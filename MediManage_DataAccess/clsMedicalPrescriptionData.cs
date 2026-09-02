using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsMedicalPrescriptionDTO
    {
        public int? MedicalPrescriptionID { get; set; }
        public int? DetectionID { get; set; }
        public string Notes { get; set; }

        public clsMedicalPrescriptionDTO(int? medicalPrescriptionID, int? detectionID, string notes)
        {
            this.MedicalPrescriptionID = medicalPrescriptionID;
            this.DetectionID = detectionID;
            this.Notes = notes;
        }
    }

    // 2. Data Access Layer
    public class clsMedicalPrescriptionsDataAccess
    {
        public static clsMedicalPrescriptionDTO GetMedicalPrescriptionInfoByID(int? MedicalPrescriptionID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMedicalPrescriptionByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)MedicalPrescriptionID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsMedicalPrescriptionDTO
                                (
                                    reader["MedicalPrescriptionID"] == DBNull.Value ? null : (int?)reader["MedicalPrescriptionID"],
                                    reader["DetectionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DetectionID"]),
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

        public static int? AddNewMedicalPrescription(clsMedicalPrescriptionDTO dto)
        {
            int? medicalPrescriptionID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewMedicalPrescription", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DetectionID", (object)dto.DetectionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)dto.Notes ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewMedicalPrescriptionID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            medicalPrescriptionID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return medicalPrescriptionID;
        }

        public static bool UpdateMedicalPrescription(clsMedicalPrescriptionDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateMedicalPrescription", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)dto.MedicalPrescriptionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DetectionID", (object)dto.DetectionID ?? DBNull.Value);
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

        public static List<clsMedicalPrescriptionDTO> GetAllMedicalPrescriptions()
        {
            var prescriptionsList = new List<clsMedicalPrescriptionDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllMedicalPrescriptions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                prescriptionsList.Add(new clsMedicalPrescriptionDTO
                                (
                                    reader["MedicalPrescriptionID"] == DBNull.Value ? null : (int?)reader["MedicalPrescriptionID"],
                                    reader["DetectionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DetectionID"]),
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

            return prescriptionsList;
        }

        public static bool DeleteMedicalPrescription(int? MedicalPrescriptionID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteMedicalPrescription", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)MedicalPrescriptionID ?? DBNull.Value);

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

        public static bool IsMedicalPrescriptionExist(int? MedicalPrescriptionID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckMedicalPrescriptionExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)MedicalPrescriptionID ?? DBNull.Value);

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