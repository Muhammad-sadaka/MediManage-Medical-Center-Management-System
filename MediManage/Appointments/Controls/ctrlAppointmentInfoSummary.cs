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
    public partial class ctrlAppointmentInfoSummary : UserControl
    {
        clsAppointment Appointment = null;

        public ctrlAppointmentInfoSummary()
        {
            InitializeComponent();
        }

        public void LoadPersonInfoData(int AppointmentID)
        {
            if (!clsAppointment.IsExist(AppointmentID))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Appointment = clsAppointment.Find(AppointmentID);

            lblPatientName.Text = Appointment.PatientInfo.PersonInfo.FirstName + " " + Appointment.PatientInfo.PersonInfo.LastName;
            lblDoctorName.Text = Appointment.DoctorInfo.PersonInfo.FirstName + " " + Appointment.DoctorInfo.PersonInfo.LastName;
            lblDate.Text = Appointment.AppointmentDate.ToString();


            klblMoreInfo.Enabled = true;

        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAppointmentDetails frm = new frmAppointmentDetails(Appointment.AppointmentID.Value);
            frm.ShowDialog();
        }
    }
}
