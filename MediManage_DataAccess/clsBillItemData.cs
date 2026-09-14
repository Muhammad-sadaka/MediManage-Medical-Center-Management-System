using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MediManage_DataAccess
{
    // 1. Data Transfer Object (DTO)
    public class clsBillItemDTO
    {
        public int? BillItemID { get; set; }
        public int? Bill_ID { get; set; }
        public int? ServiceTypeID { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }
        public decimal? Total { get; set; }

        public clsBillItemDTO(int? billItemID, int? bill_ID, int? serviceTypeID, string description, int? amount, decimal? total)
        {
            this.BillItemID = billItemID;
            this.Bill_ID = bill_ID;
            this.ServiceTypeID = serviceTypeID;
            this.Description = description;
            this.Amount = amount;
            this.Total = total;
        }
    }

    public class clsBillItemListDTO
    {
        public string ServicTypeName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
        public int? ServiceTypeID { get; set; }

        public clsBillItemListDTO(string servicTypeName,  string description, decimal? price, int? quantity, decimal? total, int? serviceTypeID)
        {
            this.ServicTypeName = servicTypeName;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Total = total;
            this.ServiceTypeID = serviceTypeID;
        }
    }

    public class clsBillItemsDataAccess
    {
        public static clsBillItemDTO GetBillItemInfoByID(int? BillItemID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetBillItemByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BillItemID", (object)BillItemID ?? DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsBillItemDTO
                                (
                                    reader["BillItemID"] == DBNull.Value ? null : (int?)reader["BillItemID"],
                                    reader["Bill_ID"] == DBNull.Value ? null : (int?)reader["Bill_ID"],
                                    reader["ServiceTypeID"] == DBNull.Value ? null : (int?)reader["ServiceTypeID"],
                                    reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                                    reader["Amount"] == DBNull.Value ? null : (int?)reader["Amount"],
                                    reader["Total"] == DBNull.Value ? null : (decimal?)reader["Total"]
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

        public static int? AddNewBillItem(clsBillItemDTO billItemDTO)
        {
            int? BillItemID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewBillItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Bill_ID", (object)billItemDTO.Bill_ID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ServiceTypeID", (object)billItemDTO.ServiceTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)billItemDTO.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", (object)billItemDTO.Amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Total", (object)billItemDTO.Total ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewBillItemID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        if (outputIdParam.Value != DBNull.Value)
                            BillItemID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.EventLogCreate();
                EventLog.WriteEntry(clsDataAccessSettings.sourceName, "Error: " + ex.Message, EventLogEntryType.Error);
            }

            return BillItemID;
        }

        public static bool UpdateBillItem(clsBillItemDTO billItemDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateBillItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BillItemID", (object)billItemDTO.BillItemID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Bill_ID", (object)billItemDTO.Bill_ID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ServiceTypeID", (object)billItemDTO.ServiceTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", (object)billItemDTO.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", (object)billItemDTO.Amount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Total", (object)billItemDTO.Total ?? DBNull.Value);

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

        public static List<clsBillItemListDTO> GetAllBillItems(int? BillID)
        {
            var billItemsList = new List<clsBillItemListDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllBillItems", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Bill_ID", (object)BillID ?? DBNull.Value);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                billItemsList.Add(new clsBillItemListDTO
                                (
                                    reader["ServicTypeName"] == DBNull.Value ? null : (string)reader["ServicTypeName"],
                                    reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                                    reader["Price"] == DBNull.Value ? null : (decimal?)reader["Price"],
                                    reader["Quantity"] == DBNull.Value ? null : (int?)reader["Quantity"],
                                    reader["Total"] == DBNull.Value ? null : (decimal?)reader["Total"],
                                    null
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

            return billItemsList;
        }

        public static bool DeleteBillItem(int? BillItemID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_DeleteBillItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BillItemID", (object)BillItemID ?? DBNull.Value);

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

        public static bool IsBillItemExist(int? BillItemID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CheckBillItemExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BillItemID", (object)BillItemID ?? DBNull.Value);

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