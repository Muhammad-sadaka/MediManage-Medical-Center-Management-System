using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    public class PersonDTO
    {
    }

    public class clsPersonDTO
    {
        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? BloodTypeID { get; set; }
        public int? MaritalStatusID { get; set; }
        public int? CountryId { get; set; }

        public clsPersonDTO(int? personID, string firstName, string secondName, string thirdName, string lastName,
                            string nationalNo, string phone, DateTime? dateOfBirth, string gender, string image,
                            string address, string email, int? bloodTypeID, int? maritalStatusID, int? countryId)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.Phone = phone;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Image = image;
            this.Address = address;
            this.Email = email;
            this.BloodTypeID = bloodTypeID;
            this.MaritalStatusID = maritalStatusID;
            this.CountryId = countryId;
        }
    }

    public class clsPersonListDTO
    {
        public int? PersonID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public string Phone { get; set; }


        public clsPersonListDTO(int? personID, string FullName, string nationalNo, string phone)
        {
            this.PersonID = personID;
            this.FullName = FullName;
            this.NationalNo = nationalNo;
            this.Phone = phone;
        }
    }
}
