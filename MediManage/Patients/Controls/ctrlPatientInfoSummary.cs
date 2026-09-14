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
    public partial class ctrlPatientInfoSummary : UserControl
    {
        clsPatient Patient = new clsPatient();

        public int PatientID { get; set; }

        public ctrlPatientInfoSummary()
        {
            InitializeComponent();
        }

        public void LoadPatientInfoData(int PersonID)
        {
            if (!clsPatient.IsExist(PersonID))
            {
                MessageBox.Show("Patient Did not Found");
                return;
            }

            Patient = clsPatient.Find(PersonID);

            _LoadData();

        }

        public void LoadPatientInfoData(string NationalNo)
        {
            if (!clsPatient.IsExist(NationalNo))
            {
                MessageBox.Show("Patient Did not Found");
                return;
            }

            Patient = clsPatient.Find(NationalNo);
            PatientID = Patient.PatientID.Value;

            _LoadData();

        }

        void _LoadData()
        {

            lblPatientName.Text = Patient.PersonInfo.FullName;
            lblPhone.Text = Patient.PersonInfo.Phone;

            klblMoreInfo.Enabled = true;
        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPatientDetails frm = new frmPatientDetails(Patient.PatientID.Value);
            frm.ShowDialog();
        }
    }
}
