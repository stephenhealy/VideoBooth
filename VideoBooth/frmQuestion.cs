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
        public int TemplateID { get; set; }
        public int Number { get; set; }
        public frmQuestion(frmEvent form)
        {
            InitializeComponent();
            Event = form;
        }

        public void LoadVideo()
        {
            // Using the template and number, get the video and play.

            lblQuestion.Text = "Question # " + Number.ToString() + " of 13...";

            string file = @"C:\Users\Public\Videos\Sample Videos\Wildlife.wmv";
            //plyMedia.URL = ConvertByteDataToFile("fileName", GetUnCompressedData((byte[])Ds.Tables[0].Rows[0]["FileData"]));
            plyMedia.URL = file;
            plyMedia.uiMode = "none";
            plyMedia.settings.autoStart = true;
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            // Send to answer
            plyMedia.close();
            this.Hide();
            // Since we are always closing the form, always create a new one
            Answer = new frmAnswer(this);
            Answer.TemplateID = TemplateID;
            Answer.Number = Number;
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
            Number++;
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
