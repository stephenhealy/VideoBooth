using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBooth
{
    public partial class frmQuestion : CustomForm
    {
        private frmAnswer Answer { get; set; }
        private frmEvent Event { get; set; }
        public int EventID { get; set; }
        public int WorkflowButtonID { get; set; }
        public int QuestionID { get; set; }
        public int Display { get; set; }
        public bool Save { get; set; }

        public frmQuestion(frmEvent form)
        {
            InitializeComponent();
            Event = form;
            ScreenName = form.ScreenName;
            Maximized = form.Maximized;
        }

        private void frmQuestion_Load(object sender, EventArgs e)
        {
            Save = false;
            SetScreen();
            lblTimer.Visible = ShowTimers;
        }

        public bool Next(bool fromEvent)
        {
            Event.SetAbandonTimer();
            bool Questions = true;
            // Using the template and number, get the video and play.
            List<Data.TextQuestion> questions = db.TextQuestions.Where(o => o.WorkflowButtonID == WorkflowButtonID).OrderBy(o => o.Display).ToList();
            lblQuestion.Text = "Question # " + Display.ToString() + " of " + questions.Count.ToString() + "...";

            if (questions.Count == 0)
            {
                if (fromEvent)
                {
                    // There are no questions - show message and return to close.
                    MessageBox.Show("There are no questions prepared for the selection you made. Please try again.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Questions = false;
                }
                else
                {
                    string temp = "";
                }
            }
            else if (questions.Count >= Display) 
            {
                Data.TextQuestion question = questions.Skip(Display - 1).FirstOrDefault();
                if (question != null)
                {
                    // Check if video is prepared
                    Data.VideoQuestion video = db.VideoQuestions.FirstOrDefault(o => o.TextQuestionID == question.TextQuestionID && o.EventID == EventID);
                    if (video != null)
                    {
                        string file = video.Path;
                        //plyMedia.URL = ConvertByteDataToFile("fileName", GetUnCompressedData((byte[])Ds.Tables[0].Rows[0]["FileData"]));
                        plyMedia.URL = file;
                        plyMedia.uiMode = "none";
                        plyMedia.settings.autoStart = true;
                        lblText.Visible = false;
                    }
                    else
                    {
                        plyMedia.Visible = false;
                        lblText.Text = question.Question;
                    }
                }
                else
                {
                    MessageBox.Show("There was a problem with the question. (" + Display.ToString() + ")", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Save the submission.
                Questions = false;
            }
            return Questions;
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            // Send to answer
            plyMedia.close();
            this.Hide();

            // Since we are always closing the form, always create a new one
            Answer = new frmAnswer(this);
            Answer.Show();
            Answer.Focus();
            Answer.EventID = EventID;
            Answer.QuestionID = QuestionID;
            Answer.LoadHelp();
            Event.StopAbandonTimer();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Send back to event options
            Event.Back(Save);
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            bool More = Skip();
            if (More == false)
                Event.Back(Save);
        }

        public bool Skip()
        {
            Display++;
            return Next(false);
        }

        public void Back()
        {
            // From the answer...will advance to next question or save and return.
            Save = true;
            bool More = Skip();
            if (More)
            {
                Show();
                Focus();
            }
            else
            {
                Event.Back(Save);
            }
            // Always close the form
            Answer.Close();
        }

        private void frmQuestion_Resize(object sender, EventArgs e)
        {
            int Width = this.ClientSize.Width;
            int Height = this.ClientSize.Height;
            
            int Video = Width - 17 - 17;        // give 17px on each side for buffer
            // Dimension needs to be 16:9 aspect ratio
            int Quotient = Video / 16;      // if 1280 = 80 (will round down)
            int NewHeight = Quotient * 9;   // if 1280 = 720
            plyMedia.Size = new Size(Video, NewHeight);

            // Starts at 12
            // Button is at 509 (700 - 150 - 41)
            // 509 - 12 = 497 (give 12 px buffer to front of button)

            int MaxSize = Width - 41 - 12;
            lblText.MaximumSize = new Size(MaxSize, 0);
        }

        public void SetTimer(int timer)
        {
            lblTimer.Text = "Timer = " + timer.ToString();
            if (Answer != null)
                Answer.SetTimer(timer);
        }
    }
}
