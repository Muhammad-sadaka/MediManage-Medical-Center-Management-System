using FluentValidation;
using MediManage_Business;
using MediManage_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineRecipeController : ControllerBase
    {
        private readonly IValidator<clsMedicineRecipeDTO> _validator;

        public MedicineRecipeController(IValidator<clsMedicineRecipeDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All/{MedicalPrescriptionID}", Name = "GetAllMedicineRecipes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicineRecipeListDTO>> GetAllMedicineRecipes(int MedicalPrescriptionID)
        {
            if (MedicalPrescriptionID <= 0)
            {
                return BadRequest($"Invalid Medical Prescription ID {MedicalPrescriptionID}");
            }

            List<clsMedicineRecipeListDTO> list = clsMedicineRecipe.GetAllMedicinesRecipes(MedicalPrescriptionID);
            if (list == null || list.Count == 0)
            {
                return NotFound("No Medicine Recipes Found for this Prescription!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMedicineRecipeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineRecipeDTO> GetMedicineRecipeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMedicineRecipe medicineRecipe = clsMedicineRecipe.Find(id);

            if (medicineRecipe == null)
            {
                return NotFound($"Medicine Recipe with ID {id} not found.");
            }

            return Ok(medicineRecipe.DTO);
        }

        [HttpPost(Name = "AddMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMedicineRecipeDTO> AddMedicineRecipe([FromBody] clsMedicineRecipeDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsMedicineRecipe medicineRecipe = new clsMedicineRecipe(newDTO, clsMedicineRecipe.enMode.AddNew);

            if (medicineRecipe.Save())
            {
                newDTO.MedicineRecipeID = medicineRecipe.MedicineRecipeID;
                return CreatedAtRoute("GetMedicineRecipeById", new { id = newDTO.MedicineRecipeID }, newDTO);
            }

            return BadRequest("Failed to create new Medicine Recipe.");
        }

        [HttpPut("{id}", Name = "UpdateMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineRecipeDTO> UpdateMedicineRecipe(int id, [FromBody] clsMedicineRecipeDTO updatedDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            var validationResult = _validator.Validate(updatedDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsMedicineRecipe medicineRecipe = clsMedicineRecipe.Find(id);

            if (medicineRecipe == null)
            {
                return NotFound($"Medicine Recipe with ID {id} not found.");
            }

            medicineRecipe.Duration = updatedDTO.Duration;
            medicineRecipe.Repetition = updatedDTO.Repetition;
            medicineRecipe.Dose = updatedDTO.Dose;
            medicineRecipe.MedicalPrescriptionID = updatedDTO.MedicalPrescriptionID;
            medicineRecipe.MedicineID = updatedDTO.MedicineID;
            medicineRecipe.Notes = updatedDTO.Notes;

            if (medicineRecipe.Save())
            {
                return Ok(medicineRecipe.DTO);
            }

            return BadRequest("Failed to update Medicine Recipe.");
        }

        [HttpDelete("{id}", Name = "DeleteMedicineRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicineRecipe(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsMedicineRecipe.IsExist(id))
            {
                return NotFound($"Medicine Recipe with ID {id} not found.");
            }

            if (clsMedicineRecipe.DeleteMedicine(id))
            {
                return Ok($"Medicine Recipe with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Medicine Recipe.");
        }

        [HttpGet("Exists/{id}", Name = "IsMedicineRecipeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicineRecipeExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicineRecipe.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}