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
    public partial class frmMain : CustomForm
    {
        private Thread thread { get; set; }
        private frmEvent Event { get; set; }
        private frmLogin Login { get; set; }
        public frmMain(frmLogin form)
        {
            InitializeComponent();
            Login = form;

            btnStop.Visible = false;
            ddlTemplate.DisplayMember = "Text";
            ddlTemplate.ValueMember = "Value";
            ddlTemplate.Items.Add(new { Text = "Wedding (Bride/Groom)", Value = "123" });
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Send back to login
            Login.Back();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter an event name", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else
            {
                btnLogout.Enabled = false;
                ddlTemplate.Enabled = false;
                txtName.Enabled = false;
                dtEvent.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Visible = true;

                // Load the type of the event.
                Event = new frmEvent();
                thread = new Thread(() => Application.Run(Event));
                thread.SetApartmentState(ApartmentState.STA); // Deprecation Fix
                thread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // close the form on the other thread
                Event.Close();
            });
            thread.Abort();

            btnLogout.Enabled = true;
            ddlTemplate.Enabled = true;
            txtName.Enabled = true;
            dtEvent.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Visible = false;
        }

    }
}
