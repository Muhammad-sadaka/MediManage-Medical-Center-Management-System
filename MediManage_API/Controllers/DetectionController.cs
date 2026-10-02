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
    public class DetectionController : ControllerBase
    {
        private readonly IValidator<clsDetectionDTO> _validator;

        public DetectionController(IValidator<clsDetectionDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllDetections")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsDetectionListDTO>> GetAllDetections()
        {
            List<clsDetectionListDTO> list = clsDetection.GetAllDetections();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Detections Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetDetectionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDetectionDTO> GetDetectionById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsDetection detection = clsDetection.Find(id);

            if (detection == null)
            {
                return NotFound($"Detection with ID {id} not found.");
            }

            return Ok(detection.DTO);
        }

        [HttpPost(Name = "AddDetection")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsDetectionDTO> AddDetection([FromBody] clsDetectionDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsDetection detection = new clsDetection(newDTO, clsDetection.enMode.AddNew);

            if (detection.Save())
            {
                newDTO.DetectionID = detection.DetectionID;
                return CreatedAtRoute("GetDetectionById", new { id = newDTO.DetectionID }, newDTO);
            }

            return BadRequest("Failed to create new Detection.");
        }

        [HttpPut("{id}", Name = "UpdateDetection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDetectionDTO> UpdateDetection(int id, [FromBody] clsDetectionDTO updatedDTO)
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

            clsDetection detection = clsDetection.Find(id);

            if (detection == null)
            {
                return NotFound($"Detection with ID {id} not found.");
            }

            detection.AppointmentID = updatedDTO.AppointmentID;
            detection.CreatedByUserID = updatedDTO.CreatedByUserID;
            detection.Symproms = updatedDTO.Symproms;
            detection.Diagnosis = updatedDTO.Diagnosis;
            detection.Temperature = updatedDTO.Temperature;
            detection.Wight = updatedDTO.Wight;
            detection.BloodPressure = updatedDTO.BloodPressure;
            detection.HeartRate = updatedDTO.HeartRate;
            detection.Notes = updatedDTO.Notes;

            if (detection.Save())
            {
                return Ok(detection.DTO);
            }

            return BadRequest("Failed to update Detection.");
        }

        [HttpDelete("{id}", Name = "DeleteDeleteion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteDetection(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsDetection.IsExist(id))
            {
                return NotFound($"Detection with ID {id} not found.");
            }

            if (clsDetection.DeleteDetection(id))
            {
                return Ok($"Detection with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Detection.");
        }

        [HttpGet("Exists/{id}", Name = "IsDetectionExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsDetectionExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsDetection.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}