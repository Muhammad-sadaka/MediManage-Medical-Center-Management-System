using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{
    public class clsServiceType
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int? ServiceTypeID { get; set; }
        public string ServicTypeName { get; set; }

        public clsServiceTypeDTO DTO => new clsServiceTypeDTO(this.ServiceTypeID, this.ServicTypeName);

        public clsServiceType()
        {
            this.ServiceTypeID = null;
            this.ServicTypeName = string.Empty;
            this.Mode = enMode.AddNew;
        }

        public clsServiceType(clsServiceTypeDTO dto, enMode mode = enMode.AddNew)
        {
            this.ServiceTypeID = dto.ServiceTypeID;
            this.ServicTypeName = dto.ServicTypeName;
            this.Mode = mode;
        }

        private bool _AddNewServiceType()
        {
            this.ServiceTypeID = clsServiceTypesDataAccess.AddNewServiceType(this.DTO);
            return (this.ServiceTypeID != null);
        }

        private bool _UpdateServiceType()
        {
            return clsServiceTypesDataAccess.UpdateServiceType(this.DTO);
        }

        public static clsServiceType Find(int? serviceTypeID)
        {
            clsServiceTypeDTO dto = clsServiceTypesDataAccess.GetServiceTypeInfoByID(serviceTypeID);

            if (dto != null)
                return new clsServiceType(dto, enMode.Update);

            return null;
        }

        public static List<clsServiceTypeDTO> GetAllServiceTypes()
        {
            return clsServiceTypesDataAccess.GetAllServiceTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewServiceType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateServiceType();
            }

            return false;
        }

        public static bool DeleteServiceType(int? serviceTypeID)
        {
            return clsServiceTypesDataAccess.DeleteServiceType(serviceTypeID);
        }

        public static bool IsServiceTypeExist(int? serviceTypeID)
        {
            return clsServiceTypesDataAccess.IsServiceTypeExist(serviceTypeID);
        }
    }
}