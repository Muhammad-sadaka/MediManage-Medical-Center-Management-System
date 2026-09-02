using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{


    public class clsPatientCase
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPatientCaseDTO DTO
        {
            get
            {
                return new clsPatientCaseDTO
                (
                    this.PatientCaseID,
                    this.PatientCaseName
                );
            }
        }

        public int? PatientCaseID { get; set; }
        public string PatientCaseName { get; set; }

        public clsPatientCase(clsPatientCaseDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PatientCaseID = dto.PatientCaseID;
            this.PatientCaseName = dto.PatientCaseName;
            this.Mode = cMode;
        }

        private bool _AddNewPatientCase()
        {
            this.PatientCaseID = clsPatientCasesDataAccess.AddNewPatientCase(this.DTO);
            return (this.PatientCaseID.HasValue);
        }

        private bool _UpdatePatientCase()
        {
            return clsPatientCasesDataAccess.UpdatePatientCase(this.DTO);
        }

        public static clsPatientCase Find(int? ID)
        {
            clsPatientCaseDTO dto = clsPatientCasesDataAccess.GetPatientCaseInfoByID(ID);

            if (dto != null)
                return new clsPatientCase(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPatientCaseDTO> GetAllPatientCases()
        {
            return clsPatientCasesDataAccess.GetAllPatientCases();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPatientCase())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePatientCase();
            }

            return false;
        }

        public static bool DeletePatientCase(int? ID)
        {
            return clsPatientCasesDataAccess.DeletePatientCase(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPatientCasesDataAccess.IsPatientCaseExist(ID);
        }
    }
}