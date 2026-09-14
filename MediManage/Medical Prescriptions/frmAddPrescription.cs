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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MediManage
{
    public partial class frmAddPrescription : Form
    {
        List<clsMedicineRecipeListDTO> MedicinesRecipesList = new List<clsMedicineRecipeListDTO>(); 
        List<clsMedicineRecipeDTO> MedicinesRecipes = new List<clsMedicineRecipeDTO>(); 

        clsMedicalPrescription Prescription = new clsMedicalPrescription();
        frmAddMedicine frm = new frmAddMedicine();

        public frmAddPrescription()
        {
            InitializeComponent();
        }

        private void frmAddPrescription_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            RefreshMedicinesRecipesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            frm = new frmAddMedicine();
            frm.DataBack += Form2_DataBack;
            frm.ShowDialog();
            RefreshMedicinesRecipesList();
        }

        private void Form2_DataBack(object sender, clsMedicineRecipeDTO MedicineRecipe, clsMedicineRecipeListDTO MedicinesRecipeList)
        {
            this.MedicinesRecipesList.Add(MedicinesRecipeList);
            this.MedicinesRecipes.Add(MedicineRecipe);
        }

        private void SetupDataGridViewColumns()
        {
            DGVMedicinesRecipes.AutoGenerateColumns = false;
            DGVMedicinesRecipes.Columns.Clear();

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineName", HeaderText = "Medicine", Name = "MedicineName" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dose", HeaderText = "Dosage", Name = "Dose" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Repetition", HeaderText = "Frequency", Name = "Repetition" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Duration", HeaderText = "Duration", Name = "Duration" });

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Remove(X)";
            btnDelete.Text = "X";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVMedicinesRecipes.Columns.Add(btnDelete);
        }

        private void RefreshMedicinesRecipesList()
        {
            DGVMedicinesRecipes.DataSource = MedicinesRecipesList.Select(m => new
            {
                m.MedicineName,
                m.Dose,
                m.Repetition,
                m.Duration
            }).ToList(); 
            lblTotalRecords.Text = $"Total Medicines: {DGVMedicinesRecipes.RowCount} records";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Prescription.DetectionID = Convert.ToInt32(numericExaminationID.Value);
            if (clsDetection.IsExist(Prescription.DetectionID))
            {
                ctrlExaminationInfoSummary1.LoadExaminationInfoData(Prescription.DetectionID.Value);
            }
            else
            {
                Prescription.DetectionID = null;
                MessageBox.Show("No Examination Found With This ID", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Prescription.DetectionID.HasValue)
            {
                MessageBox.Show("Search about Examination First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MedicinesRecipes.Count < 1)
            {
                MessageBox.Show("You should add at least one Medicine Recipe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Prescription.PrescriptionDate = DateTime.Now;
            Prescription.Notes = tbGeneralNotes.Text.Trim();

            if (Prescription.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            foreach (clsMedicineRecipeDTO MedicineRecipe in MedicinesRecipes)
            {
                MedicineRecipe.MedicalPrescriptionID = Prescription.MedicalPrescriptionID;
                clsMedicineRecipe medicineRecipe = new clsMedicineRecipe(MedicineRecipe);    //check if it is add or update
                medicineRecipe.Save();
            }
        }

        private void DGVMedicinesRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string MedicineRecipeName = DGVMedicinesRecipes.Rows[e.RowIndex].Cells["MedicineName"].Value.ToString();

            if (DGVMedicinesRecipes.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                 if (MedicinesRecipesList.RemoveAll(m => m.MedicineName == MedicineRecipeName) > 0
                         && MedicinesRecipes.RemoveAll(m => m.MedicineID == frm.Medicines.Where(k => k.MedicineName == MedicineRecipeName).Select(k => k.MedicineID).First()) > 0)
                 {
                     MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     RefreshMedicinesRecipesList();
                 }
                 else
                 {
                     MessageBox.Show("Delete failed for This Medicines Recipes .", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                
            }
        }
    }
}
