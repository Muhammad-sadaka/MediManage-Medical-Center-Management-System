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
    public class PersonController : ControllerBase
    {
        private readonly IValidator<clsPersonDTO> _validator;

        public PersonController(IValidator<clsPersonDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPersonListDTO>> GetAllPeople()
        {
            List<clsPersonListDTO> list = clsPerson.GetAllPeople();
            if (list == null || list.Count == 0)
            {
                return NotFound("No People Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> GetPersonById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPerson person = clsPerson.Find(id);

            if (person == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }

            return Ok(person.DTO);
        }

        [HttpGet("by-national-no/{nationalNo}", Name = "GetPersonByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> GetPersonByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("National No cannot be empty.");
            }

            clsPerson person = clsPerson.Find(nationalNo);

            if (person == null)
            {
                return NotFound($"Person with National No '{nationalNo}' not found.");
            }

            return Ok(person.DTO);
        }

        [HttpPost(Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPersonDTO> AddPerson([FromBody] clsPersonDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPerson person = new clsPerson(newDTO, clsPerson.enMode.AddNew);

            if (person.Save())
            {
                newDTO.PersonID = person.PersonID;
                return CreatedAtRoute("GetPersonById", new { id = newDTO.PersonID }, newDTO);
            }

            return BadRequest("Failed to create new Person.");
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> UpdatePerson(int id, [FromBody] clsPersonDTO updatedDTO)
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

            clsPerson person = clsPerson.Find(id);

            if (person == null)
            {
                return NotFound($"Person with ID {id} not found.");
            }

            person.FirstName = updatedDTO.FirstName;
            person.SecondName = updatedDTO.SecondName;
            person.ThirdName = updatedDTO.ThirdName;
            person.LastName = updatedDTO.LastName;
            person.NationalNo = updatedDTO.NationalNo;
            person.Phone = updatedDTO.Phone;
            person.DateOfBirth = updatedDTO.DateOfBirth;
            person.Gender = updatedDTO.Gender;
            person.Image = updatedDTO.Image;
            person.Address = updatedDTO.Address;
            person.Email = updatedDTO.Email;
            person.BloodTypeID = updatedDTO.BloodTypeID;
            person.MaritalStatusID = updatedDTO.MaritalStatusID;
            person.CountryId = updatedDTO.CountryId;

            if (person.Save())
            {
                return Ok(person.DTO);
            }

            return BadRequest("Failed to update Person.");
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPerson.IsExist(id))
            {
                return NotFound($"Person with ID {id} not found.");
            }

            if (clsPerson.DeletePerson(id))
            {
                return Ok($"Person with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Person.");
        }

        [HttpGet("Exists/{id}", Name = "IsPersonExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPersonExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPerson.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Exists/by-national-no/{nationalNo}", Name = "IsPersonExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPersonExistByNationalNo(string nationalNo)
        {
            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                return BadRequest("National No cannot be empty.");
            }

            if (clsPerson.IsExist(nationalNo))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}