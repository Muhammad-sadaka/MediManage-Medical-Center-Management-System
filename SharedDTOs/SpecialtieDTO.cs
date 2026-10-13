using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class SpecialtieDTO
    {
    }

    public class clsSpecialtyDTO
    {
        public int? SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public string Description { get; set; }
        public decimal? Fees { get; set; }

        public clsSpecialtyDTO(int? specialtyID, string specialtyName, string description, decimal? fees)
        {
            this.SpecialtyID = specialtyID;
            this.SpecialtyName = specialtyName;
            this.Description = description;
            this.Fees = fees;
        }

    }

}
