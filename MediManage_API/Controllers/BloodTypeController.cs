using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllBloodTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsBloodTypeDTO>> GetAllBloodTypes()
        {
            List<clsBloodTypeDTO> list = clsBloodType.GetAllBloodTypes();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Blood Types Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBloodTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBloodTypeDTO> GetBloodTypeById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsBloodType bloodType = clsBloodType.Find(id);

            if (bloodType == null)
            {
                return NotFound($"Blood Type with ID {id} not found.");
            }

            return Ok(bloodType.BloodTypeDTO);
        }

        [HttpPost(Name = "AddBloodType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsBloodTypeDTO> AddBloodType(clsBloodTypeDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.BloodTypeSymbol))
            {
                return BadRequest("Invalid blood type data.");
            }

            clsBloodType bloodType = new clsBloodType(newDTO, clsBloodType.enMode.AddNew);

            if (bloodType.Save())
            {
                newDTO.BloodTypeID = bloodType.BloodTypeID;
                return CreatedAtRoute("GetBloodTypeById", new { id = newDTO.BloodTypeID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Blood Type.");
            }
        }

        [HttpPut("{id}", Name = "UpdateBloodType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBloodTypeDTO> UpdateBloodType(int id, clsBloodTypeDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.BloodTypeSymbol))
            {
                return BadRequest("Invalid blood type data.");
            }

            clsBloodType bloodType = clsBloodType.Find(id);

            if (bloodType == null)
            {
                return NotFound($"Blood Type with ID {id} not found.");
            }

            bloodType.BloodTypeSymbol = updatedDTO.BloodTypeSymbol;

            if (bloodType.Save())
            {
                return Ok(bloodType.BloodTypeDTO);
            }
            else
            {
                return BadRequest("Failed to update Blood Type.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteBloodType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBloodType(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBloodType.DeleteBloodType(id))
            {
                return Ok($"Blood Type with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Blood Type with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsBloodTypeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsBloodTypeExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBloodType.IsExist(id))
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