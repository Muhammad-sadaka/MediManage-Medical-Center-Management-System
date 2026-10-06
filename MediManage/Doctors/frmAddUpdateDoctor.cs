using MediManage.Global_Classes;
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

        public frmAddUpdateDoctor(int DoctorID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            Doctor.DoctorID = DoctorID;
        }

        private void frmAddUpdateDoctor_Load(object sender, EventArgs e)
        {
            tbNationalNo.Enter += clsUIActions.tbNationalNo_Enter;
            tbNationalNo.Leave += clsUIActions.tbNationalNo_Leave;
            tbQualification.Validating += clsValidation.ValidateEmptyTextBox;
            tbLicenseNo.Validating += clsValidation.ValidateEmptyTextBox;

            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResestDefualtValues()
        {
            cbSpecialties.DataSource = Specialties;
            cbSpecialties.DisplayMember = "SpecialtyName";

            tbConsultationFees.Text = Specialties.Where(s => s.SpecialtyName == cbSpecialties.Text).Select(s => s.Fees).FirstOrDefault().ToString();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Doctor                       ";
            }
            else
                lblTitle.Text = "Update Doctor                        ";

            tbLicenseNo.Clear();
            tbQualification.Clear();
            numericEcperienceYears.Value = 0;
            chkIsActive.Checked = true;
            cbSpecialties.SelectedIndex = 0;
        }

        private void _LoadData()
        {
            Doctor = clsDoctor.Find(Doctor.DoctorID);

            if (Doctor == null)
            {
                MessageBox.Show("This form will be closed because No Doctor with ID = " + Doctor.DoctorID,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            if (clsPerson.IsExist(tbNationalNo.Text.Trim()))
            {
                if (clsDoctor.IsExist(tbNationalNo.Text.Trim()))
                {
                    MessageBox.Show("This Person is already exist in the system","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                Doctor.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
                ctrlPersonInfoSummary1.LoadPersonInfoData(Doctor.PersonID.Value);
            }
            else
            {
                MessageBox.Show("No Person Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Doctor == null)
            {
                MessageBox.Show("Search about Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Doctor.SpecialtyID = cbSpecialties.SelectedIndex + 1;
            Doctor.LicenseNo = tbLicenseNo.Text.Trim();
            Doctor.YearsOfExperience = Convert.ToByte(numericEcperienceYears.Value);
            Doctor.Qualification = tbQualification.Text.Trim();
            Doctor.IsActive = chkIsActive.Checked;

            if (Doctor.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Doctor                        ";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSpecialties_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbConsultationFees.Text = Specialties.Where(s => s.SpecialtyName == cbSpecialties.Text).Select(s => s.Fees).FirstOrDefault().ToString();
        }
    }
}
