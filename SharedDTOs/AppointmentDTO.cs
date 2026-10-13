using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class AppointmentDTO
    {
    }
    public class clsAppointmentDTO
    {
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

        public clsAppointmentDTO(int? appointmentID, int? patientID, int? doctorID, int? createdByUserID,
            DateTime? bookingDate, DateTime? appointmentDate, int? appointmentCaseID, byte? duration, string reason, string notes)
        {
            this.AppointmentID = appointmentID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.CreatedByUserID = createdByUserID;
            this.BookingDate = bookingDate;
            this.AppointmentDate = appointmentDate;
            this.AppointmentCaseID = appointmentCaseID;
            this.Duration = duration;
            this.Reason = reason;
            this.Notes = notes;
        }
    }

    public class clsTodayAppointmentDTO
    {
        public TimeSpan? Time { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }

        public clsTodayAppointmentDTO(TimeSpan? time, string patientName, string doctorName, string status)
        {
            Time = time;
            PatientName = patientName;
            DoctorName = doctorName;
            Status = status;
        }
    }

    public class clsAppointmentListDTO
    {
        public int? AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Status { get; set; }

        public clsAppointmentListDTO(int? appointmentID, string patientName, string doctorName, DateTime? appointmentDate, string status)
        {
            AppointmentID = appointmentID;
            PatientName = patientName;
            DoctorName = doctorName;
            AppointmentDate = appointmentDate;
            Status = status;
        }
    }

}
