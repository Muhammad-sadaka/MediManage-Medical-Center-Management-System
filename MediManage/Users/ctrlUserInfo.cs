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
    public partial class ctrlUserInfo : UserControl
    {
        clsUser User = new clsUser();
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        public void LoadUserInfoData(int UserID)
        {
            if (!clsUser.IsExist(UserID))
            {
                MessageBox.Show("User Did not Found");
                return;
            }

            User = clsUser.Find(UserID);

            lblFullName.Text = User.PersonInfo.FullName;
            lblUserName.Text = User.UserName;
            lblPermissions.Text = LoadPermissions();
            lblCreatedByUser.Text = clsUser.Find(User.CreatedByUser).UserName;
            if (User.IsActive.Value) lblIsActive.Text = "Yes"; else lblIsActive.Text = "No";

            klblPersonalInfo.Enabled = true;
        }

        private void klblPersonalInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(User.PersonID.Value);
            frm.ShowDialog();
        }

        string LoadPermissions()
        {
            string Permissions = "";

            if ((User.Permissions & 1) == 1)
            { 
                if (User.Permissions > 1)
                    Permissions += "Manage Analyses - ";
                else
                    Permissions += "Manage Analyses";
            }
            if ((User.Permissions & 2) == 2)
            {
                if (User.Permissions > 2)
                    Permissions += "Manage Appointments - ";
                else
                    Permissions += "Manage Appointments";
            }
   
            if ((User.Permissions & 4) == 4)
            {
                if (User.Permissions > 4)
                    Permissions += "Manage Doctors - ";
                else
                    Permissions += "Manage Doctors";
            }

            if ((User.Permissions & 8) == 8)
            {
                if (User.Permissions > 8)
                    Permissions += "\nManage Examinations - ";
                else
                    Permissions += "\nManage Examinations";
            }
            if ((User.Permissions & 16) == 16)
            {
                if (User.Permissions > 16)
                    Permissions += "Manage Invoices & Payments - ";
                else
                    Permissions += "Manage Invoices & Payments";
            }
            if ((User.Permissions & 32) == 32)
            {
                if (User.Permissions > 32)
                    Permissions += "Manage Patients - ";
                else
                    Permissions += "Manage Patients";
            }
            if ((User.Permissions & 64) == 64)
            {
                if (User.Permissions > 64)
                    Permissions += "\nManage People - ";
                else
                    Permissions += "\nManage People";
            }

            if ((User.Permissions & 128) == 128)
            {
                if (User.Permissions > 128)
                    Permissions += "Manage Prescriptions - ";
                else
                    Permissions += "Manage Prescriptions";
            }
            if ((User.Permissions & 256) == 256)
                Permissions += "Manage Users";


            return Permissions;
        }
    }
}
