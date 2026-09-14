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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MediManage
{
    public partial class frmUsersList : Form
    {
        List<clsUsersListDTO> UsersData;

        public frmUsersList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshUsersList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVUsersList.AutoGenerateColumns = false;
            DGVUsersList.Columns.Clear();

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserID", HeaderText = "ID", Name = "UserID" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Full Name", Name = "FullName" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Username", Name = "Username" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Phone", Name = "Phone" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status" });

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVUsersList.Columns.Add(btnEdit);

            DataGridViewCheckBoxColumn chkIsActive = new DataGridViewCheckBoxColumn();
            chkIsActive.HeaderText = "";
            chkIsActive.Name = "chkIsActive";
            chkIsActive.FlatStyle = FlatStyle.Flat;
            DGVUsersList.Columns.Add(chkIsActive);
        }

        private void RefreshUsersList()
        {
            var usersData = clsUser.GetAllUsers();

            UsersData = usersData;

            DGVUsersList.DataSource = usersData.Select(u => new
            {
                u.UserID,
                u.FullName,
                u.UserName,
                u.Phone,
                u.Status
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVUsersList.RowCount} records";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUsername.Text) && tbUsername.Text != "Enter Username to search...")
            {
                DGVUsersList.DataSource = UsersData.Select(u => new
                {
                    u.UserID,
                    u.FullName,
                    u.UserName,
                    u.Phone,
                    u.Status
                }).Where(u => u.UserName.StartsWith(tbUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVUsersList.DataSource = UsersData.Select(u => new
                {
                    u.UserID,
                    u.FullName,
                    u.UserName,
                    u.Phone,
                    u.Status
                }).ToList();
            }

            lblTotalRecords.Text = $"Total: {DGVUsersList.RowCount} records";
        }

        private void DGVUsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int UserID = Convert.ToInt32(DGVUsersList.Rows[e.RowIndex].Cells["UserID"].Value);

            if (DGVUsersList.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                frmAddUpdateUser frm = new frmAddUpdateUser(UserID);
                frm.ShowDialog();
                RefreshUsersList();
            }
            else if (DGVUsersList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this User?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsUser.DeleteUser(UserID))
                    {
                        MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshUsersList();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This User might be linked to other records.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }   
        }

        private void DGVUsersList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVUsersList.RowCount < 1) return;
            frmUserDetails frm = new frmUserDetails((int)DGVUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void tbNationalNo_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Enter Username to search...")
                tbUsername.Clear();
            tbUsername.ForeColor = Color.Black;
        }

        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                tbUsername.ForeColor = Color.Gray;
                tbUsername.Text = "Enter Username to search...";
            }
        }
    }
}
