using FluentValidation;
using MediManage_API.Validators;
using MediManage_Business;
using MediManage_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<clsUserDTO> _userValidator;
        private readonly IValidator<LoginRequestDTO> _loginValidator;

        public UserController(IValidator<clsUserDTO> userValidator, IValidator<LoginRequestDTO> loginValidator)
        {
            _userValidator = userValidator;
            _loginValidator = loginValidator;
        }

        private static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        [HttpGet("All", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsUsersListDTO>> GetAllUsers()
        {
            List<clsUsersListDTO> list = clsUser.GetAllUsers();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Users Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsUserDTO> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsUser user = clsUser.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user.DTO);
        }

        [HttpPost("Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<clsUserDTO> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var validationResult = _loginValidator.Validate(loginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            string hashedPassword = ComputeHash(loginRequest.Password);
            clsUser user = clsUser.FindByUsernameAndPassword(loginRequest.UserName, hashedPassword);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(user.DTO);
        }

        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> AddUser([FromBody] clsUserDTO newDTO)
        {
            var validationResult = _userValidator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // Hash the password before saving
            newDTO.Password = ComputeHash(newDTO.Password);

            clsUser user = new clsUser(newDTO, clsUser.enMode.AddNew);

            if (user.Save())
            {
                newDTO.UserID = user.UserID;
                return CreatedAtRoute("GetUserById", new { id = newDTO.UserID }, newDTO);
            }

            return BadRequest("Failed to create new User.");
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsUserDTO> UpdateUser(int id, [FromBody] clsUserDTO updatedDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            var validationResult = _userValidator.Validate(updatedDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsUser user = clsUser.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            user.PersonID = updatedDTO.PersonID;
            user.UserName = updatedDTO.UserName;
            user.Password = ComputeHash(updatedDTO.Password);
            user.Permissions = updatedDTO.Permissions;
            user.IsActive = updatedDTO.IsActive;

            if (user.Save())
            {
                return Ok(user.DTO);
            }

            return BadRequest("Failed to update User.");
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsUser.IsExist(id))
            {
                return NotFound($"User with ID {id} not found.");
            }

            if (clsUser.DeleteUser(id))
            {
                return Ok($"User with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete User.");
        }

        [HttpGet("Exists/{id}", Name = "IsUserExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsUserExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsUser.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Exists/by-national-no/{NationalNo}", Name = "IsUserExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsUserExistByNationalNo(string NationalNo)
        {
            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                return BadRequest("National Number cannot be empty.");
            }

            if (clsUser.IsExist(NationalNo))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}