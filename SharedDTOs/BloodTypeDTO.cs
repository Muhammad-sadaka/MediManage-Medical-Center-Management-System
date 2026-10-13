using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class BloodTypeDTO
    {
    }
    public class clsBloodTypeDTO
    {
        public int? BloodTypeID { get; set; }
        public string BloodTypeSymbol { get; set; }

        public clsBloodTypeDTO(int? bloodTypeID, string bloodTypeSymbol)
        {
            this.BloodTypeID = bloodTypeID;
            this.BloodTypeSymbol = bloodTypeSymbol;
        }
    }

}
