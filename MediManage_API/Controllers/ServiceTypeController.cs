using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllServiceTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsServiceTypeDTO>> GetAllServiceTypes()
        {
            List<clsServiceTypeDTO> list = clsServiceType.GetAllServiceTypes();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Service Types Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetServiceTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsServiceTypeDTO> GetServiceTypeById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsServiceType serviceType = clsServiceType.Find(id);

            if (serviceType == null)
            {
                return NotFound($"Service Type with ID {id} not found.");
            }

            return Ok(serviceType.DTO);
        }

        [HttpPost(Name = "AddServiceType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsServiceTypeDTO> AddServiceType(clsServiceTypeDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.ServicTypeName))
            {
                return BadRequest("Invalid service type data.");
            }

            clsServiceType serviceType = new clsServiceType(newDTO, clsServiceType.enMode.AddNew);

            if (serviceType.Save())
            {
                newDTO.ServiceTypeID = serviceType.ServiceTypeID;
                return CreatedAtRoute("GetServiceTypeById", new { id = newDTO.ServiceTypeID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Service Type.");
            }
        }

        [HttpPut("{id}", Name = "UpdateServiceType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsServiceTypeDTO> UpdateServiceType(int id, clsServiceTypeDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.ServicTypeName))
            {
                return BadRequest("Invalid service type data.");
            }

            clsServiceType serviceType = clsServiceType.Find(id);

            if (serviceType == null)
            {
                return NotFound($"Service Type with ID {id} not found.");
            }

            serviceType.ServicTypeName = updatedDTO.ServicTypeName;

            if (serviceType.Save())
            {
                return Ok(serviceType.DTO);
            }
            else
            {
                return BadRequest("Failed to update Service Type.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteServiceType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteServiceType(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsServiceType.DeleteServiceType(id))
            {
                return Ok($"Service Type with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Service Type with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsServiceTypeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsServiceTypeExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsServiceType.IsServiceTypeExist(id))
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