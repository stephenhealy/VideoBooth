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
    public partial class frmLogin : CustomForm
    {
        private frmMain Main { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Send to the main menu
            this.Hide();

            // Since we are always closing the form, always create a new one
            Main = new frmMain(this);
            Main.Show();
            Main.Focus();
        }

        public void Back()
        {
            // Sent from the main menu
            Show();
            Focus();
            Main.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
