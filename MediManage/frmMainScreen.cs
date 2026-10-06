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
using MediManage.Global_Classes;

namespace MediManage
{
    public partial class frmMainScreen : Form
    {
        frmLogin _frmLogin;

        public frmMainScreen(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
            LoadHomePage();
        }

        void LoadHomePage()
        {
            lblWelcome.Text = "Welcome " + clsGlobal.CurrentUser.PersonInfo.FirstName;
            lblTodayDate.Text = "Today's date: " + DateTime.Today.ToLongDateString();
            lblTotalPatients.Text = "Total Patients = " + clsPatient.GetTotalPatientsNumber();
            lblTodayRevenue.Text = "Today Revenue = $" + clsPayment.GetTotalTodayPayments();
            DGVTodayAppointments.DataSource = clsAppointment.GetTodayAppointments();
            lblTodayAppointments.Text = "Today Appointments = " + DGVTodayAppointments.RowCount.ToString();

            MouseHover_Leave_Buttons();
        }

        private void hopeTabPage1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    LoadHomePage();
                    break;
                case 1:
                    if ((clsGlobal.CurrentUser.Permissions & 1) != 1)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 2:
                    if ((clsGlobal.CurrentUser.Permissions & 2) != 2)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 3:
                    if ((clsGlobal.CurrentUser.Permissions & 4) != 4)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 4:
                    if ((clsGlobal.CurrentUser.Permissions & 8) != 8)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 5:
                    if ((clsGlobal.CurrentUser.Permissions & 16) != 16)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 6:
                    if ((clsGlobal.CurrentUser.Permissions & 32) != 32)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 7:
                    if ((clsGlobal.CurrentUser.Permissions & 64) != 64)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 8:
                    if ((clsGlobal.CurrentUser.Permissions & 128) != 128)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 9:
                    if ((clsGlobal.CurrentUser.Permissions & 256) != 256)
                    {
                        MessageBox.Show("You dont have permission to enter this section conact the admin", "UnAuthorized", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                    break;
                case 11:
                    e.Cancel = true;
                    clsGlobal.CurrentUser = null;
                    _frmLogin.Show();
                    this.Close();
                    break;
            }
        }

        private void MouseHover_Leave_Buttons() 
        {
            foreach (TabPage item in hopeTabPage1.Controls)
            {
                foreach (Control ctrl in item.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.MouseHover += clsUIActions.Button_MouseHover;
                        btn.MouseLeave += clsUIActions.Button_MouseLeave;
                    }
                }
            }
        }

        private void OpenForm<T>() where T : Form, new()
        {
            using (T frm = new T())
            {
                frm.ShowDialog();
            }
        }

        private void btnPeopleList_Click(object sender, EventArgs e) => OpenForm<frmPeopleList>();

        private void btnAddNewPerson_Click(object sender, EventArgs e) => OpenForm<frmAddUpdatePerson>();

        private void btnPatientsList_Click(object sender, EventArgs e) => OpenForm<frmPatientsList>();

        private void btnAddNewPatient_Click(object sender, EventArgs e) => OpenForm<frmAddUpdatePatient>();

        private void btnDoctorsList_Click(object sender, EventArgs e) => OpenForm<frmDoctorsList>();

        private void btnAddNewDoctor_Click(object sender, EventArgs e) => OpenForm<frmAddUpdateDoctor>();

        private void btnAppointmentsList_Click(object sender, EventArgs e) => OpenForm<frmAppointmentsList>();

        private void btnAddNewAppointment_Click(object sender, EventArgs e) => OpenForm<frmAddUpdateAppointment>();

        private void btnExaminationsList_Click(object sender, EventArgs e) => OpenForm<frmExaminationsList>();

        private void btnAddNewExamination_Click(object sender, EventArgs e) => OpenForm<frmAddExamination>();

        private void btnPrescriptionList_Click(object sender, EventArgs e) => OpenForm<frmPrescriptionsList>();

        private void btnAddNewPrescription_Click(object sender, EventArgs e) => OpenForm<frmAddPrescription>();

        private void btnAnalysesList_Click(object sender, EventArgs e) => OpenForm<frmAnalysesList>();

        private void btnAddNewAnalysis_Click(object sender, EventArgs e) => OpenForm<frmAddAnalysis>();

        private void btnInvoicesList_Click(object sender, EventArgs e) => OpenForm<frmInvoicesList>();

        private void btnAddNewInvoice_Click(object sender, EventArgs e) => OpenForm<frmAddInvoice>();

        private void btnUsersList_Click(object sender, EventArgs e) => OpenForm<frmUsersList>();

        private void btnAddNewUser_Click(object sender, EventArgs e) => OpenForm<frmAddUpdateUser>();
    }
}
