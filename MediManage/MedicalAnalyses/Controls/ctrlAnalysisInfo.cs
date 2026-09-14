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
    public partial class ctrlAnalysisInfo : UserControl
    {
        clsMedicalAnalysis Analysis = new clsMedicalAnalysis();

        public ctrlAnalysisInfo()
        {
            InitializeComponent();
        }

        public void LoadAnalysisInfoData(int AnalysisID)
        {
            if (!clsMedicalAnalysis.IsExist(AnalysisID))
            {
                MessageBox.Show("Analysis Did not Found");
                return;
            }

            Analysis = clsMedicalAnalysis.Find(AnalysisID);

            klblDoctorName.Text = Analysis.DetectionInfo.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            klblPatientName.Text = Analysis.DetectionInfo.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblResult.Text = Analysis.Result;
            lblOrderData.Text = Analysis.OrderDate.ToString();
            lblResultData.Text = Analysis.ResultDate.ToString();
            lblAnalysisStatus.Text = Analysis.AnalysisStatusInfo.AnalysisStatusName.ToString();
            lblAnalysisType.Text = Analysis.AnalysisTypeInfo.AnalysisTypeName.ToString();
            lblNotes.Text = Analysis.Notes;
        }

        private void klblDoctorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Analysis.DetectionInfo.AppointmentInfo.DoctorInfo.PersonID.Value);
            frm.ShowDialog();
        }

        private void klblPatientName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Analysis.DetectionInfo.AppointmentInfo.PatientInfo.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
