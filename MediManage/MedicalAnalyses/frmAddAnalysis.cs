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
            int ID = Convert.ToInt32(numericExaminationID.Value);
            if (clsDetection.IsExist(ID))
            {
                ctrlExaminationInfoSummary1.LoadExaminationInfoData(ID);
            }
            else
            {
                MessageBox.Show("No Examination Found With This ID");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MedicalAnalysis.DetectionID = Convert.ToInt32(numericExaminationID.Value);
            MedicalAnalysis.Notes = tbNotes.Text.Trim();
            MedicalAnalysis.OrderDate = DateTime.Now;
            MedicalAnalysis.ResultDate = null;
            MedicalAnalysis.Result = null;
            MedicalAnalysis.AnalysisTypeID = cbAnalysisTypes.SelectedIndex + 1;
            MedicalAnalysis.AnalysisStatusID = 1;


            if (MedicalAnalysis.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }

        private void cbAnalysisTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPrice.Text = AnalysisTypes.Where(a => a.AnalysisTypeName == cbAnalysisTypes.Text).Select(a => a.Price).FirstOrDefault().ToString();
        }
    }
}
