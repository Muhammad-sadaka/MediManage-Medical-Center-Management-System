using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAppointmentDTO>> GetAllAppointments()
        {
            List<clsAppointmentDTO> list = clsAppointment.GetAllAppointments();
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
            if (id < 1)
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
        public ActionResult<clsAppointmentDTO> AddAppointment(clsAppointmentDTO newDTO)
        {
            if (newDTO == null || !newDTO.PatientID.HasValue || !newDTO.DoctorID.HasValue || !newDTO.AppointmentDate.HasValue)
            {
                return BadRequest("Invalid appointment data.");
            }

            clsAppointment appointment = new clsAppointment(newDTO, clsAppointment.enMode.AddNew);

            if (appointment.Save())
            {
                newDTO.AppointmentID = appointment.AppointmentID;
                return CreatedAtRoute("GetAppointmentById", new { id = newDTO.AppointmentID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Appointment.");
            }
        }

        [HttpPut("{id}", Name = "UpdateAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentDTO> UpdateAppointment(int id, clsAppointmentDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.PatientID.HasValue || !updatedDTO.DoctorID.HasValue || !updatedDTO.AppointmentDate.HasValue)
            {
                return BadRequest("Invalid appointment data.");
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
            else
            {
                return BadRequest("Failed to update Appointment.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAppointment(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointment.DeleteAppointment(id))
            {
                return Ok($"Appointment with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Appointment with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsAppointmentExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAppointmentExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointment.IsExist(id))
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