using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{
    public class clsBill
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsBillDTO BillDTO
        {
            get
            {
                return new clsBillDTO
                (
                    this.Bill_ID,
                    this.PatientID,
                    this.CreatedByUserID,
                    this.BillDate,
                    this.AmountOfPaid,
                    this.AmountOfRemaining,
                    this.TotalAmount,
                    this.PaymentStatusID
                );
            }
        }

        public int? Bill_ID { get; set; }
        public int? PatientID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? AmountOfPaid { get; set; }
        public decimal? AmountOfRemaining { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? PaymentStatusID { get; set; }
        public clsUser UserInfo { get; set; }
        public clsPaymentStatus PaymentStatusInfo { get; set; }
        public clsPatient PatientInfo { get; set; }




        public clsBill()
        {
            this.Bill_ID = null;
            this.PatientID = null;
            this.CreatedByUserID = null;
            this.BillDate = null;
            this.AmountOfPaid = null;
            this.AmountOfRemaining = null;
            this.TotalAmount = null;
            this.PaymentStatusID = null;
            this.UserInfo = null;
            this.PaymentStatusInfo = null;
            this.PatientInfo = null;
            this.Mode = enMode.AddNew;
        }

        public clsBill(clsBillDTO dto, enMode cMode = enMode.AddNew)
        {
            this.Bill_ID = dto.Bill_ID;
            this.PatientID = dto.PatientID;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.BillDate = dto.BillDate;
            this.AmountOfPaid = dto.AmountOfPaid;
            this.AmountOfRemaining = dto.AmountOfRemaining;
            this.TotalAmount = dto.TotalAmount;
            this.PaymentStatusID = dto.PaymentStatusID;
            this.UserInfo = clsUser.Find(CreatedByUserID);
            this.PaymentStatusInfo = clsPaymentStatus.Find(PaymentStatusID);
            this.PatientInfo = clsPatient.Find(PatientID);
            this.Mode = cMode;
        }

        private bool _AddNewBill()
        {
            this.Bill_ID = clsBillsDataAccess.AddNewBill(this.BillDTO);
            return (this.Bill_ID.HasValue);
        }

        private bool _UpdateBill()
        {
            return clsBillsDataAccess.UpdateBill(this.BillDTO);
        }

        public static clsBill Find(int? ID)
        {
            clsBillDTO dto = clsBillsDataAccess.GetBillInfoByID(ID);

            if (dto != null)
                return new clsBill(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsBillListDTO> GetAllBills()
        {
            return clsBillsDataAccess.GetAllBills();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBill())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBill();
            }

            return false;
        }

        public static bool DeleteBill(int? ID)
        {
            return clsBillsDataAccess.DeleteBill(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsBillsDataAccess.IsBillExist(ID);
        }
    }
}