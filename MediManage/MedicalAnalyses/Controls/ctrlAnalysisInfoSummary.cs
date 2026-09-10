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
    public partial class ctrlAnalysisInfoSummary : UserControl
    {
        clsMedicalAnalysis Analysis = new clsMedicalAnalysis();

        public ctrlAnalysisInfoSummary()
        {
            InitializeComponent();
        }

        public void LoadAnalysisInfoData(int ID)
        {
            if (!clsMedicalAnalysis.IsExist(ID))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Analysis = clsMedicalAnalysis.Find(ID);
            LoadData();



        }

        void LoadData()
        {
            lblPatientName.Text = Analysis.DetectionInfo.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblAnalysisType.Text = Analysis.AnalysisTypeInfo.AnalysisTypeName.ToString();
            lblOrderDate.Text = Analysis.OrderDate.ToString();

            klblMoreInfo.Enabled = true;
        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmPersonDetails frm = new frmPersonDetails(Person.PersonID.Value);
            //frm.ShowDialog();
        }
    }
}
