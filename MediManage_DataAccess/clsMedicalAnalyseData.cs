using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsMedicalAnalysisDTO
    {
        public int? MedicalAnalysisID { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public int? AnalysisStatusID { get; set; }
        public int? AnalysisTypeID { get; set; }
        public int? DetectionID { get; set; }

        public clsMedicalAnalysisDTO(int? medicalAnalysisID, string result, DateTime? orderDate, DateTime? resultDate, int? analysisStatusID, int? analysisTypeID, int? detectionID)
        {
            this.MedicalAnalysisID = medicalAnalysisID;
            this.Result = result;
            this.OrderDate = orderDate;
            this.ResultDate = resultDate;
            this.AnalysisStatusID = analysisStatusID;
            this.AnalysisTypeID = analysisTypeID;
            this.DetectionID = detectionID;
        }
    }

    // 2. Data Access Layer
    public class clsMedicalAnalysesDataAccess
    {
        public static clsMedicalAnalysisDTO GetMedicalAnalysisInfoByID(int? MedicalAnalysisID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMedicalAnalysisByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalAnalysisID", (object)MedicalAnalysisID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsMedicalAnalysisDTO
                                (
                                    reader["MedicalAnalysisID"] == DBNull.Value ? null : (int?)reader["MedicalAnalysisID"],
                                    reader["Result"] == DBNull.Value ? null : (string)reader["Result"],
                                    reader["OrderDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]),
                                    reader["ResultDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ResultDate"]),
                                    reader["AnalysisStatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AnalysisStatusID"]),
                                    reader["AnalysisTypeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AnalysisTypeID"]),
                                    reader["DetectionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DetectionID"])
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

        public static int? AddNewMedicalAnalysis(clsMedicalAnalysisDTO dto)
        {
            int? medicalAnalysisID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewMedicalAnalysis", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Result", (object)dto.Result ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OrderDate", (object)dto.OrderDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ResultDate", (object)dto.ResultDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AnalysisStatusID", (object)dto.AnalysisStatusID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)dto.AnalysisTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DetectionID", (object)dto.DetectionID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewMedicalAnalysisID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            medicalAnalysisID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return medicalAnalysisID;
        }

        public static bool UpdateMedicalAnalysis(clsMedicalAnalysisDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateMedicalAnalysis", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MedicalAnalysisID", (object)dto.MedicalAnalysisID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Result", (object)dto.Result ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OrderDate", (object)dto.OrderDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ResultDate", (object)dto.ResultDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AnalysisStatusID", (object)dto.AnalysisStatusID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AnalysisTypeID", (object)dto.AnalysisTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DetectionID", (object)dto.DetectionID ?? DBNull.Value);

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

        public static List<clsMedicalAnalysisDTO> GetAllMedicalAnalyses()
        {
            var medicalAnalysesList = new List<clsMedicalAnalysisDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllMedicalAnalyses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medicalAnalysesList.Add(new clsMedicalAnalysisDTO
                                (
                                    reader["MedicalAnalysisID"] == DBNull.Value ? null : (int?)reader["MedicalAnalysisID"],
                                    reader["Result"] == DBNull.Value ? null : (string)reader["Result"],
                                    reader["OrderDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]),
                                    reader["ResultDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ResultDate"]),
                                    reader["AnalysisStatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AnalysisStatusID"]),
                                    reader["AnalysisTypeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["AnalysisTypeID"]),
                                    reader["DetectionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DetectionID"])
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

            return medicalAnalysesList;
        }

        public static bool DeleteMedicalAnalysis(int? MedicalAnalysisID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteMedicalAnalysis", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalAnalysisID", (object)MedicalAnalysisID ?? DBNull.Value);

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

        public static bool IsMedicalAnalysisExist(int? MedicalAnalysisID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckMedicalAnalysisExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalAnalysisID", (object)MedicalAnalysisID ?? DBNull.Value);

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