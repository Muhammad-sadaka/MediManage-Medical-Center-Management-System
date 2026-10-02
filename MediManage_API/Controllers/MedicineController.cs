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
    public class MedicineController : ControllerBase
    {
        private readonly IValidator<clsMedicineDTO> _validator;

        public MedicineController(IValidator<clsMedicineDTO> validator)
        {
            _validator = validator;
        }

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
            if (id <= 0)
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
        public ActionResult<clsMedicineDTO> AddMedicine([FromBody] clsMedicineDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsMedicine medicine = new clsMedicine(newDTO, clsMedicine.enMode.AddNew);

            if (medicine.Save())
            {
                newDTO.MedicineID = medicine.MedicineID;
                return CreatedAtRoute("GetMedicineById", new { id = newDTO.MedicineID }, newDTO);
            }

            return BadRequest("Failed to create new Medicine.");
        }

        [HttpPut("{id}", Name = "UpdateMedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicineDTO> UpdateMedicine(int id, [FromBody] clsMedicineDTO updatedDTO)
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

            clsMedicine medicine = clsMedicine.Find(id);

            if (medicine == null)
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

            medicine.MedicineName = updatedDTO.MedicineName;

            if (medicine.Save())
            {
                return Ok(medicine.DTO);
            }

            return BadRequest("Failed to update Medicine.");
        }

        [HttpDelete("{id}", Name = "DeleteMedicine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicine(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsMedicine.IsExist(id))
            {
                return NotFound($"Medicine with ID {id} not found.");
            }

            if (clsMedicine.DeleteMedicine(id))
            {
                return Ok($"Medicine with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Medicine.");
        }

        [HttpGet("Exists/{id}", Name = "IsMedicineExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicineExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicine.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}