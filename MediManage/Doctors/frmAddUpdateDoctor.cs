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
    public partial class frmAddUpdateDoctor : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        clsPerson Person = new clsPerson();
        clsDoctor Doctor = new clsDoctor();


        public frmAddUpdateDoctor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateDoctor(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            Doctor.PersonID = PersonID;
        }

        private void frmAddUpdateDoctor_Load(object sender, EventArgs e)
        {
            _ResestDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResestDefualtValues()
        {
            cbPatientCase.DataSource = clsPatientCase.GetAllPatientCases();
            cbPatientCase.DisplayMember = "PatientCaseName";



            if (_Mode == enMode.AddNew)
            {
                Doctor = new clsDoctor();
                lblTitle.Text = "Add New Doctor                       ";
            }
            else
                lblTitle.Text = "Update Doctor                        ";


            cbPatientCase.SelectedIndex = 0;

            tbSensitivity.Text = "";
            tbChronicDiseases.Text = "";
            cbPatientCase.SelectedIndex = 0;

        }

        private void _LoadData()
        {
            Doctor = clsDoctor.Find(Doctor.PersonID);
            Person = clsPerson.Find(Doctor.PersonID);

            if (Doctor == null)
            {
                MessageBox.Show("This form will be closed because No Doctor with ID = " + Doctor.PersonID);
                this.Close();
                return;
            }

            gbSearch.Enabled = false;
            ctrlPersonInfoSummary1.LoadPersonInfoData(Doctor.PersonID.Value);

            //tbSensitivity.Text = Patient.Sensitivity;
            //tbChronicDiseases.Text = Patient.ChronicDiseases;
            //cbPatientCase.SelectedIndex = Patient.PatientCaseID.Value - 1;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPerson.IsExist(tbNationalNo.Text))
            {
                Person = clsPerson.Find(tbNationalNo.Text);
                ctrlPersonInfoSummary1.LoadPersonInfoData(Person.PersonID.Value);
            }
            else
            {
                MessageBox.Show("No Person Found With This National No");
            }

        }

        private void checkBox1_Paint(object sender, PaintEventArgs e)
        {
            // 1. مسح الرسمة الافتراضية الصغيرة للنظام
            e.Graphics.Clear(this.checkBox1.BackColor);

            // 2. تحديد حجم المربع الأبيض ليكون بحجم العنصر كاملاً (مثلاً 25x25)
            // قمنا بخصم 1 بكسل للحفاظ على الحدود نظيفة
            Rectangle rect = new Rectangle(0, 0, this.checkBox1.Width - 1, this.checkBox1.Height - 1);

            // 3. رسم خلفية المربع باللون الأبيض
            e.Graphics.FillRectangle(Brushes.White, rect);

            // 4. رسم حدود المربع (Border) باللون الرمادي أو الأزرق
            using (Pen pen = new Pen(Color.DarkGray, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // 5. إذا قام المستخدم بالضغط عليه واختياره (Checked)، ارسم علامة الصح بالداخل
            if (this.checkBox1.Checked)
            {
                using (Pen checkPen = new Pen(Color.DarkRed, 3)) // لون وحجم خط علامة الصح
                {
                    // رسم علامة الصح يدوياً لتناسب أي حجم تكبر إليه خانة الاختيار
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.25f, rect.Height * 0.5f, rect.Width * 0.45f, rect.Height * 0.75f);
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.45f, rect.Height * 0.75f, rect.Width * 0.85f, rect.Height * 0.25f);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Doctor == null)
            {
                MessageBox.Show("Search about Person First");
                return;
            }


            Doctor.PersonID = Person.PersonID;
            //Patient.Sensitivity = tbSensitivity.Text.Trim();
            //Patient.ChronicDiseases = tbChronicDiseases.Text.Trim();
            //Patient.JoinDate = DateTime.Now;

            //Patient.PatientCaseID = cbPatientCase.SelectedIndex + 1;

            if (Doctor.Save())
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Update Doctor                        ";
                MessageBox.Show("Data Saved Successfully.");

                // PersonIDDataBack?.Invoke(this, _PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }
    }
}
