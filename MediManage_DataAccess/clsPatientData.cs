using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsPatientDTO
    {
        public int? PatientID { get; set; }
        public int? PersonID { get; set; }
        public string Sensitivity { get; set; }
        public string ChronicDiseases { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? PatientCaseID { get; set; }

        public clsPatientDTO(int? patientID, int? personID, string sensitivity, string chronicDiseases, DateTime? joinDate, int? patientCaseID)
        {
            this.PatientID = patientID;
            this.PersonID = personID;
            this.Sensitivity = sensitivity;
            this.ChronicDiseases = chronicDiseases;
            this.JoinDate = joinDate;
            this.PatientCaseID = patientCaseID;
        }
    }

    public class clsPatientsListDTO
    {
        public int? PersonID { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public string Phone { get; set; }

        public clsPatientsListDTO(int? PersonID, string FullName, string NationalNo, string Phone)
        {
            this.PersonID = PersonID;
            this.FullName = FullName;
            this.NationalNo = NationalNo;
            this.Phone = Phone;
        }
    }


    // 2. Data Access Layer
    public class clsPatientsDataAccess
    {
        public static clsPatientDTO GetPatientInfoByPersonID(int? PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("[SP_GetPatientByPersonID]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsPatientDTO
                                (
                                    reader["PatientID"] == DBNull.Value ? null : (int?)reader["PatientID"],
                                    reader["PersonID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PersonID"]),
                                    reader["Sensitivity"] == DBNull.Value ? null : (string)reader["Sensitivity"],
                                    reader["ChronicDiseases"] == DBNull.Value ? null : (string)reader["ChronicDiseases"],
                                    reader["JoinDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["JoinDate"]),
                                    reader["PatientCaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PatientCaseID"])
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

        public static clsPatientDTO GetPatientInfoByNationalNo(string NationalNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPatientByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", (object)NationalNo ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsPatientDTO
                                (
                                    reader["PatientID"] == DBNull.Value ? null : (int?)reader["PatientID"],
                                    reader["PersonID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PersonID"]),
                                    reader["Sensitivity"] == DBNull.Value ? null : (string)reader["Sensitivity"],
                                    reader["ChronicDiseases"] == DBNull.Value ? null : (string)reader["ChronicDiseases"],
                                    reader["JoinDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["JoinDate"]),
                                    reader["PatientCaseID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PatientCaseID"])
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


        public static int? AddNewPatient(clsPatientDTO dto)
        {
            int? patientID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewPatient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)dto.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Sensitivity", (object)dto.Sensitivity ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ChronicDiseases", (object)dto.ChronicDiseases ?? DBNull.Value);
                        command.Parameters.AddWithValue("@JoinDate", (object)dto.JoinDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PatientCaseID", (object)dto.PatientCaseID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPatientID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            patientID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return patientID;
        }

        public static bool UpdatePatient(clsPatientDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePatient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PatientID", (object)dto.PatientID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)dto.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Sensitivity", (object)dto.Sensitivity ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ChronicDiseases", (object)dto.ChronicDiseases ?? DBNull.Value);
                        command.Parameters.AddWithValue("@JoinDate", (object)dto.JoinDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PatientCaseID", (object)dto.PatientCaseID ?? DBNull.Value);

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

        public static List<clsPatientsListDTO> GetAllPatients()
        {
            var patientsList = new List<clsPatientsListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllPatients", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patientsList.Add(new clsPatientsListDTO
                                (
                                    reader["PersonID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PersonID"]),
                                    reader["FullName"] == DBNull.Value ? null : (string)reader["FullName"],
                                    reader["NationalNo"] == DBNull.Value ? null : (string)reader["NationalNo"],
                                    reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"]
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

            return patientsList;
        }

        public static bool DeletePatient(int? PersonID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeletePatient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

        public static bool IsPatientExist(int? PersonID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPatientExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

        public static bool IsPatientExist(string NationalNo)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPatientExistsByNationalNo", connection))
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


        public static int? GetTotalPatientsNumber()
        {
            int? totalNumber = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetTotalPatientsNumber", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalNumber = reader["TotalNumber"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TotalNumber"]);
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

            return totalNumber;
        }
    }
}