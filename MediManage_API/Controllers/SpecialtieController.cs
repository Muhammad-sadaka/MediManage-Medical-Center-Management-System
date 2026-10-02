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
    public class SpecialtyController : ControllerBase
    {
        private readonly IValidator<clsSpecialtyDTO> _validator;

        public SpecialtyController(IValidator<clsSpecialtyDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllSpecialties")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsSpecialtyDTO>> GetAllSpecialties()
        {
            List<clsSpecialtyDTO> list = clsSpecialty.GetAllSpecialties();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Specialties Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetSpecialtyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsSpecialtyDTO> GetSpecialtyById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsSpecialty specialty = clsSpecialty.Find(id);

            if (specialty == null)
            {
                return NotFound($"Specialty with ID {id} not found.");
            }

            return Ok(specialty.DTO);
        }

        [HttpGet("by-name/{specialtyName}", Name = "GetSpecialtyBySpecialtyName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsSpecialtyDTO> GetSpecialtyBySpecialtyName(string specialtyName)
        {
            if (string.IsNullOrWhiteSpace(specialtyName))
            {
                return BadRequest("Specialty Name cannot be empty.");
            }

            clsSpecialty specialty = clsSpecialty.Find(specialtyName);

            if (specialty == null)
            {
                return NotFound($"Specialty with Specialty Name '{specialtyName}' not found.");
            }

            return Ok(specialty.DTO);
        }

        [HttpPost(Name = "AddSpecialty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsSpecialtyDTO> AddSpecialty([FromBody] clsSpecialtyDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsSpecialty specialty = new clsSpecialty(newDTO, clsSpecialty.enMode.AddNew);

            if (specialty.Save())
            {
                newDTO.SpecialtyID = specialty.SpecialtyID;
                return CreatedAtRoute("GetSpecialtyById", new { id = newDTO.SpecialtyID }, newDTO);
            }

            return BadRequest("Failed to create new Specialty.");
        }

        [HttpPut("{id}", Name = "UpdateSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsSpecialtyDTO> UpdateSpecialty(int id, [FromBody] clsSpecialtyDTO updatedDTO)
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

            clsSpecialty specialty = clsSpecialty.Find(id);

            if (specialty == null)
            {
                return NotFound($"Specialty with ID {id} not found.");
            }

            specialty.SpecialtyName = updatedDTO.SpecialtyName;
            specialty.Description = updatedDTO.Description;
            specialty.Fees = updatedDTO.Fees;

            if (specialty.Save())
            {
                return Ok(specialty.DTO);
            }

            return BadRequest("Failed to update Specialty.");
        }

        [HttpDelete("{id}", Name = "DeleteSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSpecialty(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsSpecialty.IsSpecialtyExist(id))
            {
                return NotFound($"Specialty with ID {id} not found.");
            }

            if (clsSpecialty.DeleteSpecialty(id))
            {
                return Ok($"Specialty with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Specialty.");
        }

        [HttpGet("Exists/{id}", Name = "IsSpecialtyExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsSpecialtyExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsSpecialty.IsSpecialtyExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}