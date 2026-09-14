using MediManage_Business;
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
    public partial class ctrlappointmentInfo : UserControl
    {
        clsAppointment Appointment = new clsAppointment();

        public ctrlappointmentInfo()
        {
            InitializeComponent();
        }

        public void LoadAppointmentInfoData(int AppointmentID)
        {
            if (!clsAppointment.IsExist(AppointmentID))
            {
                MessageBox.Show("Appointment Did not Found");
                return;
            }

            Appointment = clsAppointment.Find(AppointmentID);

            klblDoctorName.Text = Appointment.DoctorInfo.PersonInfo.FullName;
            klblPatientName.Text = Appointment.PatientInfo.PersonInfo.FullName;
            lblBookingDate.Text = Appointment.BookingDate.ToString();
            lblAppointmentDate.Text = Appointment.AppointmentDate.ToString();
            lblAppointmentCase.Text = Appointment.AppointmentCaseInfo.AppointmentCaseName.ToString();
            lblDuration.Text = Appointment.Duration.ToString();
            lblReason.Text = Appointment.Reason;
            lblNotes.Text = Appointment.Notes;
            lblCreatedByUser.Text = clsUser.Find(Appointment.CreatedByUserID).UserName;
        }

        private void klblDoctorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Appointment.DoctorInfo.PersonID.Value);
            frm.ShowDialog();
        }

        private void klblPatientName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Appointment.PatientInfo.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
