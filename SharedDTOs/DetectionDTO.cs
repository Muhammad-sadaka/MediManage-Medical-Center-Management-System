using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class DetectionDTO
    {
    }
    public class clsDetectionDTO
    {
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
        public DateTime? DetectionDate { get; set; }

        public clsDetectionDTO(int? detectionID, int? appointmentID, int? createdByUserID,
            string symproms, string diagnosis, byte? temperature, byte? wight,
            byte? bloodPressure, byte? heartRate, string notes, DateTime? DetectionDate)
        {
            this.DetectionID = detectionID;
            this.AppointmentID = appointmentID;
            this.CreatedByUserID = createdByUserID;
            this.Symproms = symproms;
            this.Diagnosis = diagnosis;
            this.Temperature = temperature;
            this.Wight = wight;
            this.BloodPressure = bloodPressure;
            this.HeartRate = heartRate;
            this.Notes = notes;
            this.DetectionDate = DetectionDate;
        }
    }

    public class clsDetectionListDTO
    {
        public int? DetectionID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime? DetectionDate { get; set; }


        public clsDetectionListDTO(int? DetectionID, string PatientName, string DoctorName, DateTime? DetectionDate)
        {
            this.DetectionID = DetectionID;
            this.PatientName = PatientName;
            this.DoctorName = DoctorName;
            this.DetectionDate = DetectionDate;
        }
    }
}
