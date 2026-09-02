using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsCountryDTO>> GetAllCountries()
        {
            List<clsCountryDTO> list = clsCountry.GetAllCountries();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Countries Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetCountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCountryDTO> GetCountryById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsCountry country = clsCountry.Find(id);

            if (country == null)
            {
                return NotFound($"Country with ID {id} not found.");
            }

            return Ok(country.CountryDTO);
        }

        [HttpPost(Name = "AddCountry")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsCountryDTO> AddCountry(clsCountryDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.CountryName))
            {
                return BadRequest("Invalid country data.");
            }

            clsCountry country = new clsCountry(newDTO, clsCountry.enMode.AddNew);

            if (country.Save())
            {
                newDTO.CountryID = country.CountryID;
                return CreatedAtRoute("GetCountryById", new { id = newDTO.CountryID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Country.");
            }
        }

        [HttpPut("{id}", Name = "UpdateCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsCountryDTO> UpdateCountry(int id, clsCountryDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.CountryName))
            {
                return BadRequest("Invalid country data.");
            }

            clsCountry country = clsCountry.Find(id);

            if (country == null)
            {
                return NotFound($"Country with ID {id} not found.");
            }

            country.CountryName = updatedDTO.CountryName;

            if (country.Save())
            {
                return Ok(country.CountryDTO);
            }
            else
            {
                return BadRequest("Failed to update Country.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCountry(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsCountry.DeleteCountry(id))
            {
                return Ok($"Country with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Country with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsCountryExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsCountryExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsCountry.IsExist(id))
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