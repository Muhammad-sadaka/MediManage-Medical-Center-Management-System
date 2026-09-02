using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsDoctorListDTO>> GetAllDoctors()
        {
            List<clsDoctorListDTO> list = clsDoctor.GetAllDoctors();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Doctors Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetDoctorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDoctorDTO> GetDoctorById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsDoctor doctor = clsDoctor.Find(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }

            return Ok(doctor.DTO);
        }

        [HttpPost(Name = "AddDoctor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsDoctorDTO> AddDoctor(clsDoctorDTO newDTO)
        {
            if (newDTO == null || !newDTO.PersonID.HasValue || !newDTO.SpecialtyID.HasValue)
            {
                return BadRequest("Invalid doctor data.");
            }

            clsDoctor doctor = new clsDoctor(newDTO, clsDoctor.enMode.AddNew);

            if (doctor.Save())
            {
                newDTO.DoctorID = doctor.DoctorID;
                return CreatedAtRoute("GetDoctorById", new { id = newDTO.DoctorID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Doctor.");
            }
        }

        [HttpPut("{id}", Name = "UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDoctorDTO> UpdateDoctor(int id, clsDoctorDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.PersonID.HasValue || !updatedDTO.SpecialtyID.HasValue)
            {
                return BadRequest("Invalid doctor data.");
            }

            clsDoctor doctor = clsDoctor.Find(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }

            doctor.PersonID = updatedDTO.PersonID;
            doctor.YearsOfExperience = updatedDTO.YearsOfExperience;
            doctor.Qualification = updatedDTO.Qualification;
            doctor.IsActive = updatedDTO.IsActive;
            doctor.SpecialtyID = updatedDTO.SpecialtyID;

            if (doctor.Save())
            {
                return Ok(doctor.DTO);
            }
            else
            {
                return BadRequest("Failed to update Doctor.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteDoctor(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsDoctor.DeleteDoctor(id))
            {
                return Ok($"Doctor with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Doctor with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsDoctorExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsDoctorExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsDoctor.IsExist(id))
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