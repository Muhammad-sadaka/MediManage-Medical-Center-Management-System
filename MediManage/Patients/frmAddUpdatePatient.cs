using MediManage.Global_Classes;
using MediManage_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class frmAddUpdatePatient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsPatient Patient = new clsPatient();

        public frmAddUpdatePatient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePatient(int PersonId)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            Patient.PersonID = PersonId;
        }

        private void frmAddUpdatePatient_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();

            tbNationalNo.Enter += clsUIActions.tbNationalNo_Enter;
            tbNationalNo.Leave += clsUIActions.tbNationalNo_Leave;
        }

        private void _ResestDefualtValues()
        {
            cbPatientCase.DataSource = clsPatientCase.GetAllPatientCases();
            cbPatientCase.DisplayMember = "PatientCaseName";

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Patient                       ";
            }
            else
                lblTitle.Text = "Update Patient                        ";

            cbPatientCase.SelectedIndex = 0;
            tbSensitivity.Clear();
            tbChronicDiseases.Clear();
        }

        private void _LoadData()
        {
            Patient = clsPatient.Find(Patient.PersonID);

            if (Patient == null)
            {
                MessageBox.Show("This form will be closed because No Patient with ID = " + Patient.PatientID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            gbSearch.Enabled = false;
            ctrlPersonInfoSummary1.LoadPersonInfoData(Patient.PersonID.Value);

            tbSensitivity.Text = Patient.Sensitivity;
            tbChronicDiseases.Text = Patient.ChronicDiseases;
            cbPatientCase.SelectedIndex = Patient.PatientCaseID.Value - 1;
        }



      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Patient == null)
            {
                MessageBox.Show("Search about Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Patient.Sensitivity = tbSensitivity.Text.Trim();
            Patient.ChronicDiseases = tbChronicDiseases.Text.Trim();
            Patient.JoinDate = DateTime.Now;
            Patient.PatientCaseID = cbPatientCase.SelectedIndex + 1;

            if (Patient.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Patient                        ";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPerson.IsExist(tbNationalNo.Text.Trim()))
            {
                if (clsPatient.IsExist(tbNationalNo.Text.Trim()))
                {
                    MessageBox.Show("This Person is already patient in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Patient.PersonID = clsPerson.Find(tbNationalNo.Text).PersonID;
                ctrlPersonInfoSummary1.LoadPersonInfoData(Patient.PersonID.Value);
            }
            else
            {
                MessageBox.Show("No Person Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
