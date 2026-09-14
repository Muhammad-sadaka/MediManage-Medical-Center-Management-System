using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsPaymentListDTO
    {
        public string PatientName { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentMethod { get; set; }

        public clsPaymentListDTO(string patientName, DateTime? paymentDate, decimal? amount,string paymentMethod)
        {
            this.PatientName = patientName;
            this.PaymentDate = paymentDate;
            this.Amount = amount;
            this.PaymentMethod = paymentMethod;
        }
    }


    public class clsPaymentDTO
    {
        public int? PaymentID { get; set; }
        public int? Bill_ID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public decimal? Amount { get; set; }
        public int? PaymentMethodID { get; set; }

        public clsPaymentDTO(int? paymentID, int? bill_ID, DateTime? paymentDate, int? createdByUserID, decimal? amount,int? paymentMethodID)
        {
            this.PaymentID = paymentID;
            this.Bill_ID = bill_ID;
            this.PaymentDate = paymentDate;
            this.CreatedByUserID = createdByUserID;
            this.Amount = amount;
            this.PaymentMethodID = paymentMethodID;
        }
    }

    // 2. Data Access Layer
    public class clsPaymentsDataAccess
    {
        public static clsPaymentDTO GetPaymentInfoByID(int? PaymentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPaymentByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsPaymentDTO
                                (
                                    reader["PaymentID"] == DBNull.Value ? null : (int?)reader["PaymentID"],
                                    reader["Bill_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Bill_ID"]),
                                    reader["PaymentDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["PaymentDate"]),
                                    reader["CreatedByUserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CreatedByUserID"]),
                                    reader["Amount"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Amount"]),
                                    reader["paymentMethodID"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["paymentMethodID"])
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

        public static int? AddNewPayment(clsPaymentDTO dto)
        {
            int? paymentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewPayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Bill_ID", (object)dto.Bill_ID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentDate", (object)dto.PaymentDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)dto.Amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentMethodID", (object)dto.PaymentMethodID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            paymentID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return paymentID;
        }

        public static bool UpdatePayment(clsPaymentDTO dto)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdatePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)dto.PaymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bill_ID", (object)dto.Bill_ID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentDate", (object)dto.PaymentDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)dto.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)dto.Amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentMethodID", (object)dto.PaymentMethodID ?? DBNull.Value);

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

        public static List<clsPaymentListDTO> GetAllPayments(int? BillID)
        {
            var paymentsList = new List<clsPaymentListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllPayments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Bill_ID", (object)BillID ?? DBNull.Value);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                paymentsList.Add(new clsPaymentListDTO
                                (
                                    reader["Patient Name"] == DBNull.Value ? null : (string)reader["Patient Name"],
                                    reader["Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Date"]),
                                    reader["Amount ($)"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Amount ($)"]),
                                    reader["Payment Method"] == DBNull.Value ? null : (string)reader["Payment Method"]
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

            return paymentsList;
        }

        public static bool DeletePayment(int? PaymentID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeletePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

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

        public static bool IsPaymentExist(int? PaymentID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckPaymentExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

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