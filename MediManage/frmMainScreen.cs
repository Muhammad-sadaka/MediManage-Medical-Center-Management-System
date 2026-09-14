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
            lblTodayRevenue.Text = "Today Revenue = $"; //+
            DGVTodayAppointments.DataSource = clsAppointment.GetTodayAppointments();
            lblTodayAppointments.Text = "Today Appointments = " + DGVTodayAppointments.RowCount.ToString();

            MouseHover_Leave_Buttons();
        }

        private void hopeTabPage1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 11)
            {
                e.Cancel = true;
                clsGlobal.CurrentUser = null;
                _frmLogin.Show();
                this.Close();
            }
            else if (e.TabPageIndex == 0)
            {
                LoadHomePage();
            }
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                btn.ForeColor = Color.Red;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control btn)
            {
                btn.ForeColor = Color.Black;
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
                        btn.MouseHover += Button_MouseHover;
                        btn.MouseLeave += Button_MouseLeave;
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
