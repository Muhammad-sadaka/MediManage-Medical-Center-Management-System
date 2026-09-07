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
        clsPerson person = new clsPerson();

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int PersonId)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            person.PersonID = PersonId;
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
                person = new clsPerson();
                lblTitle.Text = "Add New User                       ";
            }
            else
                lblTitle.Text = "Update User                        ";

            tbUsername.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
            chkIsActive.Checked = false;

            chkAnalyses.Checked = false;
            chkAppointments.Checked = false;
            chkDoctors.Checked = false;
            chkExaminations.Checked = false;
            chkInvoicesPayments.Checked = false;
            chkPatients.Checked = false;
            chkPeople.Checked = false;
            chkPrescriptions.Checked = false;
            chkUsers.Checked = false;

        }

        private void _LoadData()
        {
            person = clsPerson.Find(user.PersonID);
            user = clsUser.Find(user.PersonID);


            if (person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + person.PersonID);
                this.Close();
                return;
            }

            gbSearch.Enabled = false;
            ctrlPersonInfoSummary1.LoadPersonInfoData(user.PersonID.Value);

            tbUsername.Text = user.UserName;
            LoadPermissions(user.Permissions.Value);

        }

        void LoadPermissions(int Permissions)
        {
            if ((Permissions & 1) == 1)          
                 chkAnalyses.Checked = true;
            if ((Permissions & 2) ==2)
                chkAppointments.Checked = true;
            if ((Permissions & 4) == 4)
                chkDoctors.Checked = true;
            if ((Permissions & 8) == 8)
                chkExaminations.Checked = true;
            if ((Permissions & 16) == 16)
                chkInvoicesPayments.Checked = true;
            if ((Permissions & 32) == 32)
                chkPatients.Checked = true;
            if ((Permissions & 64) == 64)
                chkPeople.Checked = true;
            if ((Permissions & 128) == 128)
                chkPrescriptions.Checked = true;
            if ((Permissions & 256) == 256)
                chkUsers.Checked = true;
        }

        int PermissionsNumber()
        {
            int Permissions = 0;

            if (chkAnalyses.Checked == true)
                Permissions = Permissions | 1;
            if (chkAppointments.Checked == true)
                Permissions = Permissions | 2;
            if (chkDoctors.Checked == true)
                Permissions = Permissions | 4;
            if (chkExaminations.Checked == true)
                Permissions = Permissions | 8;
            if (chkInvoicesPayments.Checked == true)
                Permissions = Permissions | 16;
            if (chkPatients.Checked == true)
                Permissions = Permissions | 32;
            if (chkPeople.Checked == true)
                Permissions = Permissions | 64;
            if (chkPrescriptions.Checked == true)
                Permissions = Permissions | 128;
            if (chkUsers.Checked == true)
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

            user.PersonID = person.PersonID;

            user.Permissions = PermissionsNumber();
            user.Password = clsGlobal.ComputeHash(tbConfirmPassword.Text);
            user.UserName = tbUsername.Text;
            user.IsActive = chkIsActive.Checked;
            user.CreatedByUser = clsGlobal.CurrentUser.UserID;


            if (user.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update User                        ";
                MessageBox.Show("Data Saved Successfully.");

                // PersonIDDataBack?.Invoke(this, _PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPerson.IsExist(tbNationalNo.Text))
            {
                person = clsPerson.Find(tbNationalNo.Text);
                ctrlPersonInfoSummary1.LoadPersonInfoData(person.PersonID.Value);
            }
            else
            {
                MessageBox.Show("No Person Found With This National No");
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
            if (tbNationalNo.Text == "" || tbNationalNo.Text == null)
            {
                tbNationalNo.ForeColor = Color.Gray;
                tbNationalNo.Text = "National No";
            }
        }
    }
}
