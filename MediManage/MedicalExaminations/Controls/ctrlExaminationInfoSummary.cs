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
    public partial class ctrlExaminationInfoSummary : UserControl
    {
        clsDetection Examination = new clsDetection();

        public ctrlExaminationInfoSummary()
        {
            InitializeComponent();
        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmExaminationDetails frm = new frmExaminationDetails(Examination.DetectionID);
            frm.ShowDialog();
        }

        public void LoadExaminationInfoData(int? ExaminationID)
        {
            if (!clsDetection.IsExist(ExaminationID))
            {
                MessageBox.Show("Examination Did not Found");
                return;
            }

            Examination = clsDetection.Find(ExaminationID);

            lblPatientName.Text = Examination.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblDoctorName.Text = Examination.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            lblExaminationDate.Text = Examination.DetectionDate.ToString();


            klblMoreInfo.Enabled = true;

        }

    }
}
