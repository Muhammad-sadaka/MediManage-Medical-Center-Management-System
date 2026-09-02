using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{

    public class clsMaritalStatus
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsMaritalStatusDTO DTO
        {
            get
            {
                return new clsMaritalStatusDTO
                (
                    this.MaritalStatusID,
                    this.MaritalStatusName
                );
            }
        }

        public int? MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }

        public clsMaritalStatus(clsMaritalStatusDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MaritalStatusID = dto.MaritalStatusID;
            this.MaritalStatusName = dto.MaritalStatusName;
            this.Mode = cMode;
        }

        private bool _AddNewMaritalStatus()
        {
            this.MaritalStatusID = clsMaritalStatusesDataAccess.AddNewMaritalStatus(this.DTO);
            return (this.MaritalStatusID.HasValue);
        }

        private bool _UpdateMaritalStatus()
        {
            return clsMaritalStatusesDataAccess.UpdateMaritalStatus(this.DTO);
        }

        public static clsMaritalStatus Find(int? ID)
        {
            clsMaritalStatusDTO dto = clsMaritalStatusesDataAccess.GetMaritalStatusInfoByID(ID);

            if (dto != null)
                return new clsMaritalStatus(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMaritalStatusDTO> GetAllMaritalStatuses()
        {
            return clsMaritalStatusesDataAccess.GetAllMaritalStatuses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMaritalStatus())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMaritalStatus();
            }

            return false;
        }

        public static bool DeleteMaritalStatus(int? ID)
        {
            return clsMaritalStatusesDataAccess.DeleteMaritalStatus(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMaritalStatusesDataAccess.IsMaritalStatusExist(ID);
        }
    }
}