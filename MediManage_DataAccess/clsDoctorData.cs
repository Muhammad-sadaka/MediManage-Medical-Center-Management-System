using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsDoctorDTO
    {
        public int? DoctorID { get; set; }
        public int? PersonID { get; set; }
        public byte? YearsOfExperience { get; set; }
        public string Qualification { get; set; }
        public bool? IsActive { get; set; }
        public int? SpecialtyID { get; set; }
        public string LicenseNo { get; set; }   

        public clsDoctorDTO(int? doctorID, int? personID, byte? yearsOfExperience, string qualification, bool? isActive, int? specialtyID,string licenseNo)
        {
            this.DoctorID = doctorID;
            this.PersonID = personID;
            this.YearsOfExperience = yearsOfExperience;
            this.Qualification = qualification;
            this.IsActive = isActive;
            this.SpecialtyID = specialtyID;
            this.LicenseNo = licenseNo;
        }
    }

    public class clsDoctorListDTO
    {
        public int? DoctorID { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set;  }
        public string Phone { get; set; }


        public clsDoctorListDTO(int? DoctorID, string NationalNo, string FullName, string Specialty, string Phone)
        {
            this.DoctorID = DoctorID;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.Specialty = Specialty;
            this.Phone = Phone;
        }
    }

    // 2. Data Access Layer
    public class clsDoctorsDataAccess
    {
        public static clsDoctorDTO GetDoctorInfoByID(int? DoctorID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetDoctorByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DoctorID", (object)DoctorID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsDoctorDTO
                                (
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["YearsOfExperience"] == DBNull.Value ? null : (byte?)reader["YearsOfExperience"],
                                    reader["Qualification"] == DBNull.Value ? null : (string)reader["Qualification"],
                                    reader["IsActive"] == DBNull.Value ? null : (bool?)reader["IsActive"],
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["LicenseNo"] == DBNull.Value ? null : (string)reader["LicenseNo"]
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

        public static clsDoctorDTO GetDoctorInfoByPersonID(int? PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetDoctorByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsDoctorDTO
                                (
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["YearsOfExperience"] == DBNull.Value ? null : (byte?)reader["YearsOfExperience"],
                                    reader["Qualification"] == DBNull.Value ? null : (string)reader["Qualification"],
                                    reader["IsActive"] == DBNull.Value ? null : (bool?)reader["IsActive"],
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["LicenseNo"] == DBNull.Value ? null : (string)reader["LicenseNo"]
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

        public static clsDoctorDTO GetDoctorInfoByNationalNo(string NationalNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetDoctorByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", (object)NationalNo ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsDoctorDTO
                                (
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["YearsOfExperience"] == DBNull.Value ? null : (byte?)reader["YearsOfExperience"],
                                    reader["Qualification"] == DBNull.Value ? null : (string)reader["Qualification"],
                                    reader["IsActive"] == DBNull.Value ? null : (bool?)reader["IsActive"],
                                    reader["SpecialtyID"] == DBNull.Value ? null : (int?)reader["SpecialtyID"],
                                    reader["LicenseNo"] == DBNull.Value ? null : (string)reader["LicenseNo"]
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

        public static int? AddNewDoctor(clsDoctorDTO dto)
        {
            int? doctorID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewDoctor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)dto.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@YearsOfExperience", (object)dto.YearsOfExperience ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Qualification", (object)dto.Qualification ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)dto.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpecialtyID", (object)dto.SpecialtyID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LicenseNo", (object)dto.LicenseNo ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewDoctorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            doctorID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return doctorID;
        }

        public static bool UpdateDoctor(clsDoctorDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateDoctor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DoctorID", (object)dto.DoctorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)dto.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@YearsOfExperience", (object)dto.YearsOfExperience ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Qualification", (object)dto.Qualification ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsActive", (object)dto.IsActive ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SpecialtyID", (object)dto.SpecialtyID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LicenseNo", (object)dto.LicenseNo ?? DBNull.Value);

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

        public static List<clsDoctorListDTO> GetAllDoctors()
        {
            var doctorsList = new List<clsDoctorListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllDoctors", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctorsList.Add(new clsDoctorListDTO
                                (
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["NationalNo"] == DBNull.Value ? null : (string)reader["NationalNo"],
                                    reader["FullName"] == DBNull.Value ? null : (string)reader["FullName"],
                                    reader["Specialty"] == DBNull.Value ? null : (string)reader["Specialty"],
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

            return doctorsList;
        }

        public static List<string> GetAllDoctorsNames()
        {
            var doctorsList = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllDoctorsNames", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctorsList.Add(
                                (
                                    reader["FullName"] == DBNull.Value ? null : (string)reader["FullName"]
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

            return doctorsList;
        }

        public static bool DeleteDoctor(int? DoctorID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteDoctor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DoctorID", (object)DoctorID ?? DBNull.Value);

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

        public static bool IsDoctorExist(int? DoctorID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckDoctorExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DoctorID", (object)DoctorID ?? DBNull.Value);

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

        public static bool IsDoctorExist(string NationalNo)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckDoctorExistsByNationalNo", connection))
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

    }
}