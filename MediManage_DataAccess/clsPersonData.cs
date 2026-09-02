using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsPersonDTO
    {
        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNo { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? BloodTypeID { get; set; }
        public int? MaritalStatusID { get; set; }
        public int? CountryId { get; set; }

        public clsPersonDTO(int? personID, string firstName, string secondName, string thirdName, string lastName,
                            string nationalNo, string phone, DateTime? dateOfBirth, string gender, string image,
                            string address, string email, int? bloodTypeID, int? maritalStatusID, int? countryId)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.Phone = phone;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Image = image;
            this.Address = address;
            this.Email = email;
            this.BloodTypeID = bloodTypeID;
            this.MaritalStatusID = maritalStatusID;
            this.CountryId = countryId;
        }
    }

    // 2. Data Access Layer
    public class clsPeopleDataAccess
    {
        public static clsPersonDTO GetPersonInfoByID(int? PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsPersonDTO
                                (
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["FirstName"] == DBNull.Value ? null : (string)reader["FirstName"],
                                    reader["SecondName"] == DBNull.Value ? null : (string)reader["SecondName"],
                                    reader["ThirdName"] == DBNull.Value ? null : (string)reader["ThirdName"],
                                    reader["LastName"] == DBNull.Value ? null : (string)reader["LastName"],
                                    reader["NationalNo"] == DBNull.Value ? null : (string)reader["NationalNo"],
                                    reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"],
                                    reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateOfBirth"]),
                                    reader["Gender"] == DBNull.Value ? null : (string)reader["Gender"],
                                    reader["Image"] == DBNull.Value ? null : (string)reader["Image"],
                                    reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                                    reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                    reader["BloodTypeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BloodTypeID"]),
                                    reader["MaritalStatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaritalStatusID"]),
                                    reader["CountryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CountryId"])
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

        public static clsPersonDTO GetPersonInfoByNationalNo(string NationalNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", (object)NationalNo ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsPersonDTO
                                (
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["FirstName"] == DBNull.Value ? null : (string)reader["FirstName"],
                                    reader["SecondName"] == DBNull.Value ? null : (string)reader["SecondName"],
                                    reader["ThirdName"] == DBNull.Value ? null : (string)reader["ThirdName"],
                                    reader["LastName"] == DBNull.Value ? null : (string)reader["LastName"],
                                    reader["NationalNo"] == DBNull.Value ? null : (string)reader["NationalNo"],
                                    reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"],
                                    reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateOfBirth"]),
                                    reader["Gender"] == DBNull.Value ? null : (string)reader["Gender"],
                                    reader["Image"] == DBNull.Value ? null : (string)reader["Image"],
                                    reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                                    reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                    reader["BloodTypeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BloodTypeID"]),
                                    reader["MaritalStatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaritalStatusID"]),
                                    reader["CountryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CountryId"])
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


        public static int? AddNewPerson(clsPersonDTO dto)
        {
            int? personID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", (object)dto.FirstName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SecondName", (object)dto.SecondName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThirdName", (object)dto.ThirdName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)dto.LastName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NationalNo", (object)dto.NationalNo ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", (object)dto.Phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateOfBirth", (object)dto.DateOfBirth ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", (object)dto.Gender ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Image", (object)dto.Image ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)dto.Address ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object)dto.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodTypeID", (object)dto.BloodTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaritalStatusID", (object)dto.MaritalStatusID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CountryId", (object)dto.CountryId ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            personID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return personID;
        }

        public static bool UpdatePerson(clsPersonDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)dto.PersonID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", (object)dto.FirstName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SecondName", (object)dto.SecondName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ThirdName", (object)dto.ThirdName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", (object)dto.LastName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NationalNo", (object)dto.NationalNo ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Phone", (object)dto.Phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DateOfBirth", (object)dto.DateOfBirth ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", (object)dto.Gender ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Image", (object)dto.Image ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)dto.Address ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object)dto.Email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BloodTypeID", (object)dto.BloodTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MaritalStatusID", (object)dto.MaritalStatusID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CountryId", (object)dto.CountryId ?? DBNull.Value);

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

        public static List<clsPersonDTO> GetAllPeople()
        {
            var peopleList = new List<clsPersonDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                peopleList.Add(new clsPersonDTO
                                (
                                    reader["PersonID"] == DBNull.Value ? null : (int?)reader["PersonID"],
                                    reader["FirstName"] == DBNull.Value ? null : (string)reader["FirstName"],
                                    reader["SecondName"] == DBNull.Value ? null : (string)reader["SecondName"],
                                    reader["ThirdName"] == DBNull.Value ? null : (string)reader["ThirdName"],
                                    reader["LastName"] == DBNull.Value ? null : (string)reader["LastName"],
                                    reader["NationalNo"] == DBNull.Value ? null : (string)reader["NationalNo"],
                                    reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"],
                                    reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateOfBirth"]),
                                    reader["Gender"] == DBNull.Value ? null : (string)reader["Gender"],
                                    reader["Image"] == DBNull.Value ? null : (string)reader["Image"],
                                    reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                                    reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                                    reader["BloodTypeID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["BloodTypeID"]),
                                    reader["MaritalStatusID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["MaritalStatusID"]),
                                    reader["CountryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CountryId"])
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

            return peopleList;
        }

        public static bool DeletePerson(int? PersonID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
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

        public static bool IsPersonExist(int? PersonID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPersonExists", connection))
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

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPersonExistsByNationalNo", connection))
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