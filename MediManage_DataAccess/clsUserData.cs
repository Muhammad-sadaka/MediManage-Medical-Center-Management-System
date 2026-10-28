using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SharedDTOs;

namespace MediManage_DataAccess
{
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
                                    reader["CreatedByUser"] == DBNull.Value ? null : (int?)reader["CreatedByUser"],
                                    reader["RefreshTokenHash"] == DBNull.Value ? null : (string)reader["RefreshTokenHash"],
                                    reader["RefreshTokenExpiresAt"] == DBNull.Value ? null : (DateTime?)reader["RefreshTokenExpiresAt"],
                                    reader["RefreshTokenRevokedAt"] == DBNull.Value ? null : (DateTime?)reader["RefreshTokenRevokedAt"]
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

        public static clsUserDTO GetUserInfoByUserName(string UserName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[SP_GetUserByUserName]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);

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
                                    reader["CreatedByUser"] == DBNull.Value ? null : (int?)reader["CreatedByUser"],
                                    reader["RefreshTokenHash"] == DBNull.Value ? null : (string)reader["RefreshTokenHash"],
                                    reader["RefreshTokenExpiresAt"] == DBNull.Value ? null : (DateTime?)reader["RefreshTokenExpiresAt"],
                                    reader["RefreshTokenRevokedAt"] == DBNull.Value ? null : (DateTime?)reader["RefreshTokenRevokedAt"]
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

                        // تمرير حقول الـ Refresh Token في حالة الإضافة (إذا وجِدت)
                        command.Parameters.AddWithValue("@RefreshTokenHash", (object)userDTO.RefreshTokenHash ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RefreshTokenExpiresAt", (object)userDTO.RefreshTokenExpiresAt ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RefreshTokenRevokedAt", (object)userDTO.RefreshTokenRevokedAt ?? DBNull.Value);

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

                        // تمرير وتحديث حقول الـ Refresh Token عند كل عملية حفظ/تحديث (مثل تسجيل الدخول أو الـ Refresh أو الـ Logout)
                        command.Parameters.AddWithValue("@RefreshTokenHash", (object)userDTO.RefreshTokenHash ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RefreshTokenExpiresAt", (object)userDTO.RefreshTokenExpiresAt ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RefreshTokenRevokedAt", (object)userDTO.RefreshTokenRevokedAt ?? DBNull.Value);

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
                                    reader["UserID"] == DBNull.Value ? null : (int?)reader["UserID"],
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

        public static bool IsUserExist(string NationalNo)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckUserExistsByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", (object)NationalNo ?? DBNull.Value);

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

        public static bool IsUserExistByUserName(string UserName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[SP_CheckUserExistsByUserName]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);

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

        public static bool ChangeUserStatus(int? UserID, bool? IsActive)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[SP_ChangeUserStatus]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

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
    }
}