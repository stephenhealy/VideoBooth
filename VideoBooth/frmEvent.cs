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
        public frmEvent()
        {
            InitializeComponent();
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        public void LoadEvents()
        {
            Buttons = new List<OptionButton>();
            lblOptions.Text = "What is your relationship with the wedding couple?";
            int top = 50;
            int left = 100;
            for (int ii = 0; ii < 5; ii++)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Width = 200;
                button.Height = 40;
                button.Text = "Wedding Party";
                button.Font = new Font("Segoe UI", 10f);
                button.Click += new System.EventHandler(this.btnEvent_Click);
                Buttons.Add(new OptionButton() { ID = ii, button = button });
                this.Controls.Add(button);
                top += button.Height + 10;
            }
        }

        public void Back()
        {
            Show();
            Focus();
            // Always close the form
            Question.Close();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            foreach (OptionButton option in Buttons)
            {
                if (clicked == option.button)
                {
                    this.Hide();
                    // Since we are always closing the form, always create a new one
                    Question = new frmQuestion(this);
                    Question.TemplateID = option.ID;
                    Question.Number = 1;
                    Question.LoadVideo();
                    Question.Show();
                    Question.Focus();
                    break;
                }
            }
        }
    }
}
