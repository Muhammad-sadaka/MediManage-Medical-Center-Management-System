using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsMedicineDTO
    {
        public int? MedicineID { get; set; }
        public string MedicineName { get; set; }

        public clsMedicineDTO(int? medicineID, string medicineName)
        {
            this.MedicineID = medicineID;
            this.MedicineName = medicineName;

        }

        public class clsMedicineDataAccess
        {
            public static clsMedicineDTO GetMedicineInfoByID(int? MedicineID)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_GetMedicineByID", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@MedicineID", (object)MedicineID ?? DBNull.Value);

                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    return new clsMedicineDTO
                                    (
                                        reader["MedicineID"] == DBNull.Value ? null : (int?)reader["MedicineID"],
                                        reader["MedicineName"] == DBNull.Value ? null : (string)reader["MedicineName"]
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

            public static int? AddNewMedicine(clsMedicineDTO dto)
            {
                int? medicineID = null;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_AddNewMedicine", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@MedicineName", (object)dto.MedicineName ?? DBNull.Value);

                            SqlParameter outputIdParam = new SqlParameter("@NewMedicineID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(outputIdParam);

                            connection.Open();
                            command.ExecuteNonQuery();

                            if (outputIdParam.Value != DBNull.Value)
                                medicineID = (int)outputIdParam.Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsDataAccessSettings.EventLogCreate();
                    EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
                }

                return medicineID;
            }

            public static bool UpdateMedicine(clsMedicineDTO dto)
            {
                int rowsAffected = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_UpdateMedicine", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@MedicineID", (object)dto.MedicineID ?? DBNull.Value);
                            command.Parameters.AddWithValue("@MedicineName", (object)dto.MedicineName ?? DBNull.Value);

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

            public static List<clsMedicineDTO> GetAllMedicines()
            {
                var medicinesList = new List<clsMedicineDTO>();

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_GetAllMedicines", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    medicinesList.Add(new clsMedicineDTO
                                    (
                                        reader["MedicineID"] == DBNull.Value ? null : (int?)reader["MedicineID"],
                                        reader["MedicineName"] == DBNull.Value ? null : (string)reader["MedicineName"]
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

            public static bool DeleteMedicine(int? MedicineID)
            {
                int rowsAffected = 0;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_DeleteMedicine", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@MedicineID", (object)MedicineID ?? DBNull.Value);

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

            public static bool IsMedicineExist(int? MedicineID)
            {
                bool isFound = false;

                try
                {
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SP_CheckMedicineExists", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@MedicineID", (object)MedicineID ?? DBNull.Value);

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
}