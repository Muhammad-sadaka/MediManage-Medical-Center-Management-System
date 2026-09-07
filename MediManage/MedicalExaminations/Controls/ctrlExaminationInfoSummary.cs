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
        clsDetection Detection = null;

        public ctrlExaminationInfoSummary()
        {
            InitializeComponent();
        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        public void LoadExaminationInfoData(int DetectionID)
        {
            if (!clsPerson.IsExist(DetectionID))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Detection = clsDetection.Find(DetectionID);

            lblPatientName.Text = Detection.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblDoctorName.Text = Detection.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            //lblExaminationDate.Text = Detection.
            //lblTotalMedicines.Text = 

            klblMoreInfo.Enabled = true;

        }

    }
}
