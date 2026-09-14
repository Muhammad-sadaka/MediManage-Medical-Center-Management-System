using MediManage_Business;
using MediManage_DataAccess;
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
    public partial class frmAddUpdateAppointment : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        List<clsDoctorListDTO> Doctors = clsDoctor.GetAllDoctors();

        clsAppointment Appointment = new clsAppointment();
        int? _PatientID;

        public frmAddUpdateAppointment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateAppointment(int AppoitmentId)
        {
            InitializeComponent();
        
            _Mode = enMode.Update;
            Appointment.AppointmentID = AppoitmentId;
        }

        private void frmAddUpdateAppointment_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResestDefualtValues()
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd   hh:mm tt";
            //dateTimePicker1.MinDate = DateTime.Now;

            cbDoctors.DataSource = Doctors.Select(d => d.FullName).ToList();
            cbDoctors.DisplayMember = "BloodTypeSymbol";

            cbStatuses.DataSource = clsAppointmentCase.GetAllAppointmentCases();
            cbStatuses.DisplayMember = "AppointmentCaseName";

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Appointment                       ";
            }
            else
                lblTitle.Text = "Update Appointment                        ";

            cbDoctors.SelectedIndex = 0;
            tbFees.Text = Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Fees).FirstOrDefault().ToString();

            numericDuration.Value = 30;
            tbReason.Clear();
            tbNotes.Clear();

        }

        private void _LoadData()
        {
            Appointment = clsAppointment.Find(Appointment.AppointmentID);

            if (Appointment == null)
            {
                MessageBox.Show("This form will be closed because No Appointment with ID = " + Appointment.AppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPatientInfoSummary1.Enabled = false;
            tbNationalNo.Text = Appointment.PatientInfo.PersonInfo.NationalNo;
            ctrlPatientInfoSummary1.LoadPatientInfoData(tbNationalNo.Text);
            _PatientID = ctrlPatientInfoSummary1.PatientID;

            dateTimePicker1.Value = Appointment.AppointmentDate.Value;
            tbReason.Text = Appointment.Reason;
            tbNotes.Text = Appointment.Notes;
            cbDoctors.SelectedIndex = cbDoctors.FindString(Appointment.DoctorInfo.PersonInfo.FullName.Trim());
            tbFees.Text = Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Fees).FirstOrDefault().ToString();
            cbStatuses.SelectedIndex = Appointment.AppointmentCaseID.Value - 1;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPatient.IsExist(tbNationalNo.Text))
            {
                ctrlPatientInfoSummary1.LoadPatientInfoData(tbNationalNo.Text);
                _PatientID = ctrlPatientInfoSummary1.PatientID;
            }
            else
            {
                MessageBox.Show("No Patient Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_PatientID == null)
            {
                MessageBox.Show("Search about Patient First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Appointment.PatientID = _PatientID;
            Appointment.DoctorID =  Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.DoctorID).FirstOrDefault();
            Appointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Appointment.BookingDate = DateTime.Now;
            Appointment.AppointmentDate = dateTimePicker1.Value;
            Appointment.AppointmentCaseID = cbStatuses.SelectedIndex + 1;
            Appointment.Duration = Convert.ToByte(numericDuration.Value);
            Appointment.Reason = tbReason.Text;
            Appointment.Notes = tbNotes.Text;

            if (Appointment.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Appointment                        ";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
           tbFees.Text = Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Fees).FirstOrDefault().ToString();
        }
    }
}
