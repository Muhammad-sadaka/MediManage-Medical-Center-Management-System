using MediManage_Business;
using MediManage_DataAccess;
using System;
using System.Collections;
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
    public partial class frmDoctorsList : Form
    {
        List<clsDoctorListDTO> DoctorsData;

        public frmDoctorsList()
        {
            InitializeComponent();
        }

        private void frmDoctorsList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshDoctorsList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVDoctorsList.AutoGenerateColumns = false;
            DGVDoctorsList.Columns.Clear();

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorID", HeaderText = "ID", Name = "DoctorID" });

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Specialty", HeaderText = "Speciality", Name = "Specialty" });

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone", Name = "Phone" });

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVDoctorsList.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;        
            btnDelete.UseColumnTextForButtonValue = true;
            DGVDoctorsList.Columns.Add(btnDelete);
        }

        private void RefreshDoctorsList()
        {
            var doctorsData = clsDoctor.GetAllDoctors();

            DoctorsData = doctorsData;

            DGVDoctorsList.DataSource = doctorsData.Select(p => new
            {
                p.DoctorID,
                p.FullName,
                p.Specialty,
                p.Phone
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVDoctorsList.RowCount} records";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor frm = new frmAddUpdateDoctor();
            frm.ShowDialog();
            RefreshDoctorsList();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNationalNo.Text) && tbNationalNo.Text != "Enter National No...")
            {
                DGVDoctorsList.DataSource = DoctorsData.Select(p => new
                {
                    p.DoctorID,
                    p.FullName,
                    p.NationalNo,
                    p.Specialty,
                    p.Phone
                }).Where(p => p.NationalNo.StartsWith(tbNationalNo.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVDoctorsList.DataSource = DoctorsData.Select(p => new
                {
                    p.DoctorID,
                    p.FullName,
                    p.Specialty,
                    p.Phone
                }).ToList();
            }

            lblTotalRecords.Text = $"Total: {DGVDoctorsList.RowCount} records";
        }

        private void DGVDoctorsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int DoctorID = Convert.ToInt32(DGVDoctorsList.Rows[e.RowIndex].Cells["DoctorID"].Value);

            if (DGVDoctorsList.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                frmAddUpdateDoctor frm = new frmAddUpdateDoctor(DoctorID);
                frm.ShowDialog();
                RefreshDoctorsList();
            }

            else if (DGVDoctorsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsDoctor.DeleteDoctor(DoctorID))
                    {
                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDoctorsList();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Doctor might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }  
        }

        private void DGVDoctorsList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVDoctorsList.RowCount < 1) return;
            frmDoctorDetails frm = new frmDoctorDetails((int)DGVDoctorsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
