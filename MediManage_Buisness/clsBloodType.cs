using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsBloodType
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsBloodTypeDTO BloodTypeDTO
        {
            get
            {
                return new clsBloodTypeDTO
                (
                    this.BloodTypeID,
                    this.BloodTypeSymbol
                );
            }
        }

        public int? BloodTypeID { get; set; }
        public string BloodTypeSymbol { get; set; }

        public clsBloodType(clsBloodTypeDTO dto, enMode cMode = enMode.AddNew)
        {
            this.BloodTypeID = dto.BloodTypeID;
            this.BloodTypeSymbol = dto.BloodTypeSymbol;
            this.Mode = cMode;
        }

        private bool _AddNewBloodType()
        {
            this.BloodTypeID = clsBloodTypesDataAccess.AddNewBloodType(this.BloodTypeDTO);
            return (this.BloodTypeID.HasValue);
        }

        private bool _UpdateBloodType()
        {
            return clsBloodTypesDataAccess.UpdateBloodType(this.BloodTypeDTO);
        }

        public static clsBloodType Find(int? ID)
        {
            clsBloodTypeDTO dto = clsBloodTypesDataAccess.GetBloodTypeInfoByID(ID);

            if (dto != null)
                return new clsBloodType(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsBloodTypeDTO> GetAllBloodTypes()
        {
            return clsBloodTypesDataAccess.GetAllBloodTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBloodType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBloodType();
            }

            return false;
        }

        public static bool DeleteBloodType(int? ID)
        {
            return clsBloodTypesDataAccess.DeleteBloodType(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsBloodTypesDataAccess.IsBloodTypeExist(ID);
        }
    }
}