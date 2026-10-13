using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class MedicineRecipeDTO
    {
    }
    public class clsMedicineRecipeDTO
    {
        public int? MedicineRecipeID { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }
        public int? MedicalPrescriptionID { get; set; }
        public string Notes { get; set; }
        public int? MedicineID { get; set; }

        public clsMedicineRecipeDTO(int? MedicineRecipeID, string duration, string repetition, string dose, int? medicalPrescriptionID, string notes, int? medicineID)
        {
            this.MedicineRecipeID = MedicineRecipeID;
            this.Duration = duration;
            this.Repetition = repetition;
            this.Dose = dose;
            this.MedicalPrescriptionID = medicalPrescriptionID;
            this.Notes = notes;
            this.MedicineID = medicineID;
        }
    }

    public class clsMedicineRecipeListDTO
    {
        public string MedicineName { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }
        public string Notes { get; set; }

        public clsMedicineRecipeListDTO(string MedicineName, string dose, string repetition, string duration, string notes)
        {
            this.MedicineName = MedicineName;
            this.Duration = duration;
            this.Repetition = repetition;
            this.Dose = dose;
            this.Notes = notes;
        }
    }

}
