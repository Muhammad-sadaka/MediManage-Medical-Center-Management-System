using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{


    public class clsMedicineRecipe
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsMedicineRecipeDTO DTO
        {
            get
            {
                return new clsMedicineRecipeDTO
                (
                    this.MedicineRecipeID,
                    this.Duration,
                    this.Repetition,
                    this.Dose,
                    this.MedicalPrescriptionID,
                    this.Notes,
                    this.MedicineID
                );
            }
        }

        public int? MedicineRecipeID { get; set; }
        public int? MedicineID { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }
        public int? MedicalPrescriptionID { get; set; }
        public string Notes { get; set; }
        public clsMedicine MedicineInfo { get; set; }

        public clsMedicineRecipe()
        {
            this.MedicineRecipeID =null;
            this.Duration = null;
            this.Repetition = null;
            this.Dose =  null;
            this.MedicalPrescriptionID = null;
            this.Notes = null;
            this.MedicineID = null;
            this.MedicineInfo = null;
            this.Mode = enMode.AddNew;

        }

        public clsMedicineRecipe(clsMedicineRecipeDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MedicineRecipeID = dto.MedicineRecipeID;
            this.Duration = dto.Duration;
            this.Repetition = dto.Repetition;
            this.Dose = dto.Dose;
            this.MedicalPrescriptionID = dto.MedicalPrescriptionID;
            this.Notes = dto.Notes;
            this.MedicineID = dto.MedicineID;
            this.MedicineInfo = clsMedicine.Find(MedicineID);
            this.Mode = cMode;

        }

        private bool _AddNewMedicineRecipe()
        {
            this.MedicineRecipeID = clsMedicineRecipeDataAccess.AddNewMedicineRecipe(this.DTO);
            return (this.MedicineRecipeID.HasValue);
        }

        private bool _UpdateMedicineRecipe()
        {
            return clsMedicineRecipeDataAccess.UpdateMedicineRecipe(this.DTO);
        }

        public static clsMedicineRecipe Find(int? ID)
        {
            clsMedicineRecipeDTO dto = clsMedicineRecipeDataAccess.GetMedicineRecipeInfoByID(ID);

            if (dto != null)
                return new clsMedicineRecipe(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMedicineRecipeListDTO> GetAllMedicinesRecipes(int? MedicalPrescriptionID)
        {
            return clsMedicineRecipeDataAccess.GetAllMedicinesRecipes(MedicalPrescriptionID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicineRecipe())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMedicineRecipe();
            }

            return false;
        }

        public static bool DeleteMedicine(int? ID)
        {
            return clsMedicineRecipeDataAccess.DeleteMedicineRecipe(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMedicineRecipeDataAccess.IsMedicineRecipeExist(ID);
        }
    }
}