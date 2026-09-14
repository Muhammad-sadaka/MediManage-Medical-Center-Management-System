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
    public partial class frmPrescriptionsList : Form
    {
        List<clsMedicalPrescriptionsListDTO> PrescriptionsData;

        public frmPrescriptionsList()
        {
            InitializeComponent();
        }

        private void frmPrescriptionsList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshPrescriptionsList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVPrescriptionsList.AutoGenerateColumns = false;
            DGVPrescriptionsList.Columns.Clear();
            
            DGVPrescriptionsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicalPrescriptionID", HeaderText = "ID", Name = "MedicalPrescriptionID" });

            DGVPrescriptionsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Patient Name", Name = "PatientName" });

            DGVPrescriptionsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Doctor Name", Name = "DoctorName" });

            DGVPrescriptionsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrescriptionDate", HeaderText = "Date", Name = "PrescriptionDate" });

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.HeaderText = "Actions";
            btnView.Text = "View";
            btnView.Name = "btnView";
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.UseColumnTextForButtonValue = true;
            DGVPrescriptionsList.Columns.Add(btnView);


            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVPrescriptionsList.Columns.Add(btnDelete);
        }

        private void RefreshPrescriptionsList()
        {
            var prescriptionsData = clsMedicalPrescription.GetAllMedicalPrescriptions();

            PrescriptionsData = prescriptionsData;

            DGVPrescriptionsList.DataSource = prescriptionsData.Select(p => new
            {
                p.MedicalPrescriptionID,
                p.PatientName,
                p.DoctorName,
                p.PrescriptionDate
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVPrescriptionsList.RowCount} records";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddPrescription frm = new frmAddPrescription();
            frm.ShowDialog();
            RefreshPrescriptionsList();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPatientName.Text) && tbPatientName.Text != "Enter Patient Name to search...")
            {
                DGVPrescriptionsList.DataSource = PrescriptionsData.Select(p => new
                {
                    p.MedicalPrescriptionID,
                    p.PatientName,
                    p.DoctorName,
                    p.PrescriptionDate
                }).Where(E => E.PatientName.StartsWith(tbPatientName.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVPrescriptionsList.DataSource = PrescriptionsData.Select(p => new
                {
                    p.MedicalPrescriptionID,
                    p.PatientName,
                    p.DoctorName,
                    p.PrescriptionDate
                }).ToList();
            }

            lblTotalRecords.Text = $"Total: {DGVPrescriptionsList.RowCount} records";
        }

        private void DGVPrescriptionsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int PrescriptionID = Convert.ToInt32(DGVPrescriptionsList.Rows[e.RowIndex].Cells["MedicalPrescriptionID"].Value);

            if (DGVPrescriptionsList.Columns[e.ColumnIndex].Name == "btnView")
            {
                frmPrescriptionDetails frm = new frmPrescriptionDetails(PrescriptionID);
                frm.ShowDialog();
            }

            else if (DGVPrescriptionsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Prescription?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsMedicineRecipe.DeleteMedicine(PrescriptionID))
                    {
                        if (clsMedicalPrescription.DeleteMedicalPrescription(PrescriptionID))                    
                            MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Delete failed. This Prescription might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        RefreshPrescriptionsList();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Prescription might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
