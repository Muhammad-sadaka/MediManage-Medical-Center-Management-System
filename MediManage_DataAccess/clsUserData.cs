using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{

    public class clsUserDTO
    {
        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Permissions { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedByUser { get; set; }

        public clsUserDTO(int? userID, int? personID, string userName, string password, int? permissions, bool? isActive,int? CreatedByUser)
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
        public int? PersonID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }

        public clsUsersListDTO( int? personID,string FullName, string userName, string Phone, bool? Status)
        {
            this.PersonID = personID;
            this.FullName = FullName;
            this.UserName = userName;
            this.Phone = Phone;
            this.Status = Status;
        }
    }


    public class clsUsersDataAccess
    {
        public static clsUserDTO GetUserInfoByID(int? UserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsUserDTO(
                                       reader["UserID"] == DBNull.Value ? null : (int?)reader["UserID"],
                                       reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                       reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"],
                                       reader["Password"] == DBNull.Value ? null : (string)reader["Password"],
                                       reader["Permissions"] == DBNull.Value ? null : (int?)reader["Permissions"],
                                       reader["IsActive"] == DBNull.Value ? null : (bool?)reader["IsActive"],
                                       reader["CreatedByUser"] == DBNull.Value ? null : (int?)reader["CreatedByUser"]
                                   );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return null;
        }

        public static int? AddNewUser(clsUserDTO userDTO)
        {
            int? UserID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)userDTO.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", (object)userDTO.UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)userDTO.Password ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Permissions", (object)userDTO.Permissions ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)userDTO.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUser", (object)userDTO.CreatedByUser ?? DBNull.Value);

                        
                        SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            UserID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return UserID;
        }

        public static bool UpdateUser(clsUserDTO userDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)userDTO.UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)userDTO.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserName", (object)userDTO.UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)userDTO.Password ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Permissions", (object)userDTO.Permissions ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)userDTO.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUser", (object)userDTO.CreatedByUser ?? DBNull.Value);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
                return false;
            }

            return rowsAffected > 0;
        }

        public static List<clsUsersListDTO> GetAllUsers()
        {
            List<clsUsersListDTO> list = new List<clsUsersListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new clsUsersListDTO(
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["FullName"] == DBNull.Value ? null : (string)reader["FullName"],
                                    reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"],
                                    reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"],
                                    reader["Status"] == DBNull.Value ? null : (bool?)reader["Status"]
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return list;
        }

        public static bool DeleteUser(int? UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return rowsAffected > 0;
        }

        public static bool IsUserExist(int? UserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckUserExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (returnParameter.Value != null)
                        {
                            isFound = (int)returnParameter.Value == 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return isFound;
        }

        public static clsUserDTO FindByUsernameAndPassword(string UserName, string Password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByUserNameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Password", (object)Password ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsUserDTO(
                                    reader["UserID"] == DBNull.Value ? null : (int?)reader["UserID"],
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["UserName"] == DBNull.Value ? null : (string)reader["UserName"],
                                    reader["Password"] == DBNull.Value ? null : (string)reader["Password"],
                                    reader["Permissions"] == DBNull.Value ? null : (int?)reader["Permissions"],
                                    reader["IsActive"] == DBNull.Value ? null : (bool?)reader["IsActive"],
                                    reader["CreatedByUser"] == DBNull.Value ? null : (int?)reader["CreatedByUser"]     
                                                     );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return null;
        }
    }
}