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
    public partial class ctrlDoctorInfo : UserControl
    {
        clsDoctor Doctor = new clsDoctor();

        public ctrlDoctorInfo()
        {
            InitializeComponent();
        }

        public void LoadDoctorInfoData(int DoctorID)
        {
            if (!clsDoctor.IsExist(DoctorID))
            {
                MessageBox.Show("Doctor Did not Found");
                return;
            }

            Doctor = clsDoctor.Find(DoctorID);

            lblFullName.Text = Doctor.PersonInfo.FullName;
            lblSpecialty.Text = Doctor.SpecialtyInfo.SpecialtyName;
            lblFees.Text = Doctor.SpecialtyInfo.Fees.ToString();
            lblLicenseNo.Text = Doctor.LicenseNo;
            lblYearsOfExperience.Text = Doctor.YearsOfExperience.ToString();
            lblQualification.Text = Doctor.Qualification;
            if (Doctor.IsActive.Value) lblIsActive.Text = "Yes"; else lblIsActive.Text = "No";

            klblPersonalInfo.Enabled = true;
        }


        private void klblPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Doctor.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
