using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class CountryDTO
    {
    }
    public class clsCountryDTO
    {
        public int? CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountryDTO(int? countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }
    }
}
