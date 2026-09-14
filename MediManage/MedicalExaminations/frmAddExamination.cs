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
        int? AppointmentID;

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
            AppointmentID = Convert.ToInt32(numericAppointmentID.Value);
            if (clsAppointment.IsExist(AppointmentID))
            {
                ctrlAppointmentInfoSummary1.LoadAppointmentInfoData(AppointmentID.Value);
            }
            else
            {
                AppointmentID = null;
                MessageBox.Show("No Appointment Found With This ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AppointmentID == null)
            {
                MessageBox.Show("Search about Appointment First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
