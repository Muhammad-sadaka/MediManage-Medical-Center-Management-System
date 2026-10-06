using MediManage.Global_Classes;
using MediManage_Business;
using MediManage_DataAccess;
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
    public partial class frmAddMedicine : Form
    {
        public delegate void DataBackEventHandler(object sender, clsMedicineRecipeDTO medicineRecipe, clsMedicineRecipeListDTO medicineRecipeList);

        public event DataBackEventHandler DataBack;

        public List<clsMedicineDTO> Medicines { get; set; }

        public frmAddMedicine()
        {
            InitializeComponent();
        }

        private void frmAddMedicine_Load(object sender, EventArgs e)
        {
            Medicines = clsMedicine.GetAllMedicines();
            cbMedicineName.DataSource = Medicines;
            cbMedicineName.DisplayMember = "MedicineName";

            tbDosage.Validating += clsValidation.ValidateEmptyTextBox;
            tbDuration.Validating += clsValidation.ValidateEmptyTextBox;
            tbFrequency.Validating += clsValidation.ValidateEmptyTextBox;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMedicineRecipeListDTO medicineRecipeList = new clsMedicineRecipeListDTO
            (
                cbMedicineName.Text.Trim(),
                tbDosage.Text.Trim(),
                tbFrequency.Text.Trim(),
                tbDuration.Text.Trim(),
                tbNotes.Text.Trim()
            );

            clsMedicineRecipeDTO medicineRecipe = new clsMedicineRecipeDTO
           (
                null,
               medicineRecipeList.Duration,
               medicineRecipeList.Repetition,
               medicineRecipeList.Dose,
               null,
               tbNotes.Text.Trim(),
               cbMedicineName.SelectedIndex + 1
           );

            DataBack?.Invoke(this, medicineRecipe,medicineRecipeList);


            this.Close();
        }


    }
}
