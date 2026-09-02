using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCaseController : ControllerBase
    {
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
            if (id < 1)
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
        public ActionResult<clsPatientCaseDTO> AddPatientCase(clsPatientCaseDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.PatientCaseName))
            {
                return BadRequest("Invalid patient case data.");
            }

            clsPatientCase patientCase = new clsPatientCase(newDTO, clsPatientCase.enMode.AddNew);

            if (patientCase.Save())
            {
                newDTO.PatientCaseID = patientCase.PatientCaseID;
                return CreatedAtRoute("GetPatientCaseById", new { id = newDTO.PatientCaseID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Patient Case.");
            }
        }

        [HttpPut("{id}", Name = "UpdatePatientCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientCaseDTO> UpdatePatientCase(int id, clsPatientCaseDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.PatientCaseName))
            {
                return BadRequest("Invalid patient case data.");
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
            else
            {
                return BadRequest("Failed to update Patient Case.");
            }
        }

        [HttpDelete("{id}", Name = "DeletePatientCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePatientCase(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatientCase.DeletePatientCase(id))
            {
                return Ok($"Patient Case with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Patient Case with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsPatientCaseExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPatientCaseExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatientCase.IsExist(id))
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