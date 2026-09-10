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
    public partial class frmPatientsList : Form
    {
        List<clsPatientsListDTO> PatientsData;

        public frmPatientsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient();
            frm.ShowDialog();
        }

        private void frmPatientsList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshPatientsList();
        }
        private void SetupDataGridViewColumns()
        {
            DGVPatientsList.AutoGenerateColumns = false;
            DGVPatientsList.Columns.Clear();

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientID", HeaderText = "ID", Name = "PatientID" });

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NationalNo", HeaderText = "National No", Name = "NationalNo" });
            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone", Name = "Phone" });

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVPatientsList.Columns.Add(btnEdit);


            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;        
            btnDelete.UseColumnTextForButtonValue = true;
            DGVPatientsList.Columns.Add(btnDelete);

        }

        private void RefreshPatientsList()
        {
            var patientsData = clsPatient.GetAllPatients();

            PatientsData = patientsData;

            DGVPatientsList.DataSource = patientsData.Select(p => new
            {
                p.PatientID,
                p.FullName,
                p.NationalNo,
                p.Phone
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVPatientsList.RowCount} records";
        }

        private void tbNationalNo_Enter(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == "Enter National No...")
                tbNationalNo.Clear();
            tbNationalNo.ForeColor = Color.Black;
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text))
            {
                tbNationalNo.ForeColor = Color.Gray;
                tbNationalNo.Text = "Enter National No...";
            }
        }

        private void DGVPatientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int PatientID = Convert.ToInt32(DGVPatientsList.Rows[e.RowIndex].Cells["PatientID"].Value);

            if (DGVPatientsList.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                frmAddUpdatePatient frm = new frmAddUpdatePatient(PatientID);
                frm.ShowDialog();
                RefreshPatientsList();
            }
            else if (DGVPatientsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsPatient.DeletePatient(PatientID))
                    {
                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshPatientsList(); 
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This patient might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DGVPatientsList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVPatientsList.RowCount < 1) return;

            frmPatientDetails frm = new frmPatientDetails((int)DGVPatientsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNationalNo.Text) && tbNationalNo.Text != "Enter National No...") 
            {
                DGVPatientsList.DataSource = PatientsData.Select(p => new
                {
                    p.PatientID,
                    p.FullName,
                    p.NationalNo,
                    p.Phone
                }).Where(p => p.NationalNo.StartsWith(tbNationalNo.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVPatientsList.DataSource = PatientsData.Select(p => new
                {
                    p.PatientID,
                    p.FullName,
                    p.NationalNo,
                    p.Phone
                }).ToList();

            }

            lblTotalRecords.Text = $"Total: {DGVPatientsList.RowCount} records";
        }
    }
}
