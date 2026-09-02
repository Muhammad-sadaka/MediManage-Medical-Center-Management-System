using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsCountryDTO CountryDTO
        {
            get
            {
                return new clsCountryDTO
                (
                    this.CountryID,
                    this.CountryName
                );
            }
        }

        public int? CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry(clsCountryDTO dto, enMode cMode = enMode.AddNew)
        {
            this.CountryID = dto.CountryID;
            this.CountryName = dto.CountryName;
            this.Mode = cMode;
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryData.AddNewCountry(this.CountryDTO);
            return (this.CountryID.HasValue);
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this.CountryDTO);
        }

        public static clsCountry Find(int? ID)
        {
            clsCountryDTO dto = clsCountryData.GetCountryInfoByID(ID);

            if (dto != null)
                return new clsCountry(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsCountryDTO> GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCountry();
            }

            return false;
        }

        public static bool DeleteCountry(int? ID)
        {
            return clsCountryData.DeleteCountry(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsCountryData.IsCountryExist(ID);
        }
    }
}