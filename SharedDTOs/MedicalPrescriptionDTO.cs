using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class MedicalPrescriptionDTO
    {
    }
    public class clsMedicalPrescriptionDTO
    {
        public int? MedicalPrescriptionID { get; set; }
        public int? DetectionID { get; set; }
        public string Notes { get; set; }
        public DateTime? PrescriptionDate { get; set; }

        public clsMedicalPrescriptionDTO(int? medicalPrescriptionID, int? detectionID, string notes, DateTime? PrescriptionDate)
        {
            this.MedicalPrescriptionID = medicalPrescriptionID;
            this.DetectionID = detectionID;
            this.Notes = notes;
            this.PrescriptionDate = PrescriptionDate;
        }
    }

    public class clsMedicalPrescriptionsListDTO
    {
        public int? MedicalPrescriptionID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime? PrescriptionDate { get; set; }

        public clsMedicalPrescriptionsListDTO(int? medicalPrescriptionID, string PatientName, string DoctorName, DateTime? PrescriptionDate)
        {
            this.MedicalPrescriptionID = medicalPrescriptionID;
            this.PatientName = PatientName;
            this.DoctorName = DoctorName;
            this.PrescriptionDate = PrescriptionDate;
        }
    }
}
