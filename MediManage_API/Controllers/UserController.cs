using MediManage_Business;
using MediManage_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //temp for testing purpose only
        public static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
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
            if (id < 1)
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsUserDTO> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username and password are required.");
            }
            
            clsUser user = clsUser.FindByUsernameAndPassword(userName, ComputeHash(password));

            if (user == null)
            {
                return NotFound("Invalid username or password.");
            }

            return Ok(user.DTO);
        }

        [HttpPost(Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsUserDTO> AddUser(clsUserDTO newDTO)
        {
            if (newDTO == null || !newDTO.PersonID.HasValue || string.IsNullOrEmpty(newDTO.UserName) || string.IsNullOrEmpty(newDTO.Password))
            {
                return BadRequest("Invalid user data.");
            }

            clsUser user = new clsUser(newDTO, clsUser.enMode.AddNew);

            if (user.Save())
            {
                newDTO.UserID = user.UserID;
                return CreatedAtRoute("GetUserById", new { id = newDTO.UserID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new User.");
            }
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsUserDTO> UpdateUser(int id, clsUserDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.PersonID.HasValue || string.IsNullOrEmpty(updatedDTO.UserName) || string.IsNullOrEmpty(updatedDTO.Password))
            {
                return BadRequest("Invalid user data.");
            }

            clsUser user = clsUser.Find(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            user.PersonID = updatedDTO.PersonID;
            user.UserName = updatedDTO.UserName;
            user.Password = updatedDTO.Password;
            user.Permissions = updatedDTO.Permissions;
            user.IsActive = updatedDTO.IsActive;

            if (user.Save())
            {
                return Ok(user.DTO);
            }
            else
            {
                return BadRequest("Failed to update User.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsUser.DeleteUser(id))
            {
                return Ok($"User with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"User with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsUserExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsUserExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsUser.IsExist(id))
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