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
    public class AppointmentController : ControllerBase
    {
        private readonly IValidator<clsAppointmentDTO> _validator;

        public AppointmentController(IValidator<clsAppointmentDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAppointmentListDTO>> GetAllAppointments()
        {
            List<clsAppointmentListDTO> list = clsAppointment.GetAllAppointments();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Appointments Found!");
            }
            return Ok(list);
        }

        [HttpGet("Today", Name = "GetTodayAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsTodayAppointmentDTO>> GetTodayAppointments()
        {
            List<clsTodayAppointmentDTO> list = clsAppointment.GetTodayAppointments();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Appointments Found For Today!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetAppointmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentDTO> GetAppointmentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsAppointment appointment = clsAppointment.Find(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            return Ok(appointment.AppointmentDTO);
        }

        [HttpPost(Name = "AddAppointment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsAppointmentDTO> AddAppointment([FromBody] clsAppointmentDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsAppointment appointment = new clsAppointment(newDTO, clsAppointment.enMode.AddNew);

            if (appointment.Save())
            {
                newDTO.AppointmentID = appointment.AppointmentID;
                return CreatedAtRoute("GetAppointmentById", new { id = newDTO.AppointmentID }, newDTO);
            }

            return BadRequest("Failed to create new Appointment.");
        }

        [HttpPut("{id}", Name = "UpdateAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentDTO> UpdateAppointment(int id, [FromBody] clsAppointmentDTO updatedDTO)
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

            clsAppointment appointment = clsAppointment.Find(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            appointment.PatientID = updatedDTO.PatientID;
            appointment.DoctorID = updatedDTO.DoctorID;
            appointment.CreatedByUserID = updatedDTO.CreatedByUserID;
            appointment.BookingDate = updatedDTO.BookingDate;
            appointment.AppointmentDate = updatedDTO.AppointmentDate;
            appointment.AppointmentCaseID = updatedDTO.AppointmentCaseID;
            appointment.Duration = updatedDTO.Duration;
            appointment.Reason = updatedDTO.Reason;
            appointment.Notes = updatedDTO.Notes;

            if (appointment.Save())
            {
                return Ok(appointment.AppointmentDTO);
            }

            return BadRequest("Failed to update Appointment.");
        }

        [HttpDelete("{id}", Name = "DeleteAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAppointment(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsAppointment.IsExist(id))
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            if (clsAppointment.DeleteAppointment(id))
            {
                return Ok($"Appointment with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Appointment.");
        }

        [HttpGet("Exists/{id}", Name = "IsAppointmentExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAppointmentExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointment.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}