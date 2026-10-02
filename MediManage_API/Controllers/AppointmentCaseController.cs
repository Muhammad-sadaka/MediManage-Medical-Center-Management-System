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
    public class AppointmentCaseController : ControllerBase
    {
        private readonly IValidator<clsAppointmentCaseDTO> _validator;

        public AppointmentCaseController(IValidator<clsAppointmentCaseDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllAppointmentCases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAppointmentCaseDTO>> GetAllAppointmentCases()
        {
            List<clsAppointmentCaseDTO> list = clsAppointmentCase.GetAllAppointmentCases();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Appointment Cases Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetAppointmentCaseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentCaseDTO> GetAppointmentCaseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsAppointmentCase appointmentCase = clsAppointmentCase.Find(id);

            if (appointmentCase == null)
            {
                return NotFound($"Appointment Case with ID {id} not found.");
            }

            return Ok(appointmentCase.AppointmentCaseDTO);
        }

        [HttpPost(Name = "AddAppointmentCase")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsAppointmentCaseDTO> AddAppointmentCase([FromBody] clsAppointmentCaseDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsAppointmentCase appointmentCase = new clsAppointmentCase(newDTO, clsAppointmentCase.enMode.AddNew);

            if (appointmentCase.Save())
            {
                newDTO.AppointmentCaseID = appointmentCase.AppointmentCaseID;
                return CreatedAtRoute("GetAppointmentCaseById", new { id = newDTO.AppointmentCaseID }, newDTO);
            }

            return BadRequest("Failed to create new Appointment Case.");
        }

        [HttpPut("{id}", Name = "UpdateAppointmentCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentCaseDTO> UpdateAppointmentCase(int id, [FromBody] clsAppointmentCaseDTO updatedDTO)
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

            clsAppointmentCase appointmentCase = clsAppointmentCase.Find(id);

            if (appointmentCase == null)
            {
                return NotFound($"Appointment Case with ID {id} not found.");
            }

            appointmentCase.AppointmentCaseName = updatedDTO.AppointmentCaseName;

            if (appointmentCase.Save())
            {
                return Ok(appointmentCase.AppointmentCaseDTO);
            }

            return BadRequest("Failed to update Appointment Case.");
        }

        [HttpDelete("{id}", Name = "DeleteAppointmentCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAppointmentCase(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsAppointmentCase.IsExist(id))
            {
                return NotFound($"Appointment Case with ID {id} not found.");
            }

            if (clsAppointmentCase.DeleteAppointmentCase(id))
            {
                return Ok($"Appointment Case with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Appointment Case.");
        }

        [HttpGet("Exists/{id}", Name = "IsAppointmentCaseExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAppointmentCaseExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointmentCase.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}