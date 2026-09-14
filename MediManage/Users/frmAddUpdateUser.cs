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
            if ((Permissions & 1) == 1)
                chkManageAnalyses.Checked = true;
            if ((Permissions & 2) == 2)
                chkManageAppointments.Checked = true;
            if ((Permissions & 4) == 4)
                chkManageDoctors.Checked = true;
            if ((Permissions & 8) == 8)
                chkManageExaminations.Checked = true;
            if ((Permissions & 16) == 16)
                chkManageInvoicesPayments.Checked = true;
            if ((Permissions & 32) == 32)
                chkManagePatients.Checked = true;
            if ((Permissions & 64) == 64)
                chkManagePeople.Checked = true;
            if ((Permissions & 128) == 128)
                chkManagePrescriptions.Checked = true;
            if ((Permissions & 256) == 256)
                chkManageUsers.Checked = true;
        }

        int PermissionsNumber()
        {
            int Permissions = 0;

            if (chkManageAnalyses.Checked == true)
                Permissions = Permissions | 1;
            if (chkManageAppointments.Checked == true)
                Permissions = Permissions | 2;
            if (chkManageDoctors.Checked == true)
                Permissions = Permissions | 4;
            if (chkManageExaminations.Checked == true)
                Permissions = Permissions | 8;
            if (chkManageInvoicesPayments.Checked == true)
                Permissions = Permissions | 16;
            if (chkManageInvoicesPayments.Checked == true)
                Permissions = Permissions | 32;
            if (chkManagePeople.Checked == true)
                Permissions = Permissions | 64;
            if (chkManagePrescriptions.Checked == true)
                Permissions = Permissions | 128;
            if (chkManageUsers.Checked == true)
                Permissions = Permissions | 256;

            return Permissions;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Search about Person First");
                return;
            }

            user.Permissions = PermissionsNumber();
            user.Password = clsGlobal.ComputeHash(tbConfirmPassword.Text);
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
                ctrlPersonInfoSummary1.LoadPersonInfoData(tbNationalNo.Text);
                user.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
                if (clsUser.IsExist(tbNationalNo.Text))
                {
                    MessageBox.Show("This National No is already used for another User", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Mode = enMode.Update;
                    _LoadData();
                }
            }
            else
            {
                MessageBox.Show("No Person Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbNationalNo_Enter(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == "National No")
                tbNationalNo.Clear();
            tbNationalNo.ForeColor = Color.Black;
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text))
            {
                tbNationalNo.ForeColor = Color.Gray;
                tbNationalNo.Text = "National No";
            }
        }
    }
}
