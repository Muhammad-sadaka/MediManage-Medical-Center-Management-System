using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class MedicineDTO
    {
    }
    public class clsMedicineDTO
    {
        public int? MedicineID { get; set; }
        public string MedicineName { get; set; }

        public clsMedicineDTO(int? medicineID, string medicineName)
        {
            this.MedicineID = medicineID;
            this.MedicineName = medicineName;

        }

    }
}