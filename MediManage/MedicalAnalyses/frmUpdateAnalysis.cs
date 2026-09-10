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
    public partial class frmUpdateAnalysis : Form
    {
        int AnalysisID = 0;
        public frmUpdateAnalysis(int ID)
        {
            InitializeComponent();
            AnalysisID = ID;
        }

        private void frmUpdateAnalysis_Load(object sender, EventArgs e)
        {
            ctrlAnalysisInfoSummary1.LoadAnalysisInfoData(AnalysisID);
            cbStatuses.DataSource = clsAnalysisStatus.GetAllAnalysisStatuses();
            cbStatuses.DisplayMember = "AnalysisStatusName";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsMedicalAnalysis Analysis = clsMedicalAnalysis.Find(AnalysisID);

            Analysis.Result = tbResult.Text.Trim();
            Analysis.Notes = tbNotes.Text.Trim();
            Analysis.AnalysisStatusID = cbStatuses.SelectedIndex + 1;
            Analysis.ResultDate = DateTime.Now;


            if (Analysis.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }
    }
}
