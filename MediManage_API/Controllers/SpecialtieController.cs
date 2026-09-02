using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtieController : ControllerBase
    {
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
            if (id < 1)
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

        [HttpPost(Name = "AddSpecialty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsSpecialtyDTO> AddSpecialty(clsSpecialtyDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.SpecialtyName) || !newDTO.Fees.HasValue)
            {
                return BadRequest("Invalid specialty data.");
            }

            clsSpecialty specialty = new clsSpecialty(newDTO, clsSpecialty.enMode.AddNew);

            if (specialty.Save())
            {
                newDTO.SpecialtyID = specialty.SpecialtyID;
                return CreatedAtRoute("GetSpecialtyById", new { id = newDTO.SpecialtyID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Specialty.");
            }
        }

        [HttpPut("{id}", Name = "UpdateSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsSpecialtyDTO> UpdateSpecialty(int id, clsSpecialtyDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.SpecialtyName) || !updatedDTO.Fees.HasValue)
            {
                return BadRequest("Invalid specialty data.");
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
            else
            {
                return BadRequest("Failed to update Specialty.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteSpecialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteSpecialty(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsSpecialty.DeleteSpecialty(id))
            {
                return Ok($"Specialty with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Specialty with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsSpecialtyExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsSpecialtyExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsSpecialty.IsSpecialtyExist(id))
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