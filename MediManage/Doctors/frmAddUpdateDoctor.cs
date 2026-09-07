using MediManage_Business;
using MediManage_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class frmAddUpdateDoctor : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsDoctor Doctor = new clsDoctor();

        List<clsSpecialtyDTO> Specialties = clsSpecialty.GetAllSpecialties();

        public frmAddUpdateDoctor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateDoctor(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            Doctor.PersonID = PersonID;
        }

        private void frmAddUpdateDoctor_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResestDefualtValues()
        {

            //foreach (string s in Specialties.Select(s => s.SpecialtyName))
            //{
            //    cbSpecialties.Items.Add(s);
            //}

            cbSpecialties.DataSource = Specialties;
            cbSpecialties.DisplayMember = "SpecialtyName";

            tbConsultationFees.Text = Specialties.Where(s => s.SpecialtyName == cbSpecialties.Text).Select(s => s.Fees).FirstOrDefault().ToString();

            if (_Mode == enMode.AddNew)
            {
                Doctor = new clsDoctor();
                lblTitle.Text = "Add New Doctor                       ";
            }
            else
                lblTitle.Text = "Update Doctor                        ";


            tbLicenseNo.Text = "";
            tbQualification.Text = "";
            numericEcperienceYears.Value = 0;
            chkIsActive.Checked = true;
            cbSpecialties.SelectedIndex = 0;

        }

        private void _LoadData()
        {
            Doctor = clsDoctor.Find(Doctor.PersonID);

            if (Doctor == null)
            {
                MessageBox.Show("This form will be closed because No Doctor with ID = " + Doctor.PersonID);
                this.Close();
                return;
            }

            gbSearch.Enabled = false;
            ctrlPersonInfoSummary1.LoadPersonInfoData(Doctor.PersonID.Value);


            tbLicenseNo.Text = Doctor.LicenseNo;
            tbQualification.Text = Doctor.Qualification;
            numericEcperienceYears.Value = Doctor.YearsOfExperience.Value;
            chkIsActive.Checked = Doctor.IsActive.Value;
            cbSpecialties.SelectedIndex = Doctor.SpecialtyID.Value - 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPerson.IsExist(tbNationalNo.Text))
            {
                ctrlPersonInfoSummary1.LoadPersonInfoData(tbNationalNo.Text);
                Doctor.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
                if (clsDoctor.IsExist(tbNationalNo.Text))
                {
                    MessageBox.Show("This National No is already used for another doctor");
                    _Mode = enMode.Update;
                    _LoadData();
                }
            }
            else
            {
                MessageBox.Show("No Person Found With This National No");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Doctor == null)
            {
                MessageBox.Show("Search about Person First");
                return;
            }

            //Doctor.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
            Doctor.SpecialtyID = cbSpecialties.SelectedIndex + 1;
            Doctor.LicenseNo = tbLicenseNo.Text.Trim();
            Doctor.YearsOfExperience = Convert.ToByte(numericEcperienceYears.Value);
            Doctor.Qualification = tbQualification.Text.Trim();
            Doctor.IsActive = chkIsActive.Checked;



            if (Doctor.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Doctor                        ";
                MessageBox.Show("Data Saved Successfully.");

                // PersonIDDataBack?.Invoke(this, _PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
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

        private void cbSpecialties_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbConsultationFees.Text = Specialties.Where(s => s.SpecialtyName == cbSpecialties.Text).Select(s => s.Fees).FirstOrDefault().ToString();
        }
    }
}
