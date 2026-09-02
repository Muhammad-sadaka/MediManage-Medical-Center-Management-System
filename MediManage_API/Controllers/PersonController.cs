using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPersonDTO>> GetAllPeople()
        {
            List<clsPersonDTO> list = clsPerson.GetAllPeople();
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
            if (id < 1)
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

        [HttpGet("{NationalNo}", Name = "GetPersonByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> GetPersonByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
            {
                return BadRequest($"Invalid NationalNo {NationalNo}");
            }

            clsPerson person = clsPerson.Find(NationalNo);

            if (person == null)
            {
                return NotFound($"Person with NationalNo {NationalNo} not found.");
            }

            return Ok(person.DTO);
        }

        [HttpPost(Name = "AddPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPersonDTO> AddPerson(clsPersonDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.FirstName) || string.IsNullOrEmpty(newDTO.LastName))
            {
                return BadRequest("Invalid person data.");
            }

            clsPerson person = new clsPerson(newDTO, clsPerson.enMode.AddNew);

            if (person.Save())
            {
                newDTO.PersonID = person.PersonID;
                return CreatedAtRoute("GetPersonById", new { id = newDTO.PersonID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Person.");
            }
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPersonDTO> UpdatePerson(int id, clsPersonDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.FirstName) || string.IsNullOrEmpty(updatedDTO.LastName))
            {
                return BadRequest("Invalid person data.");
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
            else
            {
                return BadRequest("Failed to update Person.");
            }
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePerson(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPerson.DeletePerson(id))
            {
                return Ok($"Person with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Person with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsPersonExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPersonExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPerson.IsExist(id))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }

        [HttpGet("Exists/{NationalNo}", Name = "IsPersonExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPersonExistByNationalNo(string NationalNo)
        {
            if (string.IsNullOrEmpty(NationalNo))
            {
                return BadRequest($"Invalid NationalNo {NationalNo}");
            }

            if (clsPerson.IsExist(NationalNo))
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