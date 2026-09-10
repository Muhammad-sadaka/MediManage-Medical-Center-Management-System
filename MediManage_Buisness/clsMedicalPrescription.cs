using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsMedicalPrescription
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsMedicalPrescriptionDTO DTO
        {
            get
            {
                return new clsMedicalPrescriptionDTO
                (
                    this.MedicalPrescriptionID,
                    this.DetectionID,
                    this.Notes
                );
            }
        }

        public int? MedicalPrescriptionID { get; set; }
        public int? DetectionID { get; set; }
        public string Notes { get; set; }


        public clsMedicalPrescription()
        {
            this.MedicalPrescriptionID = null;
            this.DetectionID = null;
            this.Notes = null;
            this.Mode = enMode.AddNew;
        }

        public clsMedicalPrescription(clsMedicalPrescriptionDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MedicalPrescriptionID = dto.MedicalPrescriptionID;
            this.DetectionID = dto.DetectionID;
            this.Notes = dto.Notes;
            this.Mode = cMode;
        }

        private bool _AddNewMedicalPrescription()
        {
            this.MedicalPrescriptionID = clsMedicalPrescriptionsDataAccess.AddNewMedicalPrescription(this.DTO);
            return (this.MedicalPrescriptionID.HasValue);
        }

        private bool _UpdateMedicalPrescription()
        {
            return clsMedicalPrescriptionsDataAccess.UpdateMedicalPrescription(this.DTO);
        }

        public static clsMedicalPrescription Find(int? ID)
        {
            clsMedicalPrescriptionDTO dto = clsMedicalPrescriptionsDataAccess.GetMedicalPrescriptionInfoByID(ID);

            if (dto != null)
                return new clsMedicalPrescription(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMedicalPrescriptionDTO> GetAllMedicalPrescriptions()
        {
            return clsMedicalPrescriptionsDataAccess.GetAllMedicalPrescriptions();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicalPrescription())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMedicalPrescription();
            }

            return false;
        }

        public static bool DeleteMedicalPrescription(int? ID)
        {
            return clsMedicalPrescriptionsDataAccess.DeleteMedicalPrescription(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMedicalPrescriptionsDataAccess.IsMedicalPrescriptionExist(ID);
        }
    }
}