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
    public partial class ctrlExaminationInfo : UserControl
    {
        clsDetection Examination = new clsDetection();
        public ctrlExaminationInfo()
        {
            InitializeComponent();
        }

        public void LoadExaminationInfoData(int? ExaminationID)
        {
            if (!clsDetection.IsExist(ExaminationID))
            {
                MessageBox.Show("Examination Did not Found");
                return;
            }

            Examination = clsDetection.Find(ExaminationID);

            klblDoctorName.Text = Examination.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            klblPatientName.Text = Examination.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblSymproms.Text = Examination.Symproms;
            lblDiagnosis.Text = Examination.Diagnosis;
            lblTemperature.Text = Examination.Temperature.ToString();
            lblWight.Text = Examination.Wight.ToString();
            lblBloodPressure.Text = Examination.BloodPressure.ToString();
            lblDetectionDate.Text = Examination.DetectionDate.ToString();
            lblHeartRate.Text = Examination.HeartRate.ToString();
            lblNotes.Text = Examination.Notes;
            lblCreatedByUser.Text = clsUser.Find(Examination.CreatedByUserID).UserName;
        }

        private void klblDoctorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Examination.AppointmentInfo.DoctorInfo.PersonID.Value);
            frm.ShowDialog();
        }

        private void klblPatientName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Examination.AppointmentInfo.PatientInfo.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
