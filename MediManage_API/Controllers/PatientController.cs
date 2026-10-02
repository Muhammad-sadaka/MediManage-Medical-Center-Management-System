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
    public class PatientController : ControllerBase
    {
        private readonly IValidator<clsPatientDTO> _validator;

        public PatientController(IValidator<clsPatientDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllPatients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPatientsListDTO>> GetAllPatients()
        {
            List<clsPatientsListDTO> list = clsPatient.GetAllPatients();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Patients Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientDTO> GetPatientById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPatient patient = clsPatient.Find(id);

            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            return Ok(patient.DTO);
        }

        [HttpGet("by-person/{personId}", Name = "GetPatientByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientDTO> GetPatientByPersonID(int personId)
        {
            if (personId <= 0)
            {
                return BadRequest($"Invalid Person ID {personId}");
            }

            clsPatient patient = clsPatient.FindByPersonID(personId);

            if (patient == null)
            {
                return NotFound($"Patient with Person ID {personId} not found.");
            }

            return Ok(patient.DTO);
        }

        [HttpGet("by-national-no/{nationalNo}", Name = "GetPatientByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientDTO> GetPatientByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("National No cannot be empty.");
            }

            clsPatient patient = clsPatient.Find(nationalNo);

            if (patient == null)
            {
                return NotFound($"Patient with National No '{nationalNo}' not found.");
            }

            return Ok(patient.DTO);
        }

        [HttpPost(Name = "AddPatient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPatientDTO> AddPatient([FromBody] clsPatientDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPatient patient = new clsPatient(newDTO, clsPatient.enMode.AddNew);

            if (patient.Save())
            {
                newDTO.PatientID = patient.PatientID;
                return CreatedAtRoute("GetPatientById", new { id = newDTO.PatientID }, newDTO);
            }

            return BadRequest("Failed to create new Patient.");
        }

        [HttpPut("{id}", Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientDTO> UpdatePatient(int id, [FromBody] clsPatientDTO updatedDTO)
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

            clsPatient patient = clsPatient.Find(id);

            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            patient.PersonID = updatedDTO.PersonID;
            patient.Sensitivity = updatedDTO.Sensitivity;
            patient.ChronicDiseases = updatedDTO.ChronicDiseases;
            patient.JoinDate = updatedDTO.JoinDate;
            patient.PatientCaseID = updatedDTO.PatientCaseID;

            if (patient.Save())
            {
                return Ok(patient.DTO);
            }

            return BadRequest("Failed to update Patient.");
        }

        [HttpDelete("{id}", Name = "DeletePatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePatient(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPatient.IsExist(id))
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            if (clsPatient.DeletePatient(id))
            {
                return Ok($"Patient with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Patient.");
        }

        [HttpGet("Exists/{id}", Name = "IsPatientExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPatientExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatient.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Exists/by-national-no/{nationalNo}", Name = "IsPatientExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPatientExistByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("National No cannot be empty.");
            }

            if (clsPatient.IsExist(nationalNo))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Count", Name = "GetTotalPatientsNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetTotalPatientsNumber()
        {
            int? count = clsPatient.GetTotalPatientsNumber();
            if (!count.HasValue)
            {
                return NotFound("Could not retrieve patients count.");
            }

            return Ok(count.Value);
        }
    }
}