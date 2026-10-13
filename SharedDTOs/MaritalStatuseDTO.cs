using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class MaritalStatuseDTO
    {
    }
    public class clsMaritalStatusDTO
    {
        public int? MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }

        public clsMaritalStatusDTO(int? maritalStatusID, string maritalStatusName)
        {
            this.MaritalStatusID = maritalStatusID;
            this.MaritalStatusName = maritalStatusName;
        }
    }
}
