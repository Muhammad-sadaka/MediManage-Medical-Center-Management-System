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
    public partial class ctrlPrescriptionInfo : UserControl
    {
        clsMedicalPrescription Prescription = new clsMedicalPrescription();
        public ctrlPrescriptionInfo()
        {
            InitializeComponent();
        }

        public void LoadPrescriptionInfoData(int? PrescriptionID)
        {
            if (!clsMedicalPrescription.IsExist(PrescriptionID))
            {
                MessageBox.Show("Prescription Did not Found");
                return;
            }

            Prescription = clsMedicalPrescription.Find(PrescriptionID);

            klblDoctorName.Text = Prescription.DetectionInfo.AppointmentInfo.DoctorInfo.PersonInfo.FullName;
            klblPatientName.Text = Prescription.DetectionInfo.AppointmentInfo.PatientInfo.PersonInfo.FullName;
            lblPrescriptionDate.Text = Prescription.PrescriptionDate.ToString();
            lblNotes.Text = Prescription.Notes;
            MedicinesList();

        }


        private void klblDoctorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Prescription.DetectionInfo.AppointmentInfo.DoctorInfo.PersonID.Value);
            frm.ShowDialog();
        }

        private void klblPatientName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(Prescription.DetectionInfo.AppointmentInfo.PatientInfo.PersonID.Value);
            frm.ShowDialog();
        }

        private void SetupDataGridViewColumns()
        {
            DGVMedicinesRecipes.AutoGenerateColumns = false;
            DGVMedicinesRecipes.Columns.Clear();

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MedicineName", HeaderText = "Medicine Name", Name = "MedicineName" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Duration", HeaderText = "Duration", Name = "Duration" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Repetition", HeaderText = "Frequency", Name = "Repetition" });
            
            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dose", HeaderText = "Dosage", Name = "Dose" });

            DGVMedicinesRecipes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "Notes", Name = "Notes" });

        }

        private void MedicinesList()
        {
            SetupDataGridViewColumns();

            var MedicinesRecipes = clsMedicineRecipe.GetAllMedicinesRecipes(Prescription.MedicalPrescriptionID);

            DGVMedicinesRecipes.DataSource = MedicinesRecipes.Select(m => new
            {
                m.MedicineName,
                m.Duration,
                m.Repetition,
                m.Dose,
                m.Notes
            }).ToList();
        }
    }
}
