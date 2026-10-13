using MediManage.Global_Classes;
using MediManage_Business;
using SharedDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            RefreshUsersList();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            tbUsername.Enter += clsUIActions.tbUserName_Enter;
            tbUsername.Leave += clsUIActions.tbUserName_Leave;

            // اشتراك بحدث رسم الخلية للتحكم بالحجم
            DGVUsersList.CellPainting += DGVUsersList_CellPainting;

            SetupDataGridViewColumns();
            RefreshUsersList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVUsersList.AutoGenerateColumns = false;
            DGVUsersList.Columns.Clear();

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UserID",
                HeaderText = "ID",
                Name = "UserID"
            });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Full Name",
                Name = "FullName"
            });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Username",
                Name = "Username"
            });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Phone",
                Name = "Phone"
            });

            DataGridViewCheckBoxColumn chkIsActive = new DataGridViewCheckBoxColumn();
            chkIsActive.HeaderText = "Is Active";
            chkIsActive.Name = "chkIsActive";
            chkIsActive.DataPropertyName = "Status";
            chkIsActive.FlatStyle = FlatStyle.Flat;
            DGVUsersList.Columns.Add(chkIsActive);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVUsersList.Columns.Add(btnEdit);
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

        // الحدث المسؤول عن تخصيص وتكبير حجم الـ CheckBox
        private void DGVUsersList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && DGVUsersList.Columns[e.ColumnIndex].Name == "chkIsActive")
            {
                // 1. رسم خلفية الخلية وتحديد حالة التحديد (Selection)
                e.PaintBackground(e.CellBounds, true);

                bool isChecked = false;
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    isChecked = Convert.ToBoolean(e.Value);
                }

                // 2. التحكم بحجم المربع (يمكنك تعديل 18 إلى أي حجم تريده)
                int checkBoxSize = 18;
                int x = e.CellBounds.X + (e.CellBounds.Width - checkBoxSize) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - checkBoxSize) / 2;

                Rectangle checkRect = new Rectangle(x, y, checkBoxSize, checkBoxSize);

                // 3. رسم مربع مسطح (Flat Style)
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // لون الخلفية ولون الحدود للمربع
                Color boxBackColor = Color.White;
                Color borderColor = Color.Gray;

                using (SolidBrush bgBrush = new SolidBrush(boxBackColor))
                using (Pen borderPen = new Pen(borderColor, 1.5f))
                {
                    e.Graphics.FillRectangle(bgBrush, checkRect);
                    e.Graphics.DrawRectangle(borderPen, checkRect);
                }

                // 4. رسم علامة الصح (Checkmark) في حال كان مفعلاً
                if (isChecked)
                {
                    using (Pen checkPen = new Pen(Color.DodgerBlue, 2.5f)) // يمكن تغيير اللون (مثل DodgerBlue أو Green)
                    {
                        // نقاط رسم علامة الصح المتقنة داخل المربع
                        Point[] checkPoints = new Point[]
                        {
                    new Point(checkRect.X + 4, checkRect.Y + (checkBoxSize / 2)),
                    new Point(checkRect.X + (checkBoxSize / 3) + 1, checkRect.Y + checkBoxSize - 5),
                    new Point(checkRect.X + checkBoxSize - 4, checkRect.Y + 4)
                        };

                        e.Graphics.DrawLines(checkPen, checkPoints);
                    }
                }

                e.Handled = true;
            }
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
            else if (DGVUsersList.Columns[e.ColumnIndex].Name == "chkIsActive")
            {
                DGVUsersList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                bool isChecked = Convert.ToBoolean(DGVUsersList.Rows[e.RowIndex].Cells["chkIsActive"].Value);

                string message = isChecked
                    ? "Are you sure you want to activate this user?"
                    : "Are you sure you want to deactivate this user?";

                DialogResult result = MessageBox.Show(message, "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (clsUser.ChangeUserStatus(UserID, isChecked))
                    {
                        MessageBox.Show("User status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshUsersList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshUsersList();
                    }
                }
                else
                {
                    DGVUsersList.Rows[e.RowIndex].Cells["chkIsActive"].Value = !isChecked;
                }
            }
        }

        private void DGVUsersList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVUsersList.RowCount < 1) return;
            frmUserDetails frm = new frmUserDetails((int)DGVUsersList.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
        }
    }
}