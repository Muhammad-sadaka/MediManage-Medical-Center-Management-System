using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediManage_Business;
using MediManage_DataAccess;

namespace MediManage
{
    public partial class frmPeopleList : Form
    {
        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns(); 
            RefreshPeopleList();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();  
            frm.ShowDialog();
        }

        private void tbNationalNo_Enter(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == "National No")
                tbNationalNo.Clear();
            tbNationalNo.ForeColor = Color.Black;
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == "" || tbNationalNo.Text == null)
            {
                tbNationalNo.ForeColor = Color.Gray;
                tbNationalNo.Text = "National No";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNationalNo.Text))
            {
                var peopleData = clsPerson.GetAllPeople().Select(p => new
                {
                    p.PersonID,
                    FullName = $"{p.FirstName} {p.SecondName} {p.ThirdName} {p.LastName}".Replace("  ", " ").Trim(),
                    p.NationalNo,
                    p.Phone
                }).Where(p => p.NationalNo.StartsWith(tbNationalNo.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

                DGVPeopleList.DataSource = peopleData;
                lblTotalRecords.Text = $"Total: {peopleData.Count} records";
            }
            else
            {
                RefreshPeopleList();
            }
        }

        private void SetupDataGridViewColumns()
        {
            // 1. منع الجدول من توليد كل أعمدة الـ DTO تلقائياً
            DGVPeopleList.AutoGenerateColumns = false;
            DGVPeopleList.Columns.Clear();

            // 2. إضافة الأعمدة العادية وربطها بخصائص الـ DTO (DataPropertyName)
            DGVPeopleList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PersonID", HeaderText = "Id", Name = "PersonID" });

            // ملاحظة: إذا كان الـ DTO لا يحتوي على خاصية FullName جاهزة، يفضل دمج الأسماء في الـ LINQ أو الـ DTO أولاً
            DGVPeopleList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVPeopleList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NationalNo", HeaderText = "NationalNo", Name = "NationalNo" });
            DGVPeopleList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone", Name = "Phone" });

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true; 
            DGVPeopleList.Columns.Add(btnEdit);
            

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;        // You can remove it and it will set the default
            btnDelete.UseColumnTextForButtonValue = true; // To Show "Delete" inside the button
            DGVPeopleList.Columns.Add(btnDelete);

        }

        private void RefreshPeopleList()
        {
            var peopleData = clsPerson.GetAllPeople().Select(p => new
            {
                p.PersonID,
                FullName = $"{p.FirstName} {p.SecondName} {p.ThirdName} {p.LastName}".Replace("  ", " ").Trim(),
                p.NationalNo,
                p.Phone
            }).ToList();

            DGVPeopleList.DataSource = peopleData;
            lblTotalRecords.Text = $"Total: {peopleData.Count} records";
        } 

        private void DGVPeopleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

           
            int personId = Convert.ToInt32(DGVPeopleList.Rows[e.RowIndex].Cells["PersonID"].Value);


            if (DGVPeopleList.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                frmAddUpdatePerson frm = new frmAddUpdatePerson(personId);
                frm.ShowDialog();

            }

            else if (DGVPeopleList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this person?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsPerson.DeletePerson(personId))
                    {
                        MessageBox.Show("Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This person might be linked to other records.");
                    }
                }
            }
            RefreshPeopleList();
        }

        private void DGVPeopleList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVPeopleList.RowCount < 1) return;
            frmPersonDetails frm = new frmPersonDetails((int)DGVPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshPeopleList();
        }
    }
}
