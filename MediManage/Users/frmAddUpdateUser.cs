using BCrypt.Net;
using MediManage.Global_Classes;
using MediManage_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MediManage
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsUser user = new clsUser();

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            user.UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();

            tbNationalNo.Enter += clsUIActions.tbNationalNo_Enter;
            tbNationalNo.Leave += clsUIActions.tbNationalNo_Leave;
            tbUsername.Validating += clsValidation.ValidateEmptyTextBox;

            if (_Mode == enMode.AddNew)
            {
                tbPassword.Validating += clsValidation.ValidateEmptyTextBox;
            }
            else
            {
                tbPassword.Validating -= clsValidation.ValidateEmptyTextBox;
            }
        }

        private void _ResestDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User                       ";
            }
            else
                lblTitle.Text = "Update User                        ";

            tbUsername.Clear();
            tbPassword.Clear();
            tbConfirmPassword.Clear();
            chkIsActive.Checked = false;

            chkManageAnalyses.Checked = false;
            chkManageAppointments.Checked = false;
            chkManageDoctors.Checked = false;
            chkManageExaminations.Checked = false;
            chkManageInvoicesPayments.Checked = false;
            chkManagePatients.Checked = false;
            chkManagePeople.Checked = false;
            chkManagePrescriptions.Checked = false;
            chkManageUsers.Checked = false;

        }

        private void _LoadData()
        {
            user = clsUser.Find(user.UserID);

            if (user == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + user.UserID);
                this.Close();
                return;
            }

            gbSearch.Enabled = false;
            ctrlPersonInfoSummary1.LoadPersonInfoData(user.PersonID.Value);

            tbUsername.Text = user.UserName;
            chkIsActive.Checked = user.IsActive.Value;
            LoadPermissions(user.Permissions.Value);

        }

        void LoadPermissions(int Permissions)
        {
            if ((Permissions & 64) == 64)
                chkManageAnalyses.Checked = true;
            if ((Permissions & 8) == 8)
                chkManageAppointments.Checked = true;
            if ((Permissions & 4) == 4)
                chkManageDoctors.Checked = true;
            if ((Permissions & 16) == 16)
                chkManageExaminations.Checked = true;
            if ((Permissions & 128) == 128)
                chkManageInvoicesPayments.Checked = true;
            if ((Permissions & 2) == 2)
                chkManagePatients.Checked = true;
            if ((Permissions & 1) == 1)
                chkManagePeople.Checked = true;
            if ((Permissions & 32) == 32)
                chkManagePrescriptions.Checked = true;
            if ((Permissions & 256) == 256)
                chkManageUsers.Checked = true;
        }

        int PermissionsNumber()
        {
            int Permissions = 0;

            if (chkManageAnalyses.Checked == true)
                Permissions = Permissions | 64;
            if (chkManageAppointments.Checked == true)
                Permissions = Permissions | 8;
            if (chkManageDoctors.Checked == true)
                Permissions = Permissions | 4;
            if (chkManageExaminations.Checked == true)
                Permissions = Permissions | 16;
            if (chkManageInvoicesPayments.Checked == true)
                Permissions = Permissions | 128;
            if (chkManagePatients.Checked == true)
                Permissions = Permissions | 2;
            if (chkManagePeople.Checked == true)
                Permissions = Permissions | 1;
            if (chkManagePrescriptions.Checked == true)
                Permissions = Permissions | 32;
            if (chkManageUsers.Checked == true)
                Permissions = Permissions | 256;

            return Permissions;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (user.PersonID == null)
            {
                MessageBox.Show("Search about Person First");
                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.Permissions = PermissionsNumber();

            if (_Mode == enMode.AddNew || !string.IsNullOrEmpty(tbConfirmPassword.Text))
                user.Password = BCrypt.Net.BCrypt.HashPassword(tbConfirmPassword.Text);

            user.UserName = tbUsername.Text;
            user.IsActive = chkIsActive.Checked;
            user.CreatedByUser = clsGlobal.CurrentUser.UserID;

            if (user.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update User                        ";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPerson.IsExist(tbNationalNo.Text))
            {
                if (clsUser.IsExist(tbNationalNo.Text))
                {
                    MessageBox.Show("This National No is already used for another User", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                user.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
                ctrlPersonInfoSummary1.LoadPersonInfoData(user.PersonID.Value);
            }
            else
            {
                MessageBox.Show("No Person Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider.SetError(tbConfirmPassword, "The Confirm Password field dosn't match Password field");
            }
            else
            {
                errorProvider.SetError(tbConfirmPassword, null);
            }
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            if (clsUser.IsExistByUserName(tbUsername.Text) && tbUsername.Text != user.UserName)
            {
                e.Cancel = true;
                errorProvider.SetError(tbUsername, "This User Name is already exist");
            }
            else
            {
                errorProvider.SetError(tbUsername, null);
            }
        }
    }
}
