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

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PersonID", HeaderText = "ID", Name = "PersonID" });

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVDoctorsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Speciality", HeaderText = "Speciality", Name = "Speciality" });

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

            var DoctorsData = clsDoctor.GetAllDoctors().Select(d => new
            {
                d.PersonID,
                d.FullName,
                d.Speciality,
                d.Phone
            }).ToList();

            DGVDoctorsList.DataSource = DoctorsData;
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
            var DoctorsData = clsDoctor.GetAllDoctors().Select(d => new
            {
                d.PersonID,
                d.NationalNo,
                d.FullName,
                d.Speciality,
                d.Phone
            });


            if (!string.IsNullOrEmpty(tbNationalNo.Text))
            {
                DoctorsData.Where(d => d.NationalNo.StartsWith(tbNationalNo.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();         
            }
            else
            {
                DoctorsData.ToList();
            }

            DGVDoctorsList.DataSource = DoctorsData;
            lblTotalRecords.Text = $"Total: {DGVDoctorsList.RowCount} records";
        }

        private void DGVDoctorsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            int personId = Convert.ToInt32(DGVDoctorsList.Rows[e.RowIndex].Cells["PersonID"].Value);


            if (DGVDoctorsList.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                frmAddUpdateDoctor frm = new frmAddUpdateDoctor(personId);
                frm.ShowDialog();

            }

            else if (DGVDoctorsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Doctor?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsDoctor.DeleteDoctor(personId))
                    {
                        MessageBox.Show("Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Doctor might be linked to other records.");
                    }
                }
            }
            RefreshDoctorsList();
        }

        private void DGVDoctorsList_DoubleClick(object sender, EventArgs e)
        {

            if (DGVDoctorsList.RowCount < 1) return;
            frmPersonDetails frm = new frmPersonDetails((int)DGVDoctorsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshDoctorsList();
        }
    }
}
