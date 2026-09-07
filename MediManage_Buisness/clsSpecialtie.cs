using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{
    public class clsSpecialty
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int? SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public string Description { get; set; }
        public decimal? Fees { get; set; }

        public clsSpecialtyDTO DTO => new clsSpecialtyDTO(this.SpecialtyID, this.SpecialtyName, this.Description, this.Fees);

        public clsSpecialty()
        {
            this.SpecialtyID = null;
            this.SpecialtyName = string.Empty;
            this.Description = string.Empty;
            this.Fees = null;
            this.Mode = enMode.AddNew;
        }

        public clsSpecialty(clsSpecialtyDTO dto, enMode mode = enMode.AddNew)
        {
            this.SpecialtyID = dto.SpecialtyID;
            this.SpecialtyName = dto.SpecialtyName;
            this.Description = dto.Description;
            this.Fees = dto.Fees;
            this.Mode = mode;
        }

        private bool _AddNewSpecialty()
        {
            this.SpecialtyID = clsSpecialtiesDataAccess.AddNewSpecialty(this.DTO);
            return (this.SpecialtyID != null);
        }

        private bool _UpdateSpecialty()
        {
            return clsSpecialtiesDataAccess.UpdateSpecialty(this.DTO);
        }

        public static clsSpecialty Find(int? specialtyID)
        {
            clsSpecialtyDTO dto = clsSpecialtiesDataAccess.GetSpecialtyInfoByID(specialtyID);

            if (dto != null)
                return new clsSpecialty(dto, enMode.Update);

            return null;
        }

        public static clsSpecialty Find(string specialtyName)
        {
            clsSpecialtyDTO dto = clsSpecialtiesDataAccess.GetSpecialtyInfoByspecialtyName(specialtyName);

            if (dto != null)
                return new clsSpecialty(dto, enMode.Update);

            return null;
        }

        public static List<clsSpecialtyDTO> GetAllSpecialties()
        {
            return clsSpecialtiesDataAccess.GetAllSpecialties();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSpecialty())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateSpecialty();
            }

            return false;
        }

        public static bool DeleteSpecialty(int? specialtyID)
        {
            return clsSpecialtiesDataAccess.DeleteSpecialty(specialtyID);
        }

        public static bool IsSpecialtyExist(int? specialtyID)
        {
            return clsSpecialtiesDataAccess.IsSpecialtyExist(specialtyID);
        }
    }
}