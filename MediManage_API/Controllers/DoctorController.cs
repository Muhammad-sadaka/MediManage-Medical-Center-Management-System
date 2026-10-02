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
    public class DoctorController : ControllerBase
    {
        private readonly IValidator<clsDoctorDTO> _validator;

        public DoctorController(IValidator<clsDoctorDTO> validator)
        {
            _validator = validator;
        }

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

        [HttpGet("DoctorsNames", Name = "GetAllDoctorsNames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<string>> GetAllDoctorsNames()
        {
            List<string> list = clsDoctor.GetAllDoctorsNames();
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
            if (id <= 0)
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

        [HttpGet("ByPerson/{personId}", Name = "GetDoctorByPersonID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDoctorDTO> FindByPersonID(int personId)
        {
            if (personId <= 0)
            {
                return BadRequest($"Invalid Person ID {personId}");
            }

            clsDoctor doctor = clsDoctor.FindByPersonID(personId);

            if (doctor == null)
            {
                return NotFound($"Doctor with Person ID {personId} not found.");
            }

            return Ok(doctor.DTO);
        }

        [HttpGet("ByNationalNo/{nationalNo}", Name = "GetDoctorByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDoctorDTO> GetDoctorByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("Invalid National No.");
            }

            clsDoctor doctor = clsDoctor.Find(nationalNo);

            if (doctor == null)
            {
                return NotFound($"Doctor with National No {nationalNo} not found.");
            }

            return Ok(doctor.DTO);
        }

        [HttpPost(Name = "AddDoctor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsDoctorDTO> AddDoctor([FromBody] clsDoctorDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsDoctor doctor = new clsDoctor(newDTO, clsDoctor.enMode.AddNew);

            if (doctor.Save())
            {
                newDTO.DoctorID = doctor.DoctorID;
                return CreatedAtRoute("GetDoctorById", new { id = newDTO.DoctorID }, newDTO);
            }

            return BadRequest("Failed to create new Doctor.");
        }

        [HttpPut("{id}", Name = "UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsDoctorDTO> UpdateDoctor(int id, [FromBody] clsDoctorDTO updatedDTO)
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
            doctor.LicenseNo = updatedDTO.LicenseNo;

            if (doctor.Save())
            {
                return Ok(doctor.DTO);
            }

            return BadRequest("Failed to update Doctor.");
        }

        [HttpDelete("{id}", Name = "DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteDoctor(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsDoctor.IsExist(id))
            {
                return NotFound($"Doctor with ID {id} not found.");
            }

            if (clsDoctor.DeleteDoctor(id))
            {
                return Ok($"Doctor with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Doctor.");
        }

        [HttpGet("Exists/{id}", Name = "IsDoctorExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsDoctorExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsDoctor.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Exists/NationalNo/{nationalNo}", Name = "IsDoctorExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsDoctorExistByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("Invalid National No.");
            }

            if (clsDoctor.IsExist(nationalNo))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}