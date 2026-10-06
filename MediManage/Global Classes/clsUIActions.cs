using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediManage_Business;
using System.Windows.Forms;
using System.Web;

namespace MediManage.Global_Classes
{
    public class  clsUIActions
    {
        public static void Button_MouseHover(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                btn.ForeColor = Color.Red;
            }
        }

        public static void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                btn.ForeColor = Color.Black;
            }
        }

        static void _TextBox_Leave(object sender,string Text)
        {
            if (sender is Control textbox)
            {
                if (string.IsNullOrEmpty(textbox.Text))
                {
                    textbox.ForeColor = Color.Gray;
                    textbox.Text = Text;
                }
            }
        }

        static void _TextBox_Enter(object sender, string Text)
        {
            if (sender is Control textbox)
            {
                if (textbox.Text == Text)
                    textbox.Text = "";
                textbox.ForeColor = Color.Black;
            }
        }

        public static void tbNationalNo_Leave(object sender, EventArgs e)
        {
            _TextBox_Leave(sender, "National No");
        }

        public static void tbNationalNo_Enter(object sender, EventArgs e)
        {
            _TextBox_Enter(sender, "National No");
        }

        public static void tbPatientName_Enter(object sender, EventArgs e)
        {
            _TextBox_Enter(sender, "Enter Patient Name");
        }

        public static void tbPatientName_Leave(object sender, EventArgs e)
        {
            _TextBox_Leave(sender, "Enter Patient Name");
        }

        public static void tbUserName_Enter(object sender, EventArgs e)
        {
            _TextBox_Enter(sender, "Enter User Name");
        }

        public static void tbUserName_Leave(object sender, EventArgs e)
        {
            _TextBox_Leave(sender, "Enter User Name");
        }

    }
}
