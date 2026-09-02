using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsAppointmentDTO
    {
        public int? AppointmentID { get; set; }
        public int? PatientID { get; set; }
        public int? DoctorID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? AppointmentCaseID { get; set; }
        public byte? Duration { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }

        public clsAppointmentDTO(int? appointmentID, int? patientID, int? doctorID, int? createdByUserID,
            DateTime? bookingDate, DateTime? appointmentDate, int? appointmentCaseID, byte? duration, string reason, string notes)
        {
            this.AppointmentID = appointmentID;
            this.PatientID = patientID;
            this.DoctorID = doctorID;
            this.CreatedByUserID = createdByUserID;
            this.BookingDate = bookingDate;
            this.AppointmentDate = appointmentDate;
            this.AppointmentCaseID = appointmentCaseID;
            this.Duration = duration;
            this.Reason = reason;
            this.Notes = notes;
        }
    }

    public class clsTodayAppointmentDTO
    {
        public DateTime? Time { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }

        public clsTodayAppointmentDTO(DateTime? time, string patientName, string doctorName, string status)
        {
            Time = time;
            PatientName = patientName;
            DoctorName = doctorName;
            Status = status;
        }
    }

    public class clsAppointmentsDataAccess
    {
        public static clsAppointmentDTO GetAppointmentInfoByID(int? AppointmentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAppointmentByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AppointmentID", (object)AppointmentID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsAppointmentDTO
                                (
                                    reader["AppointmentID"] == DBNull.Value ? null : (int?)reader["AppointmentID"],
                                    reader["PatientID"] == DBNull.Value ? null : (int?)reader["PatientID"],
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["CreatedByUserID"] == DBNull.Value ? null : (int?)reader["CreatedByUserID"],
                                    reader["BookingDate"] == DBNull.Value ? null : (DateTime?)reader["BookingDate"],
                                    reader["AppointmentDate"] == DBNull.Value ? null : (DateTime?)reader["AppointmentDate"],
                                    reader["AppointmentCaseID"] == DBNull.Value ? null : (int?)reader["AppointmentCaseID"],
                                    reader["Duration"] == DBNull.Value ? null : (byte?)reader["Duration"],
                                    reader["Reason"] == DBNull.Value ? null : (string)reader["Reason"],
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

        public static int? AddNewAppointment(clsAppointmentDTO appointmentDTO)
        {
            int? AppointmentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PatientID", (object)appointmentDTO.PatientID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DoctorID", (object)appointmentDTO.DoctorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)appointmentDTO.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BookingDate", (object)appointmentDTO.BookingDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointmentDate", (object)appointmentDTO.AppointmentDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointmentCaseID", (object)appointmentDTO.AppointmentCaseID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Duration", (object)appointmentDTO.Duration ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Reason", (object)appointmentDTO.Reason ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)appointmentDTO.Notes ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewAppointmentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            AppointmentID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return AppointmentID;
        }

        public static bool UpdateAppointment(clsAppointmentDTO appointmentDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AppointmentID", (object)appointmentDTO.AppointmentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PatientID", (object)appointmentDTO.PatientID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DoctorID", (object)appointmentDTO.DoctorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)appointmentDTO.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BookingDate", (object)appointmentDTO.BookingDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointmentDate", (object)appointmentDTO.AppointmentDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AppointmentCaseID", (object)appointmentDTO.AppointmentCaseID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Duration", (object)appointmentDTO.Duration ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Reason", (object)appointmentDTO.Reason ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Notes", (object)appointmentDTO.Notes ?? DBNull.Value);

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

        public static List<clsAppointmentDTO> GetAllAppointments()
        {
            var appointmentsList = new List<clsAppointmentDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllAppointments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointmentsList.Add(new clsAppointmentDTO
                                (
                                    reader["AppointmentID"] == DBNull.Value ? null : (int?)reader["AppointmentID"],
                                    reader["PatientID"] == DBNull.Value ? null : (int?)reader["PatientID"],
                                    reader["DoctorID"] == DBNull.Value ? null : (int?)reader["DoctorID"],
                                    reader["CreatedByUserID"] == DBNull.Value ? null : (int?)reader["CreatedByUserID"],
                                    reader["BookingDate"] == DBNull.Value ? null : (DateTime?)reader["BookingDate"],
                                    reader["AppointmentDate"] == DBNull.Value ? null : (DateTime?)reader["AppointmentDate"],
                                    reader["AppointmentCaseID"] == DBNull.Value ? null : (int?)reader["AppointmentCaseID"],
                                    reader["Duration"] == DBNull.Value ? null : (byte?)reader["Duration"],
                                    reader["Reason"] == DBNull.Value ? null : (string)reader["Reason"],
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

            return appointmentsList;
        }

        public static bool DeleteAppointment(int? AppointmentID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteAppointment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AppointmentID", (object)AppointmentID ?? DBNull.Value);

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

        public static bool IsAppointmentExist(int? AppointmentID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckAppointmentExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AppointmentID", (object)AppointmentID ?? DBNull.Value);

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

        public static List<clsTodayAppointmentDTO> GetTodayAppointments()
        {
            var appointmentsList = new List<clsTodayAppointmentDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetTodayAppointments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointmentsList.Add(new clsTodayAppointmentDTO
                                (
                                    reader["Time"] == DBNull.Value ? null : (DateTime?)reader["Time"],
                                    reader["Patient Name"] == DBNull.Value ? null : (string)reader["Patient Name"],
                                    reader["Doctor Name"] == DBNull.Value ? null : (string)reader["Doctor Name"],
                                    reader["Status"] == DBNull.Value ? null : (string)reader["Status"]
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

            return appointmentsList;
        }
    }
}