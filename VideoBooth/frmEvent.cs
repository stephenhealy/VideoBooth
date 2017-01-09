using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBooth
{
    public partial class frmEvent : CustomForm
    {
        private frmMain Main { get; set; }
        private frmQuestion Question { get; set; }
        private List<OptionButton> Buttons { get; set; }
        private int EventID { get; set; }
        private Data.WorkflowQuestion initial { get; set; }
        // Counter for thanks to appear and then hide
        private System.Windows.Forms.Timer TimerThanks;
        private int CounterThanks { get; set; }
        // Counter for abandonement
        private System.Windows.Forms.Timer TimerAbandon;
        private int CounterAbandon { get; set; }

        public frmEvent(frmMain form, int eventID, string screenName, bool maximize)
        {
            InitializeComponent();
            Main = form;
            EventID = eventID;
            ScreenName = screenName;
            Maximized = maximize;
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            LoadEvents();
            SetScreen();
            lblTimer.Visible = ShowTimers;
        }

        public void LoadEvents()
        {
            List<Data.WorkflowQuestion> questions = (from _Workflows in db.Workflows
                                                     join _WorkflowQuestions in db.WorkflowQuestions
                                                     on _Workflows.WorkflowQuestionID equals _WorkflowQuestions.WorkflowQuestionID
                                                     where !(from _WorkflowButtons in db.WorkflowButtons
                                                             select _WorkflowButtons.NextWorkflowQuestionID)
                                                            .Contains(_Workflows.WorkflowQuestionID)
                                                            && _Workflows.EventID == EventID
                                                     select _WorkflowQuestions).OrderBy(o => o.Display).ToList();

            if (questions.Count > 0)
                LoadWorkflowQuestion(questions.FirstOrDefault());
        }

        public void LoadWorkflowQuestion(Data.WorkflowQuestion question)
        {
            SetAbandonTimer();
            if (question != null)
            {
                if (initial == null)
                    initial = question;
                btnStartOver.Visible = (initial != question);

                ClearButtons();

                // Setup new buttons
                Buttons = new List<OptionButton>();
                int Width = 300;
                int Height = 60;
                string text = question.Question;
                while (text.Contains("@"))
                {
                    string before = text.Substring(0, text.IndexOf("@"));
                    string field = text.Substring(text.IndexOf("@"));
                    int indexOf = 9999;
                    if (field.IndexOf(" ") > 0)
                        indexOf = field.IndexOf(" ");
                    if (field.IndexOf(".") > 0 && field.IndexOf(".") < indexOf)
                        indexOf = field.IndexOf(".");
                    if (field.IndexOf(",") > 0 && field.IndexOf(",") < indexOf)
                        indexOf = field.IndexOf(",");
                    if (field.IndexOf(";") > 0 && field.IndexOf(";") < indexOf)
                        indexOf = field.IndexOf(",");
                    if (field.IndexOf(";") > 0 && field.IndexOf(";") < indexOf)
                        indexOf = field.IndexOf(";");
                    if (field.IndexOf("!") > 0 && field.IndexOf("!") < indexOf)
                        indexOf = field.IndexOf("!");
                    string after = field.Substring(indexOf - 1);
                    field = field.Substring(1, indexOf - 2);

                    // Look up field
                    Data.Field Field = (from fields in db.Fields
                                        join requirements in db.Requirements
                                        on fields.RequiredID equals requirements.RequiredID
                                        where fields.EventID == EventID
                                        && requirements.Name == field
                                        select fields).FirstOrDefault();
                    if (Field != null)
                        text = before + Field.Value + after;
                }
                lblOptions.Text = text;
                //int top = (this.ClientSize.Height - Height) / 2;
                int top = 100;
                int left = (this.ClientSize.Width - Width) / 2;

                List<Data.WorkflowButton> buttons = db.WorkflowButtons.Where(o => o.WorkflowQuestionID == question.WorkflowQuestionID).ToList();
                foreach (Data.WorkflowButton button in buttons)
                {
                    Button control = new Button();
                    control.Left = left;
                    control.Top = top;
                    control.Width = Width;
                    control.Height = Height;
                    control.Text = button.Text;
                    control.Font = new Font("Arial", 12f);
                    control.Anchor = AnchorStyles.Top;
                    control.FlatStyle = FlatStyle.Flat;
                    control.BackColor = Color.White;
                    control.Click += new System.EventHandler(this.btnWorkflow_Click);
                    Buttons.Add(new OptionButton() { ID = button.WorkflowButtonID, button = control });
                    this.Controls.Add(control);
                    top += control.Height + 15;
                }
            }
        }

        private void ClearButtons()
        {
            // Remove previous buttons
            foreach (Control control in this.Controls)
            {
                if (control.GetType().Name == "Button" && ((Button)control).Text != "Start Over")
                    control.Visible = false;
            }
        }

        public void Back(bool saved)
        {
            if (saved)
            {
                ClearButtons();
                lblOptions.Visible = false;
                lblSaved.Visible = lblThanks.Visible = lblInformation.Visible = true;

                CounterThanks = 10;     // Wait 10 seconds
                TimerThanks = new System.Windows.Forms.Timer();
                TimerThanks.Tick += new EventHandler(timerThanks_Tick);
                TimerThanks.Interval = 1000; // 1 second
                TimerThanks.Start();
            }
            else
            {
                // Go back to first question
                LoadWorkflowQuestion(initial);
            }
            Show();
            Focus();
            // Always close the form
            Question.Close();
        }

        private void timerThanks_Tick(object sender, EventArgs e)
        {
            CounterThanks--;
            if (CounterThanks == 0)
            {
                TimerThanks.Stop();
                lblOptions.Visible = true;
                lblSaved.Visible = lblThanks.Visible = lblInformation.Visible = false;
                // Go back to first question
                LoadWorkflowQuestion(initial);
            }
        }

        private void btnWorkflow_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            foreach (OptionButton option in Buttons)
            {
                if (clicked == option.button)
                {
                    Data.WorkflowButton button = db.WorkflowButtons.FirstOrDefault(o => o.WorkflowButtonID == option.ID);
                    if (button != null)
                    {
                        if (button.NextWorkflowQuestionID > 0)
                        {
                            LoadWorkflowQuestion(db.WorkflowQuestions.FirstOrDefault(o => o.WorkflowQuestionID == button.NextWorkflowQuestionID));
                            SetAbandonTimer();
                        }
                        else
                        {
                            this.Hide();
                            // Since we are always closing the form, always create a new one
                            Question = new frmQuestion(this);
                            Question.EventID = EventID;
                            Question.WorkflowButtonID = option.ID;
                            Question.Display = 1;
                            bool Configured = Question.Next(true);
                            if (Configured)
                            {
                                Question.Show();
                                Question.Focus();
                            }
                            else
                                Back(false);
                        }
                    }
                    else
                        MessageBox.Show("Could not find the button - " + option.ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
        }

        private void btnStartOver_Click(object sender, EventArgs e)
        {
            LoadWorkflowQuestion(initial);
        }

        private void frmEvent_Resize(object sender, EventArgs e)
        {
            int Width = this.ClientSize.Width;
            int Height = this.ClientSize.Height;

            // Starts at 12
            // Button is at 509 (700 - 150 - 41)
            // 509 - 12 = 497 (give 12 px buffer to front of button)

            int MaxSize = Width - 41 - 12;
            lblOptions.MaximumSize = new Size(MaxSize, 0);
            lblInformation.MaximumSize = new Size(MaxSize, 0);
        }

        public void StopAbandonTimer()
        {
            if (TimerAbandon != null)
                TimerAbandon.Stop();
        }

        public void SetAbandonTimer()
        {
            StopAbandonTimer();
            CounterAbandon = 10;     // Wait 10 seconds
            TimerAbandon = new System.Windows.Forms.Timer();
            TimerAbandon.Tick += new EventHandler(timerAbandon_Tick);
            TimerAbandon.Interval = 1000; // 1 second
            TimerAbandon.Start();
        }

        private void timerAbandon_Tick(object sender, EventArgs e)
        {
            CounterAbandon--;
            SetTimer(CounterAbandon);
            if (CounterAbandon == 0)
            {
                TimerAbandon.Stop();
                // Always close the frm
                if (Question != null)
                {
                    Question.Close();
                    Show();
                    Focus();
                }
                // Go back to first question
                LoadWorkflowQuestion(initial);
            }
        }

        public void SetTimer(int timer)
        {
            lblTimer.Text = "Timer = " + timer.ToString();
            if (Question != null)
                Question.SetTimer(timer);
        }
    }
}
