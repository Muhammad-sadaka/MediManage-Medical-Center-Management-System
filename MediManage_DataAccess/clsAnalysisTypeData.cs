using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsAnalysisTypeDTO
    {
        public int? AnalysisTypeID { get; set; }
        public string AnalysisTypeName { get; set; }
        public decimal? Price { get; set; }

        public clsAnalysisTypeDTO(int? analysisTypeID, string analysisTypeName, decimal? price)
        {
            this.AnalysisTypeID = analysisTypeID;
            this.AnalysisTypeName = analysisTypeName;
            this.Price = price;
        }
    }

    public class clsAnalysisTypeData
    {
        public static clsAnalysisTypeDTO GetAnalysisTypeInfoByID(int? AnalysisTypeID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAnalysisTypeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)AnalysisTypeID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsAnalysisTypeDTO
                                (
                                    reader["AnalysisTypeID"] == DBNull.Value ? null : (int?)reader["AnalysisTypeID"],
                                    reader["AnalysisTypeName"] == DBNull.Value ? null : (string)reader["AnalysisTypeName"],
                                    reader["Price"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Price"])
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

        public static int? AddNewAnalysisType(clsAnalysisTypeDTO typeDTO)
        {
            int? AnalysisTypeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewAnalysisType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AnalysisTypeName", (object)typeDTO.AnalysisTypeName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", (object)typeDTO.Price ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewAnalysisTypeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            AnalysisTypeID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return AnalysisTypeID;
        }

        public static bool UpdateAnalysisType(clsAnalysisTypeDTO typeDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateAnalysisType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)typeDTO.AnalysisTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AnalysisTypeName", (object)typeDTO.AnalysisTypeName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", (object)typeDTO.Price ?? DBNull.Value);

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

        public static List<clsAnalysisTypeDTO> GetAllAnalysisTypes()
        {
            var analysisTypesList = new List<clsAnalysisTypeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllAnalysisTypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                analysisTypesList.Add(new clsAnalysisTypeDTO
                                (
                                    reader["AnalysisTypeID"] == DBNull.Value ? null : (int?)reader["AnalysisTypeID"],
                                    reader["AnalysisTypeName"] == DBNull.Value ? null : (string)reader["AnalysisTypeName"],
                                    reader["Price"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Price"])
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

            return analysisTypesList;
        }

        public static bool DeleteAnalysisType(int? AnalysisTypeID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteAnalysisType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)AnalysisTypeID ?? DBNull.Value);

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

        public static bool IsAnalysisTypeExist(int? AnalysisTypeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckAnalysisTypeExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)AnalysisTypeID ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (returnParameter.Value != DBNull.Value)
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