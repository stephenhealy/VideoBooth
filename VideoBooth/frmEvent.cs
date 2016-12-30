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
        private frmQuestion Question { get; set; }
        private List<OptionButton> Buttons { get; set; }
        private int EventID { get; set; }
        private Data.WorkflowQuestion initial { get; set; }

        public frmEvent(int eventID)
        {
            InitializeComponent();
            EventID = eventID;
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            LoadEvents();
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
            if (question != null)
            {
                if (initial == null)
                    initial = question;
                btnStartOver.Visible = (initial != question);

                // Remove previous buttons
                foreach (Control control in this.Controls) 
                {
                    if (control.GetType().Name == "Button" && ((Button)control).Text != "Start Over")
                        control.Visible = false;
                }

                // Setup new buttons
                Buttons = new List<OptionButton>();
                int Width = 300;
                int Height = 75;
                lblOptions.Text = question.Question;
                //int top = (this.ClientSize.Height - Height) / 2;
                int top = 150;
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
                    control.Font = new Font("Segoe UI", 12f);
                    control.Anchor = AnchorStyles.Top;
                    control.Click += new System.EventHandler(this.btnWorkflow_Click);
                    Buttons.Add(new OptionButton() { ID = button.WorkflowButtonID, button = control });
                    this.Controls.Add(control);
                    top += control.Height + 25;
                }
            }
        }

        public void Back()
        {
            // Go back to first question
            LoadWorkflowQuestion(initial);
            Show();
            Focus();
            // Always close the form
            Question.Close();
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
                        }
                        else
                        {
                            this.Hide();
                            // Since we are always closing the form, always create a new one
                            Question = new frmQuestion(this);
                            Question.EventID = EventID;
                            Question.WorkflowButtonID = option.ID;
                            Question.Display = 1;
                            bool Configured = Question.LoadVideo();
                            if (Configured)
                            {
                                Question.Show();
                                Question.Focus();
                            }
                            else
                                Back();
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
    }
}
