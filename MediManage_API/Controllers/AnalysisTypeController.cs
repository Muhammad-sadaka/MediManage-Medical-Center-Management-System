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
    public class AnalysisTypeController : ControllerBase
    {
        private readonly IValidator<clsAnalysisTypeDTO> _validator;

        public AnalysisTypeController(IValidator<clsAnalysisTypeDTO> validator)
        {
            _validator = validator;
        }

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
            if (id <= 0)
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
        public ActionResult<clsAnalysisTypeDTO> AddAnalysisType([FromBody] clsAnalysisTypeDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsAnalysisType type = new clsAnalysisType(newDTO, clsAnalysisType.enMode.AddNew);

            if (type.Save())
            {
                newDTO.AnalysisTypeID = type.AnalysisTypeID;
                return CreatedAtRoute("GetAnalysisTypeById", new { id = newDTO.AnalysisTypeID }, newDTO);
            }

            return BadRequest("Failed to create new Analysis Type.");
        }

        [HttpPut("{id}", Name = "UpdateAnalysisType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisTypeDTO> UpdateAnalysisType(int id, [FromBody] clsAnalysisTypeDTO updatedDTO)
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

            return BadRequest("Failed to update Analysis Type.");
        }

        [HttpDelete("{id}", Name = "DeleteAnalysisType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAnalysisType(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsAnalysisType.IsExist(id))
            {
                return NotFound($"Analysis Type with ID {id} not found.");
            }

            if (clsAnalysisType.DeleteAnalysisType(id))
            {
                return Ok($"Analysis Type with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Analysis Type.");
        }

        [HttpGet("Exists/{id}", Name = "IsAnalysisTypeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAnalysisTypeExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisType.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}