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
    public class AnalysisStatuseController : ControllerBase
    {
        private readonly IValidator<clsAnalysisStatusDTO> _validator;

        // حقن الـ Validator
        public AnalysisStatuseController(IValidator<clsAnalysisStatusDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllAnalysisStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAnalysisStatusDTO>> GetAllAnalysisStatuses()
        {
            List<clsAnalysisStatusDTO> list = clsAnalysisStatus.GetAllAnalysisStatuses();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Analysis Statuses Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetAnalysisStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisStatusDTO> GetAnalysisStatusById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsAnalysisStatus status = clsAnalysisStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Analysis Status with ID {id} not found.");
            }

            return Ok(status.AnalysisStatusDTO);
        }

        [HttpPost(Name = "AddAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsAnalysisStatusDTO> AddAnalysisStatus([FromBody] clsAnalysisStatusDTO newDTO)
        {
            // تنفيذ الـ Validation
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsAnalysisStatus status = new clsAnalysisStatus(newDTO, clsAnalysisStatus.enMode.AddNew);

            if (status.Save())
            {
                newDTO.AnalysisStatusID = status.AnalysisStatusID;
                return CreatedAtRoute("GetAnalysisStatusById", new { id = newDTO.AnalysisStatusID }, newDTO);
            }

            return BadRequest("Failed to create new Analysis Status.");
        }

        [HttpPut("{id}", Name = "UpdateAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisStatusDTO> UpdateAnalysisStatus(int id, [FromBody] clsAnalysisStatusDTO updatedDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            // تنفيذ الـ Validation
            var validationResult = _validator.Validate(updatedDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsAnalysisStatus status = clsAnalysisStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Analysis Status with ID {id} not found.");
            }

            status.AnalysisStatusName = updatedDTO.AnalysisStatusName;

            if (status.Save())
            {
                return Ok(status.AnalysisStatusDTO);
            }

            return BadRequest("Failed to update Analysis Status.");
        }

        [HttpDelete("{id}", Name = "DeleteAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAnalysisStatus(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsAnalysisStatus.IsExist(id))
            {
                return NotFound($"Analysis Status with ID {id} not found.");
            }

            if (clsAnalysisStatus.DeleteAnalysisStatus(id))
            {
                return Ok($"Analysis Status with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Analysis Status.");
        }

        [HttpGet("Exists/{id}", Name = "IsAnalysisStatusExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAnalysisStatusExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisStatus.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}