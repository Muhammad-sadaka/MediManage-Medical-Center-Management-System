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
    public partial class frmAppointmentsList : Form
    {
        List<clsAppointmentListDTO> Appointments = clsAppointment.GetAllAppointments();

        public frmAppointmentsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment();
            frm.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var AppointmentsData = Appointments.Select(a => new
            {
                a.AppointmentID,
                a.PatientName,
                a.DoctorName,
                a.AppointmentDate,
                a.Status
            }).Where(a => a.AppointmentDate.Value.Date == dateTimePicker1.Value.Date).ToList();

            DGVAppointmentsList.DataSource = AppointmentsData;
            lblTotalRecords.Text = $"Total: {AppointmentsData.Count} records";
        }

        private void frmAppointmentsList_Load(object sender, EventArgs e)
        {

            foreach (string s in clsDoctor.GetAllDoctorsNames())   cbDoctors.Items.Add(s);
            cbDoctors.SelectedIndex = 0;

            foreach (string s in clsAppointmentCase.GetAllAppointmentCases().Select(s => s.AppointmentCaseName))  cbStatuses.Items.Add(s);
            cbStatuses.SelectedIndex = 0;

            SetupDataGridViewColumns();
            RefreshAppointmentsList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVAppointmentsList.AutoGenerateColumns = false;
            DGVAppointmentsList.Columns.Clear();

            DGVAppointmentsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentDate", HeaderText = "ID", Name = "AppointmentDate" });

            DGVAppointmentsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Patient Name", Name = "PatientName" });

            DGVAppointmentsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DoctorName", HeaderText = "Doctor Name", Name = "DoctorName" });

            DGVAppointmentsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AppointmentDate", HeaderText = "Date & Time", Name = "AppointmentDate" });

            DGVAppointmentsList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status" });

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Actions";
            btnEdit.Text = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            DGVAppointmentsList.Columns.Add(btnEdit);


            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVAppointmentsList.Columns.Add(btnDelete);

        }

        private void RefreshAppointmentsList()
        {
            
            var AppointmentsData = Appointments.Select(a => new
            {
                a.AppointmentID,
                a.PatientName,
                a.DoctorName,
                a.AppointmentDate,
                a.Status
            }).Where(a => a.AppointmentDate.Value.Date == dateTimePicker1.Value.Date).ToList();

            DGVAppointmentsList.DataSource = AppointmentsData;
            lblTotalRecords.Text = $"Total: {DGVAppointmentsList.RowCount} records";
        }

        private void DGVAppointmentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            int AppointmentId = Convert.ToInt32(DGVAppointmentsList.Rows[e.RowIndex].Cells["AppointmentId"].Value);


            if (DGVAppointmentsList.Columns[e.ColumnIndex].Name == "btnEdit")
            {

                frmAddUpdateAppointment frm = new frmAddUpdateAppointment(AppointmentId);
                frm.ShowDialog();

            }
            else if (DGVAppointmentsList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Appointment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (clsAppointment.DeleteAppointment(AppointmentId))
                    {
                        MessageBox.Show("Deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. This Appointment might be linked to other records.");
                    }
                }
            }
            RefreshAppointmentsList();
        }

        private void DGVAppointmentsList_DoubleClick(object sender, EventArgs e)
        {
            if (DGVAppointmentsList.RowCount < 1) return;

            frmPatientDetails frm = new frmPatientDetails((int)DGVAppointmentsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshAppointmentsList();
        }

        private void cbStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
