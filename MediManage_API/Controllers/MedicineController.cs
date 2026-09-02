using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllMedicines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicineDTO>> GetAllMedicines()
        {
            List<clsMedicineDTO> list = clsMedicine.GetAllMedicines();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Medicines Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMedicineById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineDTO> GetMedicineById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMedicine medicine = clsMedicine.Find(id);

            if (medicine == null)
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

            return Ok(medicine.DTO);
        }

        [HttpPost(Name = "AddMedicine")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMedicineDTO> AddMedicine(clsMedicineDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.MedicineName) || !newDTO.MedicalPrescriptionID.HasValue)
            {
                return BadRequest("Invalid medicine data.");
            }

            clsMedicine medicine = new clsMedicine(newDTO, clsMedicine.enMode.AddNew);

            if (medicine.Save())
            {
                newDTO.MedicineID = medicine.MedicineID;
                return CreatedAtRoute("GetMedicineById", new { id = newDTO.MedicineID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Medicine.");
            }
        }

        [HttpPut("{id}", Name = "UpdateMedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineDTO> UpdateMedicine(int id, clsMedicineDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.MedicineName) || !updatedDTO.MedicalPrescriptionID.HasValue)
            {
                return BadRequest("Invalid medicine data.");
            }

            clsMedicine medicine = clsMedicine.Find(id);

            if (medicine == null)
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

            medicine.MedicineName = updatedDTO.MedicineName;
            medicine.Duration = updatedDTO.Duration;
            medicine.Repetition = updatedDTO.Repetition;
            medicine.Dose = updatedDTO.Dose;
            medicine.MedicalPrescriptionID = updatedDTO.MedicalPrescriptionID;
            medicine.Notes = updatedDTO.Notes;

            if (medicine.Save())
            {
                return Ok(medicine.DTO);
            }
            else
            {
                return BadRequest("Failed to update Medicine.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicine(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicine.DeleteMedicine(id))
            {
                return Ok($"Medicine with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Medicine with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsMedicineExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicineExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicine.IsExist(id))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
    }
}