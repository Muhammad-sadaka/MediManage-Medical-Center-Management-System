using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentCaseController : ControllerBase
    {
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
            if (id < 1)
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
        public ActionResult<clsAppointmentCaseDTO> AddAppointmentCase(clsAppointmentCaseDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.AppointmentCaseName))
            {
                return BadRequest("Invalid appointment case data.");
            }

            clsAppointmentCase appointmentCase = new clsAppointmentCase(newDTO, clsAppointmentCase.enMode.AddNew);

            if (appointmentCase.Save())
            {
                newDTO.AppointmentCaseID = appointmentCase.AppointmentCaseID;
                return CreatedAtRoute("GetAppointmentCaseById", new { id = newDTO.AppointmentCaseID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Appointment Case.");
            }
        }

        [HttpPut("{id}", Name = "UpdateAppointmentCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAppointmentCaseDTO> UpdateAppointmentCase(int id, clsAppointmentCaseDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.AppointmentCaseName))
            {
                return BadRequest("Invalid appointment case data.");
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
            else
            {
                return BadRequest("Failed to update Appointment Case.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteAppointmentCase")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAppointmentCase(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointmentCase.DeleteAppointmentCase(id))
            {
                return Ok($"Appointment Case with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Appointment Case with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsAppointmentCaseExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAppointmentCaseExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAppointmentCase.IsExist(id))
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