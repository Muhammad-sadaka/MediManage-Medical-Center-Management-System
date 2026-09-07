using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Permissions { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedByUser { get; set; }
        public clsPerson PersonInfo { get; set; }


        public clsUserDTO DTO => new clsUserDTO(this.UserID, this.PersonID, this.UserName, this.Password, this.Permissions, this.IsActive,this.CreatedByUser);

        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permissions = null;
            this.IsActive = null;
            this.CreatedByUser = null;
            this.PersonInfo = null;

            this.Mode = enMode.AddNew;
        }

        public clsUser(clsUserDTO dto, enMode mode = enMode.AddNew)
        {
            this.UserID = dto.UserID;
            this.PersonID = dto.PersonID;
            this.UserName = dto.UserName;
            this.Password = dto.Password;
            this.Permissions = dto.Permissions;
            this.IsActive = dto.IsActive;
            this.CreatedByUser = dto.CreatedByUser;
            this.PersonInfo = clsPerson.Find(this.PersonID);

            this.Mode = mode;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersDataAccess.AddNewUser(this.DTO);
            return (this.UserID != null);
        }

        private bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.DTO);
        }

        public static clsUser Find(int? userID)
        {
            clsUserDTO dto = clsUsersDataAccess.GetUserInfoByID(userID);

            if (dto != null)
                return new clsUser(dto, enMode.Update);

            return null;
        }

        public static clsUser FindByUsernameAndPassword(string userName, string password)
        {
            clsUserDTO dto = clsUsersDataAccess.FindByUsernameAndPassword(userName, password);

            if (dto != null)
                return new clsUser(dto, enMode.Update);

            return null;
        }

        public static List<clsUsersListDTO> GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static bool DeleteUser(int? userID)
        {
            return clsUsersDataAccess.DeleteUser(userID);
        }

        public static bool IsUserExist(int? userID)
        {
            return clsUsersDataAccess.IsUserExist(userID);
        }
    }
}