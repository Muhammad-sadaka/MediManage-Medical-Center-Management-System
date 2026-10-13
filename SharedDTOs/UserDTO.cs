using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class UserDTO
    {
    }
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class clsUserDTO
    {
        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Permissions { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedByUser { get; set; }

        public clsUserDTO(int? userID, int? personID, string userName, string password, int? permissions, bool? isActive, int? CreatedByUser)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.Permissions = permissions;
            this.IsActive = isActive;
            this.CreatedByUser = CreatedByUser;
        }
    }

    public class clsUsersListDTO
    {
        public int? UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }

        public clsUsersListDTO(int? UserID, string FullName, string userName, string Phone, bool? Status)
        {
            this.UserID = UserID;
            this.FullName = FullName;
            this.UserName = userName;
            this.Phone = Phone;
            this.Status = Status;
        }
    }
}
