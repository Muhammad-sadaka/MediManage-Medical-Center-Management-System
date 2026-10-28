using FluentValidation;
using MediManage_API.Validators;
using MediManage_Business;
using SharedDTOs;
using SharedDTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MediManage_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<clsUserDTO> _userValidator;
        private readonly IValidator<LoginRequestDTO> _loginValidator;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IValidator<clsUserDTO> userValidator,
            IValidator<LoginRequestDTO> loginValidator,
            ILogger<UserController> logger)
        {
            _userValidator = userValidator;
            _loginValidator = loginValidator;
            _logger = logger;
        }

        [Authorize(Roles = "511")]
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

        //[HttpGet("{id}", Name = "GetUserById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<clsUserDTO> GetUserById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest($"Invalid ID {id}");
        //    }

        //    clsUser user = clsUser.Find(id);

        //    if (user == null)
        //    {
        //        return NotFound($"User with ID {id} not found.");
        //    }

        //    return Ok(user.DTO);
        //}

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<clsUserDTO>> GetUserById(int id  , [FromServices] IAuthorizationService authorizationService)
        {
            if (id <= 0)   return BadRequest($"Invalid ID {id}");

            clsUser user = clsUser.Find(id);

            if (user == null)   return NotFound($"User with ID {id} not found.");

            var authResult = await authorizationService.AuthorizeAsync(
               User,
               id,
               "OwnerOrAdmin");

            if (!authResult.Succeeded)
                return Forbid(); 

            return Ok(user.DTO);
        }

        [HttpGet("UserName", Name = "GetUserByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsUserDTO> GetUserByUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest($"Invalid UserName {username}");
            }

            clsUser user = clsUser.Find(username);

            if (user == null)
            {
                return NotFound($"User with UserName {username} not found.");
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

            newDTO.Password = BCrypt.Net.BCrypt.HashPassword(newDTO.Password);

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
            user.Password = BCrypt.Net.BCrypt.HashPassword(updatedDTO.Password);
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
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "unknown";

            if (id < 1)
            {
                _logger.LogWarning(
                    "Admin action blocked (invalid id). AdminId={AdminId}, Action=DeleteUser, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );

                return BadRequest($"Not accepted ID {id}");
            }

            if (!clsUser.IsExist(id))
            {
                _logger.LogWarning(
                    "Admin action failed (target not found). AdminId={AdminId}, Action=DeleteUser, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );

                return NotFound($"User with ID {id} not found.");
            }

            //_logger.LogInformation(
            //   "Admin action started. AdminId={AdminId}, Action=DeleteUser, TargetId={TargetId}, TargetEmail={TargetEmail}, IP={IP}",
            //   adminId,
            //   User.UserID,
            //   User.UserName,
            //   ip
            //);

            if (clsUser.DeleteUser(id))
            {
                _logger.LogInformation(
                    "Admin action succeeded. AdminId={AdminId}, Action=DeleteUser, TargetId={TargetId}, IP={IP}",
                    adminId,
                    id,
                    ip
                );

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

        [HttpPatch("{id}/status", Name = "ChangeUserStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult ChangeUserStatus(int id, [FromQuery] bool isActive)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsUser.IsExist(id))
            {
                return NotFound($"User with ID {id} not found.");
            }

            if (clsUser.ChangeUserStatus(id, isActive))
            {
                return Ok($"User status with ID {id} has been updated successfully.");
            }

            return BadRequest("Failed to update user status.");
        }
    }
}