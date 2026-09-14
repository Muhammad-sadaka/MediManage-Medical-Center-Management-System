using System;
using System.Collections.Generic;
using MediManage_DataAccess;



namespace MediManage_Business
{
  
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPersonDTO DTO
        {
            get
            {
                return new clsPersonDTO
                (
                    this.PersonID,
                    this.FirstName,
                    this.SecondName,
                    this.ThirdName,
                    this.LastName,
                    this.NationalNo,
                    this.Phone,
                    this.DateOfBirth,
                    this.Gender,
                    this.Image,
                    this.Address,
                    this.Email,
                    this.BloodTypeID,
                    this.MaritalStatusID,
                    this.CountryId
                );
            }
        }

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
        public string FullName { get; }
       public clsCountry CountryInfo { get; set; }
       public clsBloodType BloodTypeInfo { get; set; }
       public clsMaritalStatus MaritalStatusInfo { get; set; } 


        //is it right ??
        public clsPerson()
        {
            this.PersonID = null;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.NationalNo = string.Empty;
            this.Phone = string.Empty;
            this.DateOfBirth = null;
            this.Gender = string.Empty;
            this.Image = string.Empty;
            this.Address = string.Empty;
            this.Email = string.Empty;
            this.BloodTypeID = null;
            this.MaritalStatusID = null;
            this.CountryId = null;
            this.FullName = null;
            this.CountryInfo = null;
            this.BloodTypeInfo = null;
            this.MaritalStatusInfo = null;

            this.Mode = enMode.AddNew;
        }


        public clsPerson(clsPersonDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PersonID = dto.PersonID;
            this.FirstName = dto.FirstName;
            this.SecondName = dto.SecondName;
            this.ThirdName = dto.ThirdName;
            this.LastName = dto.LastName;
            this.NationalNo = dto.NationalNo;
            this.Phone = dto.Phone;
            this.DateOfBirth = dto.DateOfBirth;
            this.Gender = dto.Gender;
            this.Image = dto.Image;
            this.Address = dto.Address;
            this.Email = dto.Email;
            this.BloodTypeID = dto.BloodTypeID;
            this.MaritalStatusID = dto.MaritalStatusID;
            this.CountryId = dto.CountryId;
            this.FullName = this.FirstName + " " + this.LastName;
            this.CountryInfo = clsCountry.Find(this.CountryId);
            this.BloodTypeInfo = clsBloodType.Find(this.BloodTypeID);
            this.MaritalStatusInfo = clsMaritalStatus.Find(this.MaritalStatusID);


            this.Mode = cMode;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.DTO);
            return (this.PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePerson(this.DTO);
        }

        public static clsPerson Find(int? ID)
        {
            clsPersonDTO dto = clsPeopleDataAccess.GetPersonInfoByID(ID);

            if (dto != null)
                return new clsPerson(dto, enMode.Update);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            clsPersonDTO dto = clsPeopleDataAccess.GetPersonInfoByNationalNo(NationalNo);

            if (dto != null)
                return new clsPerson(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPersonListDTO> GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static bool DeletePerson(int? ID)
        {
            return clsPeopleDataAccess.DeletePerson(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPeopleDataAccess.IsPersonExist(ID);
        }

        public static bool IsExist(string NationalNo)
        {
            return clsPeopleDataAccess.IsPersonExist(NationalNo);
        }
    }
}