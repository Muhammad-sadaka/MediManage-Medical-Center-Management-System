using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class PatientDTO
    {
    }
    public class clsPatientDTO
    {
        public int? PatientID { get; set; }
        public int? PersonID { get; set; }
        public string Sensitivity { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? PatientCaseID { get; set; }

        public clsPatientDTO(int? patientID, int? personID, string sensitivity, string chronicDiseases, DateTime? joinDate, int? patientCaseID)
        {
            this.PatientID = patientID;
            this.PersonID = personID;
            this.Sensitivity = sensitivity;
            this.ChronicDiseases = chronicDiseases;
            this.JoinDate = joinDate;
            this.PatientCaseID = patientCaseID;
        }
    }

    public class clsPatientsListDTO
    {
        public int? PatientID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public string Phone { get; set; }

        public clsPatientsListDTO(int? PatientID, string FullName, string NationalNo, string Phone)
        {
            this.PatientID = PatientID;
            this.FullName = FullName;
            this.NationalNo = NationalNo;
            this.Phone = Phone;
        }
    }

}
