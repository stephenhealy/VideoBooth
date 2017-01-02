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

        public CustomForm()
        {
            ControlBox = false;
            Demo = Statics.ParseBool(ConfigurationManager.AppSettings["Demo"]);

            common = new Common();
            db = new DB();
        }
    }
}
