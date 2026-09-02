using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{


    public class clsDoctor
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsDoctorDTO DTO
        {
            get
            {
                return new clsDoctorDTO
                (
                    this.DoctorID,
                    this.PersonID,
                    this.YearsOfExperience,
                    this.Qualification,
                    this.IsActive,
                    this.SpecialtyID
                );
            }
        }

        public int? DoctorID { get; set; }
        public int? PersonID { get; set; }
        public byte? YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public bool? IsActive { get; set; }
        public int? SpecialtyID { get; set; }

        public clsDoctor()
        {
            this.DoctorID = null;
            this.PersonID = null;
            this.YearsOfExperience = null;
            this.Qualification = null;
            this.IsActive = null;
            this.SpecialtyID = null;
            this.Mode = enMode.AddNew;
        }

        public clsDoctor(clsDoctorDTO dto, enMode cMode = enMode.AddNew)
        {
            this.DoctorID = dto.DoctorID;
            this.PersonID = dto.PersonID;
            this.YearsOfExperience = dto.YearsOfExperience;
            this.Qualification = dto.Qualification;
            this.IsActive = dto.IsActive;
            this.SpecialtyID = dto.SpecialtyID;
            this.Mode = cMode;
        }

        private bool _AddNewDoctor()
        {
            this.DoctorID = clsDoctorsDataAccess.AddNewDoctor(this.DTO);
            return (this.DoctorID.HasValue);
        }

        private bool _UpdateDoctor()
        {
            return clsDoctorsDataAccess.UpdateDoctor(this.DTO);
        }

        public static clsDoctor Find(int? ID)
        {
            clsDoctorDTO dto = clsDoctorsDataAccess.GetDoctorInfoByID(ID);

            if (dto != null)
                return new clsDoctor(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsDoctorListDTO> GetAllDoctors()
        {
            return clsDoctorsDataAccess.GetAllDoctors();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDoctor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDoctor();
            }

            return false;
        }

        public static bool DeleteDoctor(int? ID)
        {
            return clsDoctorsDataAccess.DeleteDoctor(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsDoctorsDataAccess.IsDoctorExist(ID);
        }
    }
}