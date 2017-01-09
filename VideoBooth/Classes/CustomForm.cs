using Core;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBooth
{
    public partial class CustomForm : Form
    {
        public Common common { get; set; }
        public DB db { get; set; }
        public bool Demo { get; set; }
        public bool ShowTimers { get; set; }
        public string ScreenName { get; set; }
        public bool Maximized { get; set; }

        public CustomForm()
        {
            ControlBox = false;
            Demo = Statics.ParseBool(ConfigurationManager.AppSettings["Demo"]);
            ShowTimers = Statics.ParseBool(ConfigurationManager.AppSettings["ShowTimers"]);

            common = new Common();
            db = new DB();
        }

        public void SetScreen()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.DeviceName == ScreenName)
                {
                    this.Location = screen.WorkingArea.Location;
                    break;
                }
            }

            if (Maximized)
                this.WindowState = FormWindowState.Maximized;
        }
    }
}
