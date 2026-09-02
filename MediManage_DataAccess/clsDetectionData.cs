using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsDetectionDTO
    {
        public int? DetectionID { get; set; }
        public int? AppointmentID { get; set; }
        public int? CreatedByUserID { get; set; }
        public string Symproms { get; set; }
        public string Diagnosis { get; set; }
        public byte? Temperature { get; set; }
        public byte? Wight { get; set; }
        public byte? BloodPressure { get; set; }
        public byte? HeartRate { get; set; }
        public string Notes { get; set; }

        public clsDetectionDTO(int? detectionID, int? appointmentID, int? createdByUserID,
            string symproms, string diagnosis, byte? temperature, byte? wight,
            byte? bloodPressure, byte? heartRate, string notes)
        {
            this.DetectionID = detectionID;
            this.AppointmentID = appointmentID;
            this.CreatedByUserID = createdByUserID;
            this.Symproms = symproms;
            this.Diagnosis = diagnosis;
            this.Temperature = temperature;
            this.Wight = wight;
            this.BloodPressure = bloodPressure;
            this.HeartRate = heartRate;
            this.Notes = notes;
        }
    }

    // 2. Data Access Layer
    public class clsDetectionsDataAccess
    {
        public static clsDetectionDTO GetDetectionInfoByID(int? DetectionID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetDetectionByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DetectionID", (object)DetectionID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsDetectionDTO
                                (
                                    reader["DetectionID"] == DBNull.Value ? null : (int?)reader["DetectionID"],
                                    reader["AppointmentID"] == DBNull.Value ? null : (int?)reader["AppointmentID"],
                                    reader["CreatedByUserID"] == DBNull.Value ? null : (int?)reader["CreatedByUserID"],
                                    reader["Symproms"] == DBNull.Value ? null : (string)reader["Symproms"],
                                    reader["Diagnosis"] == DBNull.Value ? null : (string)reader["Diagnosis"],
                                    reader["Temperature"] == DBNull.Value ? null : (byte?)reader["Temperature"],
                                    reader["Wight"] == DBNull.Value ? null : (byte?)reader["Wight"],
                                    reader["BloodPressure"] == DBNull.Value ? null : (byte?)reader["BloodPressure"],
                                    reader["HeartRate"] == DBNull.Value ? null : (byte?)reader["HeartRate"],
                                    reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"]
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

        public static int? AddNewDetection(clsDetectionDTO dto)
        {
            int? detectionID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewDetection", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AppointmentID", (object)dto.AppointmentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Symproms", (object)dto.Symproms ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Diagnosis", (object)dto.Diagnosis ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Temperature", (object)dto.Temperature ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Wight", (object)dto.Wight ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodPressure", (object)dto.BloodPressure ?? DBNull.Value);
                        command.Parameters.AddWithValue("@HeartRate", (object)dto.HeartRate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)dto.Notes ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewDetectionID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            detectionID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return detectionID;
        }

        public static bool UpdateDetection(clsDetectionDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateDetection", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DetectionID", (object)dto.DetectionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointmentID", (object)dto.AppointmentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Symproms", (object)dto.Symproms ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Diagnosis", (object)dto.Diagnosis ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Temperature", (object)dto.Temperature ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Wight", (object)dto.Wight ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodPressure", (object)dto.BloodPressure ?? DBNull.Value);
                        command.Parameters.AddWithValue("@HeartRate", (object)dto.HeartRate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)dto.Notes ?? DBNull.Value);

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

        public static List<clsDetectionDTO> GetAllDetections()
        {
            var detectionsList = new List<clsDetectionDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllDetections", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detectionsList.Add(new clsDetectionDTO
                                (
                                    reader["DetectionID"] == DBNull.Value ? null : (int?)reader["DetectionID"],
                                    reader["AppointmentID"] == DBNull.Value ? null : (int?)reader["AppointmentID"],
                                    reader["CreatedByUserID"] == DBNull.Value ? null : (int?)reader["CreatedByUserID"],
                                    reader["Symproms"] == DBNull.Value ? null : (string)reader["Symproms"],
                                    reader["Diagnosis"] == DBNull.Value ? null : (string)reader["Diagnosis"],
                                    reader["Temperature"] == DBNull.Value ? null : (byte?)reader["Temperature"],
                                    reader["Wight"] == DBNull.Value ? null : (byte?)reader["Wight"],
                                    reader["BloodPressure"] == DBNull.Value ? null : (byte?)reader["BloodPressure"],
                                    reader["HeartRate"] == DBNull.Value ? null : (byte?)reader["HeartRate"],
                                    reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"]
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

            return detectionsList;
        }

        public static bool DeleteDetection(int? DetectionID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteDetection", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DetectionID", (object)DetectionID ?? DBNull.Value);

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

        public static bool IsDetectionExist(int? DetectionID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckDetectionExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DetectionID", (object)DetectionID ?? DBNull.Value);

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