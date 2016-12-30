using Data;
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
    public partial class CustomForm : Form
    {
        public Common common { get; set; }
        public DB db { get; set; }
        public CustomForm()
        {
            ControlBox = false;

            common = new Common();
            db = new DB();
        }
    }
}
