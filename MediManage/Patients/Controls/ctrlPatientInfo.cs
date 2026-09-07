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
    public partial class ctrlPatientInfo : UserControl
    {
        clsPatient Patient = new clsPatient();

        public ctrlPatientInfo()
        {
            InitializeComponent();
        }

        public void LoadPatientInfoData(int PersonId)
        {
            if (!clsPatient.IsExist(PersonId))
            {
                MessageBox.Show("Patient Did not Found");
                return;
            }

            Patient = clsPatient.Find(PersonId);

            lblSensitivity.Text = Patient.Sensitivity;
            lblChronicDiseases.Text = Patient.ChronicDiseases;
            lblJoinDate.Text = Patient.JoinDate.ToString();
            lblStatus.Text = Patient.PatientCaseInfo.PatientCaseName;

            klblPersonalInfo.Enabled = true;
        }

        private void klblPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Patient.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
