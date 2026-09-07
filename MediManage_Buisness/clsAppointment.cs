
using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{

    public class clsAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsAppointmentDTO AppointmentDTO
        {
            get
            {
                return new clsAppointmentDTO
                (
                    this.AppointmentID,
                    this.PatientID,
                    this.DoctorID,
                    this.CreatedByUserID,
                    this.BookingDate,
                    this.AppointmentDate,
                    this.AppointmentCaseID,
                    this.Duration,
                    this.Reason,
                    this.Notes
                );
            }
        }

        public int? AppointmentID { get; set; }
        public int? PatientID { get; set; }
        public int? DoctorID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? AppointmentCaseID { get; set; }
        public byte? Duration { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public clsPatient PatientInfo { get; set; }
        public clsDoctor DoctorInfo { get; set; }

        public clsAppointment()
        {
            this.AppointmentID = null;
            this.PatientID = null;
            this.DoctorID = null;
            this.CreatedByUserID = null;
            this.BookingDate = null;
            this.AppointmentDate =  null;
            this.AppointmentCaseID =  null;
            this.Duration =  null;
            this.Reason =  null;
            this.Notes = null;
            this.PatientInfo =  null;
            this.DoctorInfo =  null;
            this.Mode = enMode.AddNew;
        }

        public clsAppointment(clsAppointmentDTO dto, enMode cMode = enMode.AddNew)
        {
            this.AppointmentID = dto.AppointmentID;
            this.PatientID = dto.PatientID;
            this.DoctorID = dto.DoctorID;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.BookingDate = dto.BookingDate;
            this.AppointmentDate = dto.AppointmentDate;
            this.AppointmentCaseID = dto.AppointmentCaseID;
            this.Duration = dto.Duration;
            this.Reason = dto.Reason;
            this.Notes = dto.Notes;
            this.PatientInfo = clsPatient.Find(PatientID);
            this.DoctorInfo = clsDoctor.Find(DoctorID);
            this.Mode = cMode;
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsAppointmentsDataAccess.AddNewAppointment(this.AppointmentDTO);
            return (this.AppointmentID.HasValue);
        }

        private bool _UpdateAppointment()
        {
            return clsAppointmentsDataAccess.UpdateAppointment(this.AppointmentDTO);
        }

        public static clsAppointment Find(int? ID)
        {
            clsAppointmentDTO dto = clsAppointmentsDataAccess.GetAppointmentInfoByID(ID);

            if (dto != null)
                return new clsAppointment(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsAppointmentListDTO> GetAllAppointments()
        {
            return clsAppointmentsDataAccess.GetAllAppointments();
        }

        public static List<clsTodayAppointmentDTO> GetTodayAppointments()
        {
            return clsAppointmentsDataAccess.GetTodayAppointments();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }

        public static bool DeleteAppointment(int? ID)
        {
            return clsAppointmentsDataAccess.DeleteAppointment(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsAppointmentsDataAccess.IsAppointmentExist(ID);
        }
    }
}