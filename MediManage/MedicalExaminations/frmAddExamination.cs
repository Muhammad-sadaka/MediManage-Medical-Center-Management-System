using MediManage.Global_Classes;
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
    public partial class frmAddExamination : Form
    {
        clsDetection Examination = new clsDetection();

        public frmAddExamination()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Examination.AppointmentID = Convert.ToInt32(numericAppointmentID.Value);
            if (clsAppointment.IsExist(Examination.AppointmentID))
            {
                if (clsAppointment.IsCompleted(Examination.AppointmentID))
                {
                    MessageBox.Show("This Appointment already has a Medical Examination", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (clsAppointment.IsCanceledorAbsent(Examination.AppointmentID))
                {
                    MessageBox.Show("Can't add an Examination of this appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ctrlAppointmentInfoSummary1.LoadAppointmentInfoData(Examination.AppointmentID.Value);
            }
            else
            {
                Examination.AppointmentID = null;
                MessageBox.Show("No Appointment Found With This ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Examination.AppointmentID == null)
            {
                MessageBox.Show("Search about Appointment First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Examination.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Examination.Symproms = tbSymptoms.Text.Trim();
            Examination.Diagnosis = tbDiagosis.Text.Trim();
            Examination.Temperature      = Convert.ToByte(numericTemperature.Value);
            Examination.Wight = Convert.ToByte(tbWeight.Text.Trim());
            Examination.BloodPressure = Convert.ToByte(tbBloodPressure.Text.Trim());
            Examination.HeartRate        = Convert.ToByte(tbHeartRate.Text.Trim());
            Examination.Notes            = tbNotes.Text.Trim();
            Examination.DetectionDate = DateTime.Now;

            if (Examination.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        

        private void frmAddExamination_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.groupBox1.Controls)
            {
                if (ctrl is TextBox && ctrl != tbNotes)
                {
                    ctrl.Validating += clsValidation.ValidateEmptyTextBox;
                }
            }
            tbWeight.KeyPress += clsValidation.ValidateNumbersOnly;
            tbHeartRate.KeyPress += clsValidation.ValidateNumbersOnly;
            tbBloodPressure.KeyPress += clsValidation.ValidateNumbersOnly;
        }
    }
}
