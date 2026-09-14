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
    public partial class frmExaminationsList : Form
    {
        List<clsDetectionListDTO> ExaminationsData;

        public frmExaminationsList()
        {
            InitializeComponent();
        }

        private void frmExaminationsList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshExaminationsList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVExaminationsList.AutoGenerateColumns = false;
            DGVExaminationsList.Columns.Clear();

            DGVExaminationsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DetectionID", HeaderText = "ID", Name = "DetectionID" });

            DGVExaminationsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Patient Name", Name = "PatientName" });

            DGVExaminationsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Doctor Name", Name = "DoctorName" });

            DGVExaminationsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DetectionDate", HeaderText = "Date", Name = "DetectionDate" });

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.HeaderText = "Actions";
            btnView.Text = "View";
            btnView.Name = "btnView";
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.UseColumnTextForButtonValue = true;
            DGVExaminationsList.Columns.Add(btnView);


            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVExaminationsList.Columns.Add(btnDelete);
        }

        private void RefreshExaminationsList()
        {
            var examinationsData = clsDetection.GetAllDetections();

            ExaminationsData = examinationsData;

            DGVExaminationsList.DataSource = examinationsData.Select(e => new
            {
                e.DetectionID,
                e.PatientName,
                e.DoctorName,
                e.DetectionDate
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVExaminationsList.RowCount} records";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPatientName.Text) && tbPatientName.Text != "Enter Patient Name to search...")
            {
                DGVExaminationsList.DataSource = ExaminationsData.Select(E => new
                {
                    E.DetectionID,
                    E.PatientName,
                    E.DoctorName,
                    E.DetectionDate
                }).Where(E => E.PatientName.StartsWith(tbPatientName.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVExaminationsList.DataSource = ExaminationsData.Select(E => new
                {
                    E.DetectionID,
                    E.PatientName,
                    E.DoctorName,
                    E.DetectionDate
                }).ToList();
            }

            lblTotalRecords.Text = $"Total: {DGVExaminationsList.RowCount} records";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddExamination frm = new frmAddExamination();
            frm.ShowDialog();
            RefreshExaminationsList();
        }

        private void tbPatientName_Enter(object sender, EventArgs e)
        {
            if (tbPatientName.Text == "Enter Patient Name to search...")
                tbPatientName.Clear();
            tbPatientName.ForeColor = Color.Black;
        }

        private void tbPatientName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPatientName.Text))
            {
                tbPatientName.ForeColor = Color.Gray;
                tbPatientName.Text = "Enter Patient Name to search...";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DGVExaminationsList.DataSource = ExaminationsData.Select(E => new
            {
                E.DetectionID,
                E.PatientName,
                E.DoctorName,
                E.DetectionDate
            }).Where(E => E.DetectionDate.Value.Date == dateTimePicker1.Value.Date).ToList();

            lblTotalRecords.Text = $"Total: {DGVExaminationsList.RowCount} records";
        }

        private void DGVExaminationsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int ExaminationID = Convert.ToInt32(DGVExaminationsList.Rows[e.RowIndex].Cells["DetectionID"].Value);

            if (DGVExaminationsList.Columns[e.ColumnIndex].Name == "btnView")
            {
                frmExaminationDetails frm = new frmExaminationDetails(ExaminationID);
                frm.ShowDialog();
            }

            else if (DGVExaminationsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Examination?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsDetection.DeleteDetection(ExaminationID))
                    {
                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshExaminationsList();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Examination might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
