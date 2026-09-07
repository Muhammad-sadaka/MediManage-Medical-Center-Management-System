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
    public partial class ctrlPersonInfoSummary : UserControl
    {
        clsPerson Person = new clsPerson();

        public ctrlPersonInfoSummary()
        {
            InitializeComponent();
        }

        public void LoadPersonInfoData(int PersonID)
        {
            if (!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Person = clsPerson.Find(PersonID);
            LoadData();



        }

        public void LoadPersonInfoData(string NationalNo)
        {
            if (!clsPerson.IsExist(NationalNo))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Person = clsPerson.Find(NationalNo);
            LoadData();

        }

       
        void LoadData()
        {
            lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblDateOfBirth.Text = Person.DateOfBirth.ToString();
            lblPhone.Text = Person.Phone;

            klblMoreInfo.Enabled = true;
        }

        private void klblMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Person.PersonID.Value);
            frm.ShowDialog();
        }
    }
}
