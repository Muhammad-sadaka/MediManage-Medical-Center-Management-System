using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalStatuseController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllMaritalStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMaritalStatusDTO>> GetAllMaritalStatuses()
        {
            List<clsMaritalStatusDTO> list = clsMaritalStatus.GetAllMaritalStatuses();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Marital Statuses Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMaritalStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMaritalStatusDTO> GetMaritalStatusById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMaritalStatus status = clsMaritalStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Marital Status with ID {id} not found.");
            }

            return Ok(status.DTO);
        }

        [HttpPost(Name = "AddMaritalStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMaritalStatusDTO> AddMaritalStatus(clsMaritalStatusDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.MaritalStatusName))
            {
                return BadRequest("Invalid marital status data.");
            }

            clsMaritalStatus status = new clsMaritalStatus(newDTO, clsMaritalStatus.enMode.AddNew);

            if (status.Save())
            {
                newDTO.MaritalStatusID = status.MaritalStatusID;
                return CreatedAtRoute("GetMaritalStatusById", new { id = newDTO.MaritalStatusID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Marital Status.");
            }
        }

        [HttpPut("{id}", Name = "UpdateMaritalStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMaritalStatusDTO> UpdateMaritalStatus(int id, clsMaritalStatusDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.MaritalStatusName))
            {
                return BadRequest("Invalid marital status data.");
            }

            clsMaritalStatus status = clsMaritalStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Marital Status with ID {id} not found.");
            }

            status.MaritalStatusName = updatedDTO.MaritalStatusName;

            if (status.Save())
            {
                return Ok(status.DTO);
            }
            else
            {
                return BadRequest("Failed to update Marital Status.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMaritalStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMaritalStatus(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMaritalStatus.DeleteMaritalStatus(id))
            {
                return Ok($"Marital Status with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Marital Status with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsMaritalStatusExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMaritalStatusExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMaritalStatus.IsExist(id))
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