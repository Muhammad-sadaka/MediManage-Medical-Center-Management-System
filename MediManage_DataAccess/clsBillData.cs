using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    public class clsBillListDTO
    {
        public int? Bill_ID { get; set; }
        public string PatientName { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }

        public clsBillListDTO(int? bill_ID, string PatientName, DateTime? billDate, decimal? totalAmount,string Status)
        {
            this.Bill_ID = bill_ID;
            this.PatientName = PatientName;
            this.BillDate = billDate;
            this.TotalAmount = totalAmount;
            this.Status = Status;
        }
    }

    public class clsBillDTO
    {
        public int? Bill_ID { get; set; }
        public int? PatientID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? AmountOfPaid { get; set; }
        public decimal? AmountOfRemaining { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? PaymentStatusID { get; set; }

        public clsBillDTO(int? bill_ID, int? patientID, int? createdByUserID, DateTime? billDate,
            decimal? amountOfPaid, decimal? amountOfRemaining, decimal? totalAmount, int? paymentStatusID)
        {
            this.Bill_ID = bill_ID;
            this.PatientID = patientID;
            this.CreatedByUserID = createdByUserID;
            this.BillDate = billDate;
            this.AmountOfPaid = amountOfPaid;
            this.AmountOfRemaining = amountOfRemaining;
            this.TotalAmount = totalAmount;
            this.PaymentStatusID = paymentStatusID;
        }
    }

    public class clsBillsDataAccess
    {
        public static clsBillDTO GetBillInfoByID(int? Bill_ID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetBillByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Bill_ID", (object)Bill_ID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsBillDTO
                                (
                                    reader["Bill_ID"] == DBNull.Value ? null : (int?)reader["Bill_ID"],
                                    reader["PatientID"] == DBNull.Value ? null : (int?)reader["PatientID"],
                                    reader["CreatedByUserID"] == DBNull.Value ? null : (int?)reader["CreatedByUserID"],
                                    reader["BillDate"] == DBNull.Value ? null : (DateTime?)reader["BillDate"],
                                    reader["AmountOfPaid"] == DBNull.Value ? null : (decimal?)reader["AmountOfPaid"],
                                    reader["AmountOfRemaining"] == DBNull.Value ? null : (decimal?)reader["AmountOfRemaining"],
                                    reader["TotalAmount"] == DBNull.Value ? null : (decimal?)reader["TotalAmount"],
                                    reader["PaymentStatusID"] == DBNull.Value ? null : (int?)reader["PaymentStatusID"]
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

        public static int? AddNewBill(clsBillDTO billDTO)
        {
            int? Bill_ID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewBill", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PatientID", (object)billDTO.PatientID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)billDTO.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillDate", (object)billDTO.BillDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountOfPaid", (object)billDTO.AmountOfPaid ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountOfRemaining", (object)billDTO.AmountOfRemaining ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalAmount", (object)billDTO.TotalAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentStatusID", (object)billDTO.PaymentStatusID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewBillID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            Bill_ID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return Bill_ID;
        }

        public static bool UpdateBill(clsBillDTO billDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateBill", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Bill_ID", (object)billDTO.Bill_ID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PatientID", (object)billDTO.PatientID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)billDTO.CreatedByUserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BillDate", (object)billDTO.BillDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountOfPaid", (object)billDTO.AmountOfPaid ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountOfRemaining", (object)billDTO.AmountOfRemaining ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalAmount", (object)billDTO.TotalAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentStatusID", (object)billDTO.PaymentStatusID ?? DBNull.Value);

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

        public static List<clsBillListDTO> GetAllBills()
        {
            var billsList = new List<clsBillListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllBills", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                billsList.Add(new clsBillListDTO
                                (
                                    reader["Bill_ID"] == DBNull.Value ? null : (int?)reader["Bill_ID"],
                                    reader["PatientName"] == DBNull.Value ? null : (string)reader["PatientName"],
                                    reader["BillDate"] == DBNull.Value ? null : (DateTime?)reader["BillDate"],
                                    reader["TotalAmount"] == DBNull.Value ? null : (decimal?)reader["TotalAmount"],
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

            return billsList;
        }

        public static bool DeleteBill(int? Bill_ID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteBill", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Bill_ID", (object)Bill_ID ?? DBNull.Value);

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

        public static bool IsBillExist(int? Bill_ID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckBillExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Bill_ID", (object)Bill_ID ?? DBNull.Value);

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