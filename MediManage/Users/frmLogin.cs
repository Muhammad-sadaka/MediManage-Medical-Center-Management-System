using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MediManage.Global_Classes;
using MediManage_Business;

namespace MediManage
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;

                txtUserName.ForeColor = Color.Black;
                txtPassword.ForeColor = Color.Black;
            }
            else
            {
                chkRememberMe.Checked = false;
                txtUserName.Text = "User name";
                txtUserName.ForeColor = Color.Gray;
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }

            clsAppointment.UpdateAbsentAppointments();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // التقاط مفتاح Enter لتشغيل زر تسجيل الدخول
            if (keyData == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void InvalidCredentials()
        {
            txtUserName.Focus();
            MessageBox.Show("Invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredUsername = (txtUserName.Text == "User name") ? "" : txtUserName.Text.Trim();
            string enteredPassword = (txtPassword.Text == "Password") ? "" : txtPassword.Text.Trim();

            if (clsUser.IsExistByUserName(enteredUsername))
            {
                clsUser user = clsUser.Find(enteredUsername);

                if (user == null || !BCrypt.Net.BCrypt.Verify(enteredPassword, user.Password))
                {
                    InvalidCredentials();
                    return;
                }

                if (!user.IsActive.Value)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPasswordInRegistry(enteredUsername, enteredPassword);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPasswordInRegistry("", "");
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                Form frm = new frmMainScreen(this);
                frm.ShowDialog();
            }
            else
            {
                InvalidCredentials();
                return;
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "User name")
            {
                txtUserName.Text = "";
            }
            txtUserName.ForeColor = Color.Black;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.ForeColor = Color.Gray;
                txtUserName.Text = "User name";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";

            }
            txtPassword.ForeColor = Color.Black;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "Password";
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()) || txtPassword.Text == "Password")
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, $"{"Password" ?? "This field"} is required!");
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()) || txtUserName.Text == "User name")
            {
                e.Cancel = true;
                errorProvider.SetError(txtUserName, $"{"User name" ?? "This field"} is required!"); 
            }
            else
            {
                errorProvider.SetError(txtUserName, null);
            }
        }
    }
}