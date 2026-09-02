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
    public partial class frmPatientsList : Form
    {
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

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PersonID", HeaderText = "Id", Name = "PersonID" });

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVPatientsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NationalNo", HeaderText = "NationalNo", Name = "NationalNo" });
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
            var PatientsData = clsPatient.GetAllPatients().Select(p => new
            {
                p.PersonID,
                p.FullName ,
                p.NationalNo,
                p.Phone
            }).ToList();

            DGVPatientsList.DataSource = PatientsData;
            lblTotalRecords.Text = $"Total: {PatientsData.Count} records";
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


            int personId = Convert.ToInt32(DGVPatientsList.Rows[e.RowIndex].Cells["PersonID"].Value);


            if (DGVPatientsList.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                frmAddUpdatePatient frm = new frmAddUpdatePatient(personId);
                frm.ShowDialog();

            }
            else if (DGVPatientsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsPatient.DeletePatient(personId))
                    {
                        MessageBox.Show("Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This patient might be linked to other records.");
                    }
                }
            }
            RefreshPatientsList();
        }

        private void DGVPatientsList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVPatientsList.RowCount < 1) return;

            frmPatientDetails frm = new frmPatientDetails((int)DGVPatientsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshPatientsList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNationalNo.Text))
            {
                var peopleData = clsPatient.GetAllPatients().Select(p => new
                {
                    p.PersonID,
                    p.FullName, 
                    p.NationalNo,
                    p.Phone
                }).Where(p => p.NationalNo.StartsWith(tbNationalNo.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

                DGVPatientsList.DataSource = peopleData;
                lblTotalRecords.Text = $"Total: {peopleData.Count} records";
            }
            else
            {
                RefreshPatientsList();
            }
        }
    }
}
