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
        List<clsDoctorListDTO> Doctors = clsDoctor.GetAllDoctors();

        clsAppointment Appointment = new clsAppointment();
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

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

            tbFees.Text = clsSpecialty.Find(Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Specialty).FirstOrDefault()).Fees.ToString();

            numericDuration.Value = 30;
            tbReason.Text = "";
            tbNotes.Text = "";
            


        }

        private void _LoadData()
        {
            Appointment = clsAppointment.Find(Appointment.AppointmentID);

            if (Appointment == null)
            {
                MessageBox.Show("This form will be closed because No Appointment with ID = " + Appointment.AppointmentID);
                this.Close();
                return;
            }



            dateTimePicker1.Value = Appointment.AppointmentDate.Value;
            tbReason.Text = Appointment.Reason;
            tbNotes.Text = Appointment.Notes;
            cbDoctors.SelectedIndex = cbDoctors.FindString(Appointment.DoctorInfo.PersonInfo.FullName);
            tbFees.Text = clsSpecialty.Find(Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Specialty).FirstOrDefault()).Fees.ToString();
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
            }
            else
            {
                MessageBox.Show("No Patient Found With This National No");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            Appointment.PatientID = clsPatient.Find(tbNationalNo.Text).PatientID;
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
                MessageBox.Show("Data Saved Successfully.");

                // PersonIDDataBack?.Invoke(this, _PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFees.Text = clsSpecialty.Find(Doctors.Where(d => d.FullName == cbDoctors.Text).Select(d => d.Specialty).FirstOrDefault()).Fees.ToString();
        }
    }
}
