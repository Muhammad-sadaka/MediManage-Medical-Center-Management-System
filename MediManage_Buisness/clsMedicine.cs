using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{


    public class clsMedicine
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsMedicineDTO DTO
        {
            get
            {
                return new clsMedicineDTO
                (
                    this.MedicineID,
                    this.MedicineName,
                    this.Duration,
                    this.Repetition,
                    this.Dose,
                    this.MedicalPrescriptionID,
                    this.Notes
                );
            }
        }

        public int? MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }
        public int? MedicalPrescriptionID { get; set; }
        public string Notes { get; set; }

        public clsMedicine(clsMedicineDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MedicineID = dto.MedicineID;
            this.MedicineName = dto.MedicineName;
            this.Duration = dto.Duration;
            this.Repetition = dto.Repetition;
            this.Dose = dto.Dose;
            this.MedicalPrescriptionID = dto.MedicalPrescriptionID;
            this.Notes = dto.Notes;
            this.Mode = cMode;
        }

        private bool _AddNewMedicine()
        {
            this.MedicineID = clsMedicinesDataAccess.AddNewMedicine(this.DTO);
            return (this.MedicineID.HasValue);
        }

        private bool _UpdateMedicine()
        {
            return clsMedicinesDataAccess.UpdateMedicine(this.DTO);
        }

        public static clsMedicine Find(int? ID)
        {
            clsMedicineDTO dto = clsMedicinesDataAccess.GetMedicineInfoByID(ID);

            if (dto != null)
                return new clsMedicine(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMedicineDTO> GetAllMedicines()
        {
            return clsMedicinesDataAccess.GetAllMedicines();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicine())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMedicine();
            }

            return false;
        }

        public static bool DeleteMedicine(int? ID)
        {
            return clsMedicinesDataAccess.DeleteMedicine(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMedicinesDataAccess.IsMedicineExist(ID);
        }
    }
}