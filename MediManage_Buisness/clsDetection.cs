using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{

    public class clsDetection
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsDetectionDTO DTO
        {
            get
            {
                return new clsDetectionDTO
                (
                    this.DetectionID,
                    this.AppointmentID,
                    this.CreatedByUserID,
                    this.Symproms,
                    this.Diagnosis,
                    this.Temperature,
                    this.Wight,
                    this.BloodPressure,
                    this.HeartRate,
                    this.Notes
                );
            }
        }

        public int? DetectionID { get; set; }
        public int? AppointmentID { get; set; }
        public int? CreatedByUserID { get; set; }
        public string Symproms { get; set; }
        public string Diagnosis { get; set; }
        public byte? Temperature { get; set; }
        public byte? Wight { get; set; }
        public byte? BloodPressure { get; set; }
        public byte? HeartRate { get; set; }
        public string Notes { get; set; }
        public clsAppointment AppointmentInfo { get; set; }

        public clsDetection(clsDetectionDTO dto, enMode cMode = enMode.AddNew)
        {
            this.DetectionID = dto.DetectionID;
            this.AppointmentID = dto.AppointmentID;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.Symproms = dto.Symproms;
            this.Diagnosis = dto.Diagnosis;
            this.Temperature = dto.Temperature;
            this.Wight = dto.Wight;
            this.BloodPressure = dto.BloodPressure;
            this.HeartRate = dto.HeartRate;
            this.Notes = dto.Notes;
            this.AppointmentInfo = clsAppointment.Find(AppointmentID);
            this.Mode = cMode;
        }

        private bool _AddNewDetection()
        {
            this.DetectionID = clsDetectionsDataAccess.AddNewDetection(this.DTO);
            return (this.DetectionID.HasValue);
        }

        private bool _UpdateDetection()
        {
            return clsDetectionsDataAccess.UpdateDetection(this.DTO);
        }

        public static clsDetection Find(int? ID)
        {
            clsDetectionDTO dto = clsDetectionsDataAccess.GetDetectionInfoByID(ID);

            if (dto != null)
                return new clsDetection(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsDetectionDTO> GetAllDetections()
        {
            return clsDetectionsDataAccess.GetAllDetections();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetection())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDetection();
            }

            return false;
        }

        public static bool DeleteDetection(int? ID)
        {
            return clsDetectionsDataAccess.DeleteDetection(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsDetectionsDataAccess.IsDetectionExist(ID);
        }
    }
}