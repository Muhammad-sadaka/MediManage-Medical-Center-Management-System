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
    public class MedicalPrescriptionController : ControllerBase
    {
        private readonly IValidator<clsMedicalPrescriptionDTO> _validator;

        public MedicalPrescriptionController(IValidator<clsMedicalPrescriptionDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllMedicalPrescriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicalPrescriptionsListDTO>> GetAllMedicalPrescriptions()
        {
            List<clsMedicalPrescriptionsListDTO> list = clsMedicalPrescription.GetAllMedicalPrescriptions();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Medical Prescriptions Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMedicalPrescriptionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicalPrescriptionDTO> GetMedicalPrescriptionById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMedicalPrescription prescription = clsMedicalPrescription.Find(id);

            if (prescription == null)
            {
                return NotFound($"Medical Prescription with ID {id} not found.");
            }

            return Ok(prescription.DTO);
        }

        [HttpPost(Name = "AddMedicalPrescription")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMedicalPrescriptionDTO> AddMedicalPrescription([FromBody] clsMedicalPrescriptionDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsMedicalPrescription prescription = new clsMedicalPrescription(newDTO, clsMedicalPrescription.enMode.AddNew);

            if (prescription.Save())
            {
                newDTO.MedicalPrescriptionID = prescription.MedicalPrescriptionID;
                return CreatedAtRoute("GetMedicalPrescriptionById", new { id = newDTO.MedicalPrescriptionID }, newDTO);
            }

            return BadRequest("Failed to create new Medical Prescription.");
        }

        [HttpPut("{id}", Name = "UpdateMedicalPrescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicalPrescriptionDTO> UpdateMedicalPrescription(int id, [FromBody] clsMedicalPrescriptionDTO updatedDTO)
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

            clsMedicalPrescription prescription = clsMedicalPrescription.Find(id);

            if (prescription == null)
            {
                return NotFound($"Medical Prescription with ID {id} not found.");
            }

            prescription.DetectionID = updatedDTO.DetectionID;
            prescription.Notes = updatedDTO.Notes;
            prescription.PrescriptionDate = updatedDTO.PrescriptionDate;

            if (prescription.Save())
            {
                return Ok(prescription.DTO);
            }

            return BadRequest("Failed to update Medical Prescription.");
        }

        [HttpDelete("{id}", Name = "DeleteMedicalPrescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicalPrescription(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsMedicalPrescription.IsExist(id))
            {
                return NotFound($"Medical Prescription with ID {id} not found.");
            }

            if (clsMedicalPrescription.DeleteMedicalPrescription(id))
            {
                return Ok($"Medical Prescription with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Medical Prescription.");
        }

        [HttpGet("Exists/{id}", Name = "IsMedicalPrescriptionExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicalPrescriptionExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicalPrescription.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}