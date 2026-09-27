using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineRecipeController : ControllerBase
    {
        [HttpGet("All/{MedicalPrescriptionID}", Name = "GetAllMedicineRecipes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicineRecipeListDTO>> GetAllMedicineRecipes(int? MedicalPrescriptionID)
        {
            List<clsMedicineRecipeListDTO> list = clsMedicineRecipe.GetAllMedicinesRecipes(MedicalPrescriptionID);
            if (list == null || list.Count == 0)
            {
                return NotFound("No Medicines Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMedicineRecipeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineRecipeDTO> GetMedicineRecipeById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMedicineRecipe medicine = clsMedicineRecipe.Find(id);

            if (medicine == null)
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

            return Ok(medicine.DTO);
        }

        [HttpPost(Name = "AddMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMedicineRecipeDTO> AddMedicineRecipe(clsMedicineRecipeDTO newDTO)
        {
            if (newDTO == null || !newDTO.MedicalPrescriptionID.HasValue)
            {
                return BadRequest("Invalid medicine data.");
            }

            clsMedicineRecipe medicine = new clsMedicineRecipe(newDTO, clsMedicineRecipe.enMode.AddNew);

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

        [HttpPut("{id}", Name = "UpdateMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineRecipeDTO> UpdateMedicineRecipe(int id, clsMedicineRecipeDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.MedicalPrescriptionID.HasValue)
            {
                return BadRequest("Invalid medicine data.");
            }

            clsMedicineRecipe medicine = clsMedicineRecipe.Find(id);

            if (medicine == null)
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

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

        [HttpDelete("{id}", Name = "DeleteMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicineRecipe(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicineRecipe.DeleteMedicine(id))
            {
                return Ok($"Medicine with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Medicine with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsMedicineRecipeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicineRecipeExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicineRecipe.IsExist(id))
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