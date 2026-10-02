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
    public class PatientCaseController : ControllerBase
    {
        private readonly IValidator<clsPatientCaseDTO> _validator;

        public PatientCaseController(IValidator<clsPatientCaseDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllPatientCases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPatientCaseDTO>> GetAllPatientCases()
        {
            List<clsPatientCaseDTO> list = clsPatientCase.GetAllPatientCases();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Patient Cases Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPatientCaseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientCaseDTO> GetPatientCaseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPatientCase patientCase = clsPatientCase.Find(id);

            if (patientCase == null)
            {
                return NotFound($"Patient Case with ID {id} not found.");
            }

            return Ok(patientCase.DTO);
        }

        [HttpPost(Name = "AddPatientCase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPatientCaseDTO> AddPatientCase([FromBody] clsPatientCaseDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPatientCase patientCase = new clsPatientCase(newDTO, clsPatientCase.enMode.AddNew);

            if (patientCase.Save())
            {
                newDTO.PatientCaseID = patientCase.PatientCaseID;
                return CreatedAtRoute("GetPatientCaseById", new { id = newDTO.PatientCaseID }, newDTO);
            }

            return BadRequest("Failed to create new Patient Case.");
        }

        [HttpPut("{id}", Name = "UpdatePatientCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientCaseDTO> UpdatePatientCase(int id, [FromBody] clsPatientCaseDTO updatedDTO)
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

            clsPatientCase patientCase = clsPatientCase.Find(id);

            if (patientCase == null)
            {
                return NotFound($"Patient Case with ID {id} not found.");
            }

            patientCase.PatientCaseName = updatedDTO.PatientCaseName;

            if (patientCase.Save())
            {
                return Ok(patientCase.DTO);
            }

            return BadRequest("Failed to update Patient Case.");
        }

        [HttpDelete("{id}", Name = "DeletePatientCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePatientCase(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPatientCase.IsExist(id))
            {
                return NotFound($"Patient Case with ID {id} not found.");
            }

            if (clsPatientCase.DeletePatientCase(id))
            {
                return Ok($"Patient Case with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Patient Case.");
        }

        [HttpGet("Exists/{id}", Name = "IsPatientCaseExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPatientCaseExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatientCase.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}