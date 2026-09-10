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
    public partial class frmExaminationsList : Form
    {
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

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVExaminationsList.Columns.Add(btnEdit);


            DataGridViewCheckBoxColumn chkIsActive = new DataGridViewCheckBoxColumn();
            chkIsActive.HeaderText = "";
            chkIsActive.Name = "chkIsActive";
            chkIsActive.FlatStyle = FlatStyle.Flat;
            DGVExaminationsList.Columns.Add(chkIsActive);
        }

        private void RefreshExaminationsList()
        {
            var ExaminationsData = clsDetection.GetAllDetections().Select(e => new
            {
                e.DetectionID,
                e.PatientName,
                e.DoctorName,
                e.DetectionDate
            }).ToList();

            DGVExaminationsList.DataSource = ExaminationsData;
            lblTotalRecords.Text = $"Total: {DGVExaminationsList.RowCount} records";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddExamination frm = new frmAddExamination();
            frm.ShowDialog();
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

        }
    }
}
