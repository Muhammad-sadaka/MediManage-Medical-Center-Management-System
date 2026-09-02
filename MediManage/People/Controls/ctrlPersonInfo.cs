using MediManage.Properties;
using MediManage_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class ctrlPersonInfo : UserControl
    {
        clsPerson Person = new clsPerson();

        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadPersonInfoData(int PersonID)
        {
            if(!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show("Person Did not Found");
                return;
            }

            Person = clsPerson.Find(PersonID);

            lblFullName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblNationalNo.Text = Person.NationalNo;
            lblDateOfBirth.Text = Person.DateOfBirth.ToString();

            if (Person.Gender == "0")
                lblGender.Text = "Male";
            else
                lblGender.Text = "FeMale";

            lblPhone.Text = Person.Phone;
            lblEmail.Text = Person.Email;
            lblCountry.Text = clsCountry.Find(Person.CountryId).CountryName.Trim();
            lblBloodType.Text = clsBloodType.Find(Person.BloodTypeID).BloodTypeSymbol;
            lblMaritalStatus.Text = clsMaritalStatus.Find(Person.MaritalStatusID).MaritalStatusName;
            lblAddress.Text = Person.Address;

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            string ImagePath = Person.Image;
            if (!string.IsNullOrEmpty( ImagePath))
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
            else
                pbPersonImage.Image = Resources.Person32;

        }

    }
}
