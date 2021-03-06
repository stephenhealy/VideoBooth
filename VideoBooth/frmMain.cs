﻿using Core;
using Data;
using Models;
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

            // Setup form
            btnStop.Visible = false;

            common.DataBindDDL(ddlEvent, db.Events.Select(o => new NameID() { Name = o.Name, ID = o.EventID }).ToList());
            common.DataBindDDL(ddlScreen, Screen.AllScreens.Select(o => new TextValue() { Text = o.DeviceName, Value = o.DeviceName }).ToList());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Send back to login
            Login.Back();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ddlEvent.SelectedIndex <= 0)
            {
                MessageBox.Show("Select an event", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ddlEvent.Focus();
            }
            else
            {
                StartEvent();
                btnLogout.Enabled = false;
                ddlEvent.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Visible = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopEvent();
            btnLogout.Enabled = true;
            ddlEvent.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Visible = false;
        }

        private void StartEvent()
        {
            // Load the type of the event.
            Event = new frmEvent(this, Statics.ParseInt(common.GetDDL(ddlEvent)), common.GetDDL(ddlScreen), chkMaximize.Checked);
            thread = new Thread(() => Application.Run(Event));
            thread.SetApartmentState(ApartmentState.STA); // Deprecation Fix
            thread.Start();
        }

        private void StopEvent()
        {
            this.Invoke((MethodInvoker)delegate
            {
                // close the form on the other thread
                Event.Close();
            });
            thread.Abort();
        }
    }
}
