using MediManage.Properties;
using MediManage_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class frmAddUpdatePerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsPerson person = new clsPerson();

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            person.PersonID = PersonID;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _HandlePersonImage()
        {
            if (person.Image != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrWhiteSpace(person.Image))
                {
                    try
                    {
                        File.Delete(person.Image);
                    }
                    catch (IOException ex)
                    {
                        MediManage_DataAccess.clsDataAccessSettings.EventLogCreate();
                        EventLog.WriteEntry(MediManage_DataAccess.clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!_HandlePersonImage())
                return;

            person.FirstName = tbFirstName.Text.Trim();
            person.SecondName = tbSecondName.Text.Trim();
            person.ThirdName = tbThirdName.Text.Trim();
            person.LastName = tbLastName.Text.Trim();
            person.NationalNo = tbNationalNo.Text.Trim();
            person.DateOfBirth = dateTimePicker1.Value;
            if (rbMale.Checked)
                person.Gender = "0";
            else
                person.Gender = "1";
            person.Phone = tbPhone.Text.Trim();
            person.Email = tbEmail.Text.Trim();
            person.Address = tbAddress.Text.Trim();
            person.BloodTypeID = cbBloodType.SelectedIndex + 1;
            person.MaritalStatusID = cbMaritalStatus.SelectedIndex + 1;
            person.CountryId = cbCountries.SelectedIndex + 1;
            person.Image = pbPersonImage.ImageLocation;

            if (person.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person                        ";
                MessageBox.Show("Data Saved Successfully.", "Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _SelectDateTime()
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Today.AddYears(-100);
            dateTimePicker1.CustomFormat = "yyyy-MM-dd   hh:mm tt";
        }

        private void _ResestDefualtValues()
        {
            cbBloodType.DataSource = clsBloodType.GetAllBloodTypes();
            cbBloodType.DisplayMember = "BloodTypeSymbol";

            cbMaritalStatus.DataSource = clsMaritalStatus.GetAllMaritalStatuses();
            cbMaritalStatus.DisplayMember = "MaritalStatusName";

            cbCountries.DataSource = clsCountry.GetAllCountries();
            cbCountries.DisplayMember = "CountryName";



            if (_Mode == enMode.AddNew)
            {
                person = new clsPerson();
                lblTitle.Text = "Add New Person                       ";
            }
            else
                lblTitle.Text = "Update Person                        ";

            _SelectDateTime();

            cbCountries.SelectedIndex = cbCountries.FindString("Syria");

            tbFirstName.Clear();
            tbSecondName.Clear();
            tbThirdName.Clear();
            tbLastName.Clear();
            tbNationalNo.Clear();
            tbPhone.Clear();
            tbEmail.Clear();
            tbAddress.Clear();
            cbBloodType.SelectedIndex = 0;
            cbMaritalStatus.SelectedIndex = 0;

            rbMale.Checked = true;
        }

        private void _LoadData()
        {
            person = clsPerson.Find(person.PersonID);

            if (person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + person.PersonID);
                this.Close();
                return;
            }

             tbFirstName.Text = person.FirstName;
             tbSecondName.Text = person.SecondName;
             tbThirdName.Text = person.ThirdName;
             tbLastName.Text = person.LastName;
             tbNationalNo.Text = person.NationalNo;
             dateTimePicker1.Value = person.DateOfBirth.Value;
             if (person.Gender == "0")
                 rbMale.Checked = true;
             else
                rbFemale.Checked = true;
            tbPhone.Text =person.Phone;
            tbEmail.Text=person.Email;
            tbAddress.Text = person.Address;
            cbBloodType.SelectedIndex = person.BloodTypeID.Value -1;
            cbMaritalStatus.SelectedIndex = person.MaritalStatusID.Value - 1;
            cbCountries.SelectedIndex = person.CountryId.Value - 1;

            if (!string.IsNullOrEmpty(person.Image))   pbPersonImage.ImageLocation = person.Image;
            

            klblRemove.Visible = (pbPersonImage.ImageLocation != null);
            klblChangeImage.Visible = klblRemove.Visible;
            klblClicktoAddPhoto.Visible = !klblChangeImage.Visible;
        }

        void SetImage()
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                klblClicktoAddPhoto.Visible = false;
                klblRemove.Visible = true;
                klblChangeImage.Visible = true;
            }
        }

        private void klblChangeImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetImage();
        }
        private void klblClicktoAddPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetImage();
        }

        private void klblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            klblRemove.Visible = false;
            klblChangeImage.Visible = false;
            klblClicktoAddPhoto.Visible = true;
            pbPersonImage.Image = Resources.Person32;
        }


        //// still in testing phase, not used yet
        //private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        //{

        //    // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
        //    TextBox Temp = ((TextBox)sender);
        //    if (string.IsNullOrEmpty(Temp.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(Temp, "This field is required!");
        //    }
        //    else
        //    {
        //        //e.Cancel = false;
        //        errorProvider1.SetError(Temp, null);
        //    }

        //}


        //// still in testing phase, not used yet
        ///
        //private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        //{
        //    TextBox temp = (TextBox)sender;

        //    if (string.IsNullOrWhiteSpace(temp.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        temp.Focus();
        //        errorProvider1.SetError(temp, $"{temp.Tag ?? "This field"} should have a value!");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(temp, "");
        //    }
        //}

        //private void Form_Load(object sender, EventArgs e)
        //{
        //    tBFirstName.Validating += ValidateEmptyTextBox;
        //    tBSecondName.Validating += ValidateEmptyTextBox;
        //    tBLastName.Validating += ValidateEmptyTextBox;
        //    tBAddress.Validating += ValidateEmptyTextBox;
        //    tBPhone.Validating += ValidateEmptyTextBox;
        //}

        //private void tBEmail_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tBEmail.Text.Trim()))
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(tBEmail, "");
        //        return;
        //    }

        //    if (!clsValidation.ValidateEmail(tBEmail.Text))
        //    {
        //        e.Cancel = true;
        //        tBEmail.Focus();
        //        errorProvider1.SetError(tBEmail, "This is a wrong email format, it should end with (@gmail.com).");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(tBEmail, "");
        //    }
        //}

        //private void tBNationalNo_Validating_1(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tBNationalNo.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        tBNationalNo.Focus();
        //        errorProvider1.SetError(tBNationalNo, "NationalNo should have a value");
        //    }
        //    else if (tBNationalNo.Text.Trim() != _Person.NationalNo && clsPeople.isPersonExist(tBNationalNo.Text.Trim()))
        //    {
        //        e.Cancel = true;
        //        tBNationalNo.Focus();
        //        errorProvider1.SetError(tBNationalNo, "This NationalNo already exists");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(tBNationalNo, "");
        //    }
        //}

        //private void tBPhone_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }
        //}

    }
}
