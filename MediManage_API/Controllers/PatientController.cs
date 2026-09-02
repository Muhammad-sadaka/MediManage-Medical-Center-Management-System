using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
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
            if (id < 1)
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

        [HttpPost(Name = "AddPatient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPatientDTO> AddPatient(clsPatientDTO newDTO)
        {
            if (newDTO == null || !newDTO.PersonID.HasValue)
            {
                return BadRequest("Invalid patient data.");
            }

            clsPatient patient = new clsPatient(newDTO, clsPatient.enMode.AddNew);

            if (patient.Save())
            {
                newDTO.PatientID = patient.PatientID;
                return CreatedAtRoute("GetPatientById", new { id = newDTO.PatientID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Patient.");
            }
        }

        [HttpPut("{id}", Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPatientDTO> UpdatePatient(int id, clsPatientDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.PersonID.HasValue)
            {
                return BadRequest("Invalid patient data.");
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
            else
            {
                return BadRequest("Failed to update Patient.");
            }
        }

        [HttpDelete("{id}", Name = "DeletePatient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePatient(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatient.DeletePatient(id))
            {
                return Ok($"Patient with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Patient with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsPatientExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPatientExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPatient.IsExist(id))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
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