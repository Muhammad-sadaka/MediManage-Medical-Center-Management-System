using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsPaymentStatus
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPaymentStatusDTO DTO
        {
            get
            {
                return new clsPaymentStatusDTO
                (
                    this.PaymentStatusID,
                    this.PaymentStatusName
                );
            }
        }

        public int? PaymentStatusID { get; set; }
        public string PaymentStatusName { get; set; }

        public clsPaymentStatus(clsPaymentStatusDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PaymentStatusID = dto.PaymentStatusID;
            this.PaymentStatusName = dto.PaymentStatusName;
            this.Mode = cMode;
        }

        private bool _AddNewPaymentStatus()
        {
            this.PaymentStatusID = clsPaymentStatusesDataAccess.AddNewPaymentStatus(this.DTO);
            return (this.PaymentStatusID.HasValue);
        }

        private bool _UpdatePaymentStatus()
        {
            return clsPaymentStatusesDataAccess.UpdatePaymentStatus(this.DTO);
        }

        public static clsPaymentStatus Find(int? ID)
        {
            clsPaymentStatusDTO dto = clsPaymentStatusesDataAccess.GetPaymentStatusInfoByID(ID);

            if (dto != null)
                return new clsPaymentStatus(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPaymentStatusDTO> GetAllPaymentStatuses()
        {
            return clsPaymentStatusesDataAccess.GetAllPaymentStatuses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPaymentStatus())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePaymentStatus();
            }

            return false;
        }

        public static bool DeletePaymentStatus(int? ID)
        {
            return clsPaymentStatusesDataAccess.DeletePaymentStatus(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPaymentStatusesDataAccess.IsPaymentStatusExist(ID);
        }
    }
}