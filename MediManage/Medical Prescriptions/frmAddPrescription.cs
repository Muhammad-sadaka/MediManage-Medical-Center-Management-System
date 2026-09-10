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
            frmAddMedicine frm = new frmAddMedicine();
            frm.DataBack += Form2_DataBack; // Subscribe to the event
            frm.ShowDialog();
            RefreshMedicinesRecipesList();
        }

        private void Form2_DataBack(object sender, clsMedicineRecipeDTO MedicineRecipe, clsMedicineRecipeListDTO MedicinesRecipeList)
        {
            // Handle the data received from Form2
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

            int ID = Convert.ToInt32(numericExaminationID.Value);
            if (clsDetection.IsExist(ID))
            {
                ctrlExaminationInfoSummary1.LoadExaminationInfoData(ID);
            }
            else
            {
                MessageBox.Show("No Examination Found With This ID");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if()
            //{
            //    MessageBox.Show("Search about Appointment First");
            //    return;
            //}


            if (MedicinesRecipes.Count < 1)
            {
                MessageBox.Show("You should add at least one Medicine Recipe");
                return;
            }

            Prescription.DetectionID = Convert.ToInt32(numericExaminationID.Value);
            Prescription.Notes = tbGeneralNotes.Text.Trim();


            if (Prescription.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            foreach (clsMedicineRecipeDTO MedicineRecipe in MedicinesRecipes)
            {
                MedicineRecipe.MedicalPrescriptionID = Prescription.MedicalPrescriptionID;
            }

            foreach (clsMedicineRecipeDTO MedicineRecipe in MedicinesRecipes)
            {
                clsMedicineRecipe medicineRecipe = new clsMedicineRecipe(MedicineRecipe);
                medicineRecipe.Save();
            }
        }


    }
}
