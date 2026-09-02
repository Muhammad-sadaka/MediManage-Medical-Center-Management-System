using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPaymentDTO DTO
        {
            get
            {
                return new clsPaymentDTO
                (
                    this.PaymentID,
                    this.Bill_ID,
                    this.PaymentDate,
                    this.CreatedByUserID,
                    this.Amount
                );
            }
        }

        public int? PaymentID { get; set; }
        public int? Bill_ID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public decimal? Amount { get; set; }

        public clsPayment(clsPaymentDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PaymentID = dto.PaymentID;
            this.Bill_ID = dto.Bill_ID;
            this.PaymentDate = dto.PaymentDate;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.Amount = dto.Amount;
            this.Mode = cMode;
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentsDataAccess.AddNewPayment(this.DTO);
            return (this.PaymentID.HasValue);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentsDataAccess.UpdatePayment(this.DTO);
        }

        public static clsPayment Find(int? ID)
        {
            clsPaymentDTO dto = clsPaymentsDataAccess.GetPaymentInfoByID(ID);

            if (dto != null)
                return new clsPayment(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPaymentDTO> GetAllPayments()
        {
            return clsPaymentsDataAccess.GetAllPayments();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePayment();
            }

            return false;
        }

        public static bool DeletePayment(int? ID)
        {
            return clsPaymentsDataAccess.DeletePayment(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPaymentsDataAccess.IsPaymentExist(ID);
        }
    }
}