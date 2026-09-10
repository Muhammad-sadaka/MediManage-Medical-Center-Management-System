using MediManage_DataAccess;
using System;
using System.Collections.Generic;
using static MediManage_DataAccess.clsMedicineDTO;

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
                    this.MedicineName
                );
            }
        }

        public int? MedicineID { get; set; }
        public string MedicineName { get; set; }

        public clsMedicine(clsMedicineDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MedicineID = dto.MedicineID;
            this.MedicineName = dto.MedicineName;

            this.Mode = cMode;
        }

        private bool _AddNewMedicine()
        {
            this.MedicineID = clsMedicineDataAccess.AddNewMedicine(this.DTO);
            return (this.MedicineID.HasValue);
        }

        private bool _UpdateMedicine()
        {
            return clsMedicineDataAccess.UpdateMedicine(this.DTO);
        }

        public static clsMedicine Find(int? ID)
        {
            clsMedicineDTO dto = clsMedicineDataAccess.GetMedicineInfoByID(ID);

            if (dto != null)
                return new clsMedicine(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMedicineDTO> GetAllMedicines()
        {
            return clsMedicineDataAccess.GetAllMedicines();
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
            return clsMedicineDataAccess.DeleteMedicine(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMedicineDataAccess.IsMedicineExist(ID);
        }
    }
}