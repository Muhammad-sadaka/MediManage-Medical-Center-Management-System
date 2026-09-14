using MediManage_Business;
using MediManage_DataAccess;
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
    public partial class frmAddAnalysis : Form
    {
        clsMedicalAnalysis MedicalAnalysis = new clsMedicalAnalysis();
        List<clsAnalysisTypeDTO> AnalysisTypes = clsAnalysisType.GetAllAnalysisTypes();


        public frmAddAnalysis()
        {
            InitializeComponent();
        }

        private void frmAddAnalysis_Load(object sender, EventArgs e)
        {
            cbAnalysisTypes.DataSource = AnalysisTypes;
            cbAnalysisTypes.DisplayMember = "AnalysisTypeName";
            tbPrice.Text = AnalysisTypes.Where(a => a.AnalysisTypeName == cbAnalysisTypes.Text).Select(a => a.Price).FirstOrDefault().ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MedicalAnalysis.DetectionID = Convert.ToInt32(numericExaminationID.Value);
            if (clsDetection.IsExist(MedicalAnalysis.DetectionID))
            {
                ctrlExaminationInfoSummary1.LoadExaminationInfoData(MedicalAnalysis.DetectionID);
            }
            else
            {
                MessageBox.Show("No Examination Found With This ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MedicalAnalysis.DetectionID == null)
            {
                MessageBox.Show("Search about Examination First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MedicalAnalysis.Notes = tbNotes.Text.Trim();
            MedicalAnalysis.OrderDate = DateTime.Now;
            MedicalAnalysis.ResultDate = null;
            MedicalAnalysis.Result = null;
            MedicalAnalysis.AnalysisTypeID = cbAnalysisTypes.SelectedIndex + 1;
            MedicalAnalysis.AnalysisStatusID = 1;
            MedicalAnalysis.Notes = tbNotes.Text;

            if (MedicalAnalysis.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbAnalysisTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPrice.Text = AnalysisTypes.Where(a => a.AnalysisTypeName == cbAnalysisTypes.Text).Select(a => a.Price).FirstOrDefault().ToString();
        }
    }
}
