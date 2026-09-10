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
    public partial class frmAnalysesList : Form
    {
        public frmAnalysesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddAnalysis frm = new frmAddAnalysis();
            frm.ShowDialog();
        }

        private void frmAnalysesList_Load(object sender, EventArgs e)
        {
            foreach (var s in clsAnalysisStatus.GetAllAnalysisStatuses().Select(s => s.AnalysisStatusName).ToList()) cbStatuses.Items.Add(s);
            cbStatuses.SelectedIndex = 0;

            SetupDataGridViewColumns();
            RefreshAnalysesList();
        }


        private void SetupDataGridViewColumns()
        {

            DGVAnalysesList.AutoGenerateColumns = false;
            DGVAnalysesList.Columns.Clear();

            DGVAnalysesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicalAnalysisID", HeaderText = "ID", Name = "MedicalAnalysisID" });

            DGVAnalysesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Patient Name", Name = "PatientName" });

            DGVAnalysesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AnalysisType", HeaderText = "Analysis Type", Name = "AnalysisType" });

            DGVAnalysesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OrderDate", HeaderText = "Order Date", Name = "OrderDate" });

            DGVAnalysesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status" });


            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVAnalysesList.Columns.Add(btnEdit);


            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVAnalysesList.Columns.Add(btnDelete);

        }

        private void RefreshAnalysesList()
        {

            var AnalysesData = clsMedicalAnalysis.GetAllMedicalAnalyses().Select(a => new
            {
                a.MedicalAnalysisID,
                a.PatientName,
                a.AnalysisType,
                a.OrderDate,
                a.Status
            }).ToList();

            DGVAnalysesList.DataSource = AnalysesData;
            lblTotalRecords.Text = $"Total: {DGVAnalysesList.RowCount} records";
        }

        private void DGVAnalysesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            int ID = Convert.ToInt32(DGVAnalysesList.Rows[e.RowIndex].Cells["MedicalAnalysisID"].Value);


            if (DGVAnalysesList.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                frmUpdateAnalysis frm = new frmUpdateAnalysis(ID);
                frm.ShowDialog();

            }
            
            else if (DGVAnalysesList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Analysis?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsMedicalAnalysis.DeleteMedicalAnalysis(ID))
                    {
                        MessageBox.Show("Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Analysis might be linked to other records.");
                    }
                }
            }
            RefreshAnalysesList();
        }

        private void DGVAnalysesList_DoubleClick(object sender, EventArgs e)
        {
            //if (DGVAnalysesList.RowCount < 1) return;
            //frmAnalysisDetails frm = new frmAnalysisDetails((int)DGVAnalysesList.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();
            //RefreshAnalysesList();
        }

        private void tbNationalNo_Enter(object sender, EventArgs e)
        {

            if (tbPatientName.Text == "Enter Patient Name...")
                tbPatientName.Clear();
            tbPatientName.ForeColor = Color.Black;
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPatientName.Text))
            {
                tbPatientName.ForeColor = Color.Gray;
                tbPatientName.Text = "Enter Patient Name...";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
