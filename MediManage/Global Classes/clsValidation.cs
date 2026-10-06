using MediManage_Business;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MediManage.Global_Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            ErrorProvider errorProvider = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(Temp, $"{Temp.Name ?? "This field"} is required!"); // You can put Temp.Tag Allowance Temp.Name
            }
            else
            {
                errorProvider.SetError(Temp, null);
            }
        }

        public static void ValidateNumbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;

            }
        }

    }
}
