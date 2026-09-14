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
        clsAppointment Appointment = new clsAppointment();

        public int? AppointmentID { get; set; }

        public ctrlAppointmentInfoSummary()
        {
            InitializeComponent();
        }

        public void LoadAppointmentInfoData(int? AppointmentID)
        {
            if (!clsAppointment.IsExist(AppointmentID))
            {
                MessageBox.Show("Appointment Did not Found");
                return;
            }

            Appointment = clsAppointment.Find(AppointmentID);

            AppointmentID = Appointment.AppointmentID.Value;
            lblPatientName.Text = Appointment.PatientInfo.PersonInfo.FullName;
            lblDoctorName.Text = Appointment.DoctorInfo.PersonInfo.FullName;
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
