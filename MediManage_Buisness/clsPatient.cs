using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsPatient
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPatientDTO DTO
        {
            get
            {
                return new clsPatientDTO
                (
                    this.PatientID,
                    this.PersonID,
                    this.Sensitivity,
                    this.ChronicDiseases,
                    this.JoinDate,
                    this.PatientCaseID
                );
            }
        }

        public int? PatientID { get; set; }
        public int? PersonID { get; set; }
        public string Sensitivity { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? PatientCaseID { get; set; }


        public clsPatient()
        {
            this.PersonID = null;
            this.PersonID = null;
            this.Sensitivity = string.Empty;
            this.ChronicDiseases = string.Empty;
            this.JoinDate = null;
            this.PatientCaseID = null;
            this.Mode = enMode.AddNew;
        }


        public clsPatient(clsPatientDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PatientID = dto.PatientID;
            this.PersonID = dto.PersonID;
            this.Sensitivity = dto.Sensitivity;
            this.ChronicDiseases = dto.ChronicDiseases;
            this.JoinDate = dto.JoinDate;
            this.PatientCaseID = dto.PatientCaseID;
            this.Mode = cMode;
        }

        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientsDataAccess.AddNewPatient(this.DTO);
            return (this.PatientID.HasValue);
        }

        private bool _UpdatePatient()
        {
            return clsPatientsDataAccess.UpdatePatient(this.DTO);
        }

        public static clsPatient Find(int? ID)
        {
            clsPatientDTO dto = clsPatientsDataAccess.GetPatientInfoByPersonID(ID);

            if (dto != null)
                return new clsPatient(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPatientsListDTO> GetAllPatients()
        {
            return clsPatientsDataAccess.GetAllPatients();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPatient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePatient();
            }

            return false;
        }

        public static bool DeletePatient(int? ID)
        {
            return clsPatientsDataAccess.DeletePatient(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPatientsDataAccess.IsPatientExist(ID);
        }

        public static int? GetTotalPatientsNumber()
        {
            return clsPatientsDataAccess.GetTotalPatientsNumber();
        }
    }
}