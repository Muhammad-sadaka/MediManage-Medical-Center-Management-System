using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisTypeController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllAnalysisTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAnalysisTypeDTO>> GetAllAnalysisTypes()
        {
            List<clsAnalysisTypeDTO> list = clsAnalysisType.GetAllAnalysisTypes();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Analysis Types Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetAnalysisTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisTypeDTO> GetAnalysisTypeById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsAnalysisType type = clsAnalysisType.Find(id);

            if (type == null)
            {
                return NotFound($"Analysis Type with ID {id} not found.");
            }

            return Ok(type.AnalysisTypeDTO);
        }

        [HttpPost(Name = "AddAnalysisType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsAnalysisTypeDTO> AddAnalysisType(clsAnalysisTypeDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.AnalysisTypeName) || !newDTO.Price.HasValue || newDTO.Price < 0)
            {
                return BadRequest("Invalid analysis type data.");
            }

            clsAnalysisType type = new clsAnalysisType(newDTO, clsAnalysisType.enMode.AddNew);

            if (type.Save())
            {
                newDTO.AnalysisTypeID = type.AnalysisTypeID;
                return CreatedAtRoute("GetAnalysisTypeById", new { id = newDTO.AnalysisTypeID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Analysis Type.");
            }
        }

        [HttpPut("{id}", Name = "UpdateAnalysisType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisTypeDTO> UpdateAnalysisType(int id, clsAnalysisTypeDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.AnalysisTypeName) || !updatedDTO.Price.HasValue || updatedDTO.Price < 0)
            {
                return BadRequest("Invalid analysis type data.");
            }

            clsAnalysisType type = clsAnalysisType.Find(id);

            if (type == null)
            {
                return NotFound($"Analysis Type with ID {id} not found.");
            }

            type.AnalysisTypeName = updatedDTO.AnalysisTypeName;
            type.Price = updatedDTO.Price;

            if (type.Save())
            {
                return Ok(type.AnalysisTypeDTO);
            }
            else
            {
                return BadRequest("Failed to update Analysis Type.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteAnalysisType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAnalysisType(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisType.DeleteAnalysisType(id))
            {
                return Ok($"Analysis Type with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Analysis Type with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsAnalysisTypeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAnalysisTypeExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisType.IsExist(id))
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