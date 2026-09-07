using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsSpecialtyDTO
    {
        public int? SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public string Description { get; set; }
        public decimal? Fees { get; set; }
   
        public clsSpecialtyDTO(int? specialtyID, string specialtyName, string description, decimal? fees)
        {
            this.SpecialtyID = specialtyID;
            this.SpecialtyName = specialtyName;
            this.Description = description;
            this.Fees = fees;
        }
        
    }

    public class clsSpecialtiesDataAccess
    {
        public static clsSpecialtyDTO GetSpecialtyInfoByID(int? SpecialtyID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetSpecialtyByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SpecialtyID", (object)SpecialtyID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsSpecialtyDTO(
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["SpecialtyName"] == DBNull.Value ? null : (string)reader["SpecialtyName"],
                                    reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                                    reader["Fees"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Fees"])
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

        public static clsSpecialtyDTO GetSpecialtyInfoByspecialtyName(string SpecialtyName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetSpecialtyBySpecialtyName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SpecialtyName", (object)SpecialtyName ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsSpecialtyDTO(
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["SpecialtyName"] == DBNull.Value ? null : (string)reader["SpecialtyName"],
                                    reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                                    reader["Fees"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Fees"])
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

        public static int? AddNewSpecialty(clsSpecialtyDTO specialtyDTO)
        {
            int? SpecialtyID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewSpecialty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SpecialtyName", (object)specialtyDTO.SpecialtyName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)specialtyDTO.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Fees", (object)specialtyDTO.Fees ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewSpecialtyID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            SpecialtyID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return SpecialtyID;
        }

        public static bool UpdateSpecialty(clsSpecialtyDTO specialtyDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateSpecialty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SpecialtyID", (object)specialtyDTO.SpecialtyID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpecialtyName", (object)specialtyDTO.SpecialtyName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)specialtyDTO.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Fees", (object)specialtyDTO.Fees ?? DBNull.Value);

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

        public static List<clsSpecialtyDTO> GetAllSpecialties()
        {
            List<clsSpecialtyDTO> list = new List<clsSpecialtyDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllSpecialties", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new clsSpecialtyDTO(
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["SpecialtyName"] == DBNull.Value ? null : (string)reader["SpecialtyName"],
                                    reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                                    reader["Fees"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Fees"])
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

        public static bool DeleteSpecialty(int? SpecialtyID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteSpecialty", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SpecialtyID", (object)SpecialtyID ?? DBNull.Value);

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

        public static bool IsSpecialtyExist(int? SpecialtyID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckSpecialtyExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SpecialtyID", (object)SpecialtyID ?? DBNull.Value);

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
    }
}