using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsMedicineRecipeDTO
    {
        public int? MedicineRecipeID { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }
        public int? MedicalPrescriptionID { get; set; }
        public string Notes { get; set; }
        public int? MedicineID { get; set; }

        public clsMedicineRecipeDTO(int? MedicineRecipeID, string duration, string repetition, string dose, int? medicalPrescriptionID, string notes,int? medicineID)
        {
            this.MedicineRecipeID = MedicineRecipeID;
            this.Duration = duration;
            this.Repetition = repetition;
            this.Dose = dose;
            this.MedicalPrescriptionID = medicalPrescriptionID;
            this.Notes = notes;
            this.MedicineID = medicineID;
        }
    }

    public class clsMedicineRecipeListDTO
    {
        public string MedicineName { get; set; }
        public string Duration { get; set; }
        public string Repetition { get; set; }
        public string Dose { get; set; }

        public clsMedicineRecipeListDTO(string MedicineName, string dose,  string repetition, string duration)
        {
            this.MedicineName = MedicineName;
            this.Duration = duration;
            this.Repetition = repetition;
            this.Dose = dose;
        }
    }

    public class clsMedicineRecipeDataAccess
    {
        public static clsMedicineRecipeDTO GetMedicineRecipeInfoByID(int? MedicineID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetMedicineRecipeByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicineRecipeID", (object)MedicineID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsMedicineRecipeDTO
                                (
                                    reader["MedicineRecipeID"] == DBNull.Value ? null : (int?)reader["MedicineRecipeID"],
                                    reader["Duration"] == DBNull.Value ? null : (string)reader["Duration"],
                                    reader["Repetition"] == DBNull.Value ? null : (string)reader["Repetition"],
                                    reader["Dose"] == DBNull.Value ? null : (string)reader["Dose"],
                                    reader["MedicalPrescriptionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MedicalPrescriptionID"]),
                                    reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"],
                                    reader["MedicineID"] == DBNull.Value ? null : (int?)reader["MedicineID"]
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

        public static int? AddNewMedicineRecipe(clsMedicineRecipeDTO dto)
        {
            int? MedicineRecipeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewMedicineRecipe", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Duration", (object)dto.Duration ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Repetition", (object)dto.Repetition ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Dose", (object)dto.Dose ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)dto.MedicalPrescriptionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)dto.Notes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MedicineID", (object)dto.MedicineID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewMedicineRecipeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            MedicineRecipeID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return MedicineRecipeID;
        }

        public static bool UpdateMedicineRecipe(clsMedicineRecipeDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateMedicineRecipe", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MedicineRecipeID", (object)dto.MedicineID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Duration", (object)dto.Duration ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Repetition", (object)dto.Repetition ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Dose", (object)dto.Dose ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MedicalPrescriptionID", (object)dto.MedicalPrescriptionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)dto.Notes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MedicineID", (object)dto.MedicineID ?? DBNull.Value);

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

        public static List<clsMedicineRecipeDTO> GetAllMedicinesRecipes()
        {
            var medicinesList = new List<clsMedicineRecipeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllMedicinesRecipes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                medicinesList.Add(new clsMedicineRecipeDTO
                                (
                                    reader["MedicineRecipeID"] == DBNull.Value ? null : (int?)reader["MedicineRecipeID"],
                                    reader["Duration"] == DBNull.Value ? null : (string)reader["Duration"],
                                    reader["Repetition"] == DBNull.Value ? null : (string)reader["Repetition"],
                                    reader["Dose"] == DBNull.Value ? null : (string)reader["Dose"],
                                    reader["MedicalPrescriptionID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MedicalPrescriptionID"]),
                                    reader["Notes"] == DBNull.Value ? null : (string)reader["Notes"],
                                    reader["MedicineID"] == DBNull.Value ? null : (int?)reader["MedicineID"]
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

            return medicinesList;
        }

        public static bool DeleteMedicineRecipe(int? MedicineRecipeID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteMedicineRecipe", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicineRecipeID", (object)MedicineRecipeID ?? DBNull.Value);

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

        public static bool IsMedicineRecipeExist(int? MedicineRecipeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckMedicineRecipeExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MedicineRecipeID", (object)MedicineRecipeID ?? DBNull.Value);

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
