using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MediManage_Business;

namespace MediManage
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            Login_Load();
        }

        private void Login_Load()
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                tbUserName.TextButton = UserName;
                tbPassword.TextButton = Password;
                chkRememberMe.Checked = true;

                tbUserName.ForeColor = Color.Black;
                tbPassword.ForeColor = Color.Black;
                tbPassword.Password = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }
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
            tbUserName.Focus();
            MessageBox.Show("Invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string enteredUsername = tbUserName.TextButton.Trim();
            string enteredPassword = tbPassword.TextButton.Trim();

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
                    tbUserName.Focus();
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

        private void tbUserName_Enter(object sender, EventArgs e)
        {
            if (tbUserName.TextButton == "User name")
                tbUserName.textBox.Clear();
            tbUserName.ForeColor = Color.Black;
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.TextButton == "Password")
            {
                tbPassword.textBox.Clear();
                tbPassword.Password = true;
            }
            tbPassword.ForeColor = Color.Black;
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.TextButton))
            {
                tbPassword.ForeColor = Color.Gray;
                tbPassword.TextButton = "Password";
                tbPassword.Password = false;
            }
        }

        private void tbUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.TextButton))
            {
                tbUserName.ForeColor = Color.Gray;
                tbUserName.TextButton = "User name";
            }
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUserName.TextButton) || tbUserName.TextButton == "User name")
            {
                e.Cancel = true;
                tbUserName.Focus();
                errorProvider1.SetError(tbUserName, "UserName should have a value");
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.TextButton) || tbPassword.TextButton == "Password")
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider1.SetError(tbPassword, "Password should have a value");
            }
        }
    }
}