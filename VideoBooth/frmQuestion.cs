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
    public partial class frmQuestion : CustomForm
    {
        private frmAnswer Answer { get; set; }
        private frmEvent Event { get; set; }
        public int EventID { get; set; }
        public int WorkflowButtonID { get; set; }
        public int QuestionID { get; set; }
        public int Display { get; set; }
        public frmQuestion(frmEvent form)
        {
            InitializeComponent();
            Event = form;
        }

        public bool LoadVideo()
        {
            bool Questions = true;
            // Using the template and number, get the video and play.
            List<Data.TextQuestion> questions = db.TextQuestions.Where(o => o.WorkflowButtonID == WorkflowButtonID).OrderBy(o => o.Display).ToList();
            lblQuestion.Text = "Question # " + Display.ToString() + " of " + questions.Count.ToString() + "...";

            if (questions.Count <= Display) 
            {
                int Skip = Display - 1;
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
                    }
                    else
                    {
                        MessageBox.Show(question.Question);
                    }
                }
                else
                {
                    MessageBox.Show("There are no questions prepared for the selection you made. Please try again.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Questions = false;
                }
            }
            else
            {
                // Save the submission.
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
            Answer.EventID = EventID;
            Answer.QuestionID = QuestionID;
            Answer.LoadWebcam(true);
            Answer.Show();
            Answer.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Send back to event options
            Event.Back();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Skip();
        }

        public void Skip()
        {
            Display++;
            LoadVideo();
        }

        public void Back()
        {
            // From the answer...will advance to next question
            Skip();
            Show();
            Focus();
            // Always close the form
            Answer.Close();
        }
    }
}
