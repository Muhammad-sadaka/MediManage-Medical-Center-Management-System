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

        private void btnAddNewPerson_MouseHover(object sender, EventArgs e)
        {
            btnAddNewPerson.ForeColor = Color.Red;
        }

        private void btnAddNewPerson_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewPerson.ForeColor = Color.Black;
        }

        private void btnPeopleList_MouseHover(object sender, EventArgs e)
        {
            btnPeopleList.ForeColor = Color.Red;
        }

        private void btnPeopleList_MouseLeave(object sender, EventArgs e)
        {
            btnPeopleList.ForeColor = Color.Black;
        }

        private void btnPeopleList_Click(object sender, EventArgs e)
        {
            frmPeopleList frm = new frmPeopleList();
            frm.ShowDialog();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void btnPatientsList_Click(object sender, EventArgs e)
        {
            frmPatientsList frm = new frmPatientsList();
            frm.ShowDialog();
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient frm = new frmAddUpdatePatient();
            frm.ShowDialog();
        }

        private void btnDoctorsList_Click(object sender, EventArgs e)
        {
            frmDoctorsList frm = new frmDoctorsList();
            frm.ShowDialog();
        }

        private void btnAddNewDoctor_Click(object sender, EventArgs e)
        {
            frmAddUpdateDoctor frm = new frmAddUpdateDoctor();
            frm.ShowDialog();
        }

        private void btnAppointmentsList_Click(object sender, EventArgs e)
        {
            frmAppointmentsList frm = new frmAppointmentsList();
            frm.ShowDialog();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmAddUpdateAppointment frm = new frmAddUpdateAppointment();
            frm.ShowDialog();
        }

        private void btnPatientsList_MouseHover(object sender, EventArgs e)
        {
            btnPatientsList.ForeColor = Color.Red;
        }

        private void btnPatientsList_MouseLeave(object sender, EventArgs e)
        {
            btnPatientsList.ForeColor = Color.Black;
        }

        private void btnAddNewPatient_MouseHover(object sender, EventArgs e)
        {
            btnAddNewPatient.ForeColor = Color.Red;
        }

        private void btnAddNewPatient_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewPatient.ForeColor = Color.Black;
        }

        private void btnDoctorsList_MouseHover(object sender, EventArgs e)
        {
            btnDoctorsList.ForeColor = Color.Red;
        }

        private void btnDoctorsList_MouseLeave(object sender, EventArgs e)
        {
            btnDoctorsList.ForeColor = Color.Black;
        }

        private void btnAddNewDoctor_MouseHover(object sender, EventArgs e)
        {
            btnAddNewDoctor.ForeColor = Color.Red;
        }

        private void btnAddNewDoctor_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewDoctor.ForeColor = Color.Black;
        }

        private void btnAppointmentsList_MouseHover(object sender, EventArgs e)
        {
            btnAppointmentsList.ForeColor = Color.Red;
        }

        private void btnAppointmentsList_MouseLeave(object sender, EventArgs e)
        {
            btnAppointmentsList.ForeColor = Color.Black;
        }

        private void btnAddNewAppointment_MouseHover(object sender, EventArgs e)
        {
            btnAddNewAppointment.ForeColor = Color.Red;
        }

        private void btnAddNewAppointment_MouseLeave(object sender, EventArgs e)
        {
            btnAddNewAppointment.ForeColor = Color.Black;
        }

        private void btnUsersList_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void btnExaminationsList_Click(object sender, EventArgs e)
        {
            frmExaminationsList frm = new frmExaminationsList();
            frm.ShowDialog();
        }

        private void btnAddNewExamination_Click(object sender, EventArgs e)
        {
            frmAddExamination frm = new frmAddExamination();
            frm.ShowDialog();
        }

        private void btnPrescriptionList_Click(object sender, EventArgs e)
        {
            frmPrescriptionsList frm = new frmPrescriptionsList();
            frm.ShowDialog();
        }

        private void btnAddNewPrescription_Click(object sender, EventArgs e)
        {
            frmAddPrescription frm = new frmAddPrescription();
            frm.ShowDialog();
        }

        private void btnAnalysesList_Click(object sender, EventArgs e)
        {
            frmAnalysesList frm = new frmAnalysesList();
            frm.ShowDialog();
        }

        private void btnAddNewAnalysis_Click(object sender, EventArgs e)
        {
            frmAddAnalysis frm = new frmAddAnalysis();
            frm.ShowDialog();
        }

        private void btnInvoicesList_Click(object sender, EventArgs e)
        {
            frmInvoicesList frm = new frmInvoicesList();
            frm.ShowDialog();
        }

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            frmAddInvoice frm = new frmAddInvoice();
            frm.ShowDialog();
        }




        //// still need to be tested and implemented
        ///

        //private void Button_MouseHover(object sender, EventArgs e)
        //{
        //    if (sender is Control btn)
        //    {
        //        btn.ForeColor = Color.Red;
        //    }
        //}

        //private void Button_MouseLeave(object sender, EventArgs e)
        //{
        //    if (sender is Control btn)
        //    {
        //        btn.ForeColor = Color.Black;
        //    }
        //}


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    foreach (Control ctrl in this.Controls)
        //    {
        //        if (ctrl is Button btn)
        //        {
        //            btn.MouseHover += Button_MouseHover;
        //            btn.MouseLeave += Button_MouseLeave;
        //        }
        //    }
        //}

        //// دالة عامة لفتح أي Form باستخدام ShowDialog
        //private void OpenForm<T>() where T : Form, new()
        //{
        //    using (T frm = new T())
        //    {
        //        frm.ShowDialog();
        //    }
        //}

        //private void btnPeopleList_Click(object sender, EventArgs e) => OpenForm<frmPeopleList>();

        //private void btnAddNewPerson_Click(object sender, EventArgs e) => OpenForm<frmAddUpdatePerson>();

        //private void btnPatientsList_Click(object sender, EventArgs e) => OpenForm<frmPatientsList>();

        //private void btnAddNewPatient_Click(object sender, EventArgs e) => OpenForm<frmAddUpdatePatient>();

        //private void btnDoctorsList_Click(object sender, EventArgs e) => OpenForm<frmDoctorsList>();

        //private void btnAddNewDoctor_Click(object sender, EventArgs e) => OpenForm<frmAddUpdateDoctor>();

        //private void btnAppointmentsList_Click(object sender, EventArgs e) => OpenForm<frmAppointmentsList>();

        //private void btnAddNewAppointment_Click(object sender, EventArgs e) => OpenForm<frmAddUpdateAppointment>();

    }
}
