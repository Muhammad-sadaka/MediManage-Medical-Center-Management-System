using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class DoctorDTO
    {
    }
    public class clsDoctorDTO
    {
        public int? DoctorID { get; set; }
        public int? PersonID { get; set; }
        public byte? YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public bool? IsActive { get; set; }
        public int? SpecialtyID { get; set; }
        public string LicenseNo { get; set; }

        public clsDoctorDTO(int? doctorID, int? personID, byte? yearsOfExperience, string qualification, bool? isActive, int? specialtyID, string licenseNo)
        {
            this.DoctorID = doctorID;
            this.PersonID = personID;
            this.YearsOfExperience = yearsOfExperience;
            this.Qualification = qualification;
            this.IsActive = isActive;
            this.SpecialtyID = specialtyID;
            this.LicenseNo = licenseNo;
        }
    }

    public class clsDoctorListDTO
    {
        public int? DoctorID { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public decimal? Fees { get; set; }


        public clsDoctorListDTO(int? DoctorID, string NationalNo, string FullName, string Specialty, string Phone, decimal? Fees)
        {
            this.DoctorID = DoctorID;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.Specialty = Specialty;
            this.Phone = Phone;
            this.Fees = Fees;
        }
    }
}
