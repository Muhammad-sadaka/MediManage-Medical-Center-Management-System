using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class PatientCaseDTO
    {
    }
    public class clsPatientCaseDTO
    {
        public int? PatientCaseID { get; set; }
        public string PatientCaseName { get; set; }

        public clsPatientCaseDTO(int? patientCaseID, string patientCaseName)
        {
            this.PatientCaseID = patientCaseID;
            this.PatientCaseName = patientCaseName;
        }
    }
}
