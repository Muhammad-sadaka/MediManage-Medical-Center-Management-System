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
        public frmPrescriptionsList()
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
            DGVUsersList.AutoGenerateColumns = false;
            DGVUsersList.Columns.Clear();

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PersonID", HeaderText = "ID", Name = "PersonID" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Patient Name", Name = "FullName" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Doctor Name", Name = "Username" });

            DGVUsersList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Date", Name = "Phone" });

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

        private void RefreshExaminationsList()
        {
            //var UserssData = clsUser.GetAllUsers().Select(u => new
            //{
            //    u.PersonID,
            //    u.FullName,
            //    u.UserName,
            //    u.Phone,
            //    u.Status
            //}).ToList();

            //DGVUsersList.DataSource = UserssData;
            //lblTotalRecords.Text = $"Total: {UserssData.Count} records";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddPrescription frm = new frmAddPrescription();
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
    }
}
