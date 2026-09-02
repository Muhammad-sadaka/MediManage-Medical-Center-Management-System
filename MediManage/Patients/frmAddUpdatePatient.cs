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
    public partial class frmAddUpdatePatient : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsPatient Patient = new clsPatient();
        clsPerson Person = new clsPerson();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdatePatient_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResestDefualtValues()
        {
            cbPatientCase.DataSource = clsPatientCase.GetAllPatientCases();
            cbPatientCase.DisplayMember = "PatientCaseName";



            if (_Mode == enMode.AddNew)
            {
                Patient = new clsPatient();
                lblTitle.Text = "Add New Patient                       ";
            }
            else
                lblTitle.Text = "Update Patient                        ";


            cbPatientCase.SelectedIndex = 0;

            tbSensitivity.Text = "";
            tbChronicDiseases.Text = "";
            cbPatientCase.SelectedIndex = 0;

        }

        private void _LoadData()
        {
            Patient = clsPatient.Find(Patient.PersonID);
            Person = clsPerson.Find(Patient.PersonID);

            if (Patient == null)
            {
                MessageBox.Show("This form will be closed because No Patient with ID = " + Patient.PatientID);
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
            if(Patient == null)
            {
                MessageBox.Show("Search about Person First");
                return;
            }


            Patient.PersonID = Person.PersonID;
            Patient.Sensitivity = tbSensitivity.Text.Trim();
            Patient.ChronicDiseases = tbChronicDiseases.Text.Trim();
            Patient.JoinDate = DateTime.Now;

            Patient.PatientCaseID = cbPatientCase.SelectedIndex + 1;

            if (Patient.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Patient                        ";
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
            if(clsPerson.IsExist(tbNationalNo.Text))
            {
                Person = clsPerson.Find(tbNationalNo.Text);
                ctrlPersonInfoSummary1.LoadPersonInfoData(Person.PersonID.Value);
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
