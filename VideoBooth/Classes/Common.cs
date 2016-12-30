using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoBooth
{
    public class Common
    {
        public void DataBindDDL(ComboBox ddl, List<TextValue> items)
        {
            DataBindDDL(ddl, items, null);
        }
        public void DataBindDDL(ComboBox ddl, List<TextValue> items, string _0_text)
        {
            ddl.DisplayMember = "Text";
            ddl.ValueMember = "Value";
            foreach (TextValue item in items)
                ddl.Items.Add(item);
            if (_0_text != null)
            {
                if (_0_text != "")
                    ddl.Items.Insert(0, new TextValue() { Text = _0_text, Value = "0" });
            }
            else
                ddl.Items.Insert(0, new TextValue() { Text = "-- select --", Value = "0" });
            ddl.SelectedIndex = 0;
        }
        public void DataBindDDL(ComboBox ddl, List<NameID> items)
        {
            DataBindDDL(ddl, items, null);
        }
        public void DataBindDDL(ComboBox ddl, List<NameID> items, string _0_text)
        {
            ddl.DisplayMember = "Text";
            ddl.ValueMember = "Value";
            foreach (NameID item in items)
                ddl.Items.Add(new TextValue() { Text = item.Name, Value = item.ID.ToString() });
            if (_0_text != null)
            {
                if (_0_text != "")
                    ddl.Items.Insert(0, new TextValue() { Text = _0_text, Value = "0" });
            }
            else
                ddl.Items.Insert(0, new TextValue() { Text = "-- select --", Value = "0" });
            ddl.SelectedIndex = 0;
        }
        public string GetDDL(ComboBox ddl)
        {
            return ((TextValue)ddl.SelectedItem).Value;
        }
    }
}
