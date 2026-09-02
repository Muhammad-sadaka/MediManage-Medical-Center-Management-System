namespace MediManage_Business
{
    using System;
    using System.Collections.Generic;
    using MediManage_DataAccess;

    // 3. Business Layer
    public class clsPaymentMethod
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPaymentMethodDTO DTO
        {
            get
            {
                return new clsPaymentMethodDTO
                (
                    this.PaymentMethodID,
                    this.PaymentMethodName
                );
            }
        }

        public int? PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }

        public clsPaymentMethod(clsPaymentMethodDTO dto, enMode cMode = enMode.AddNew)
        {
            this.PaymentMethodID = dto.PaymentMethodID;
            this.PaymentMethodName = dto.PaymentMethodName;
            this.Mode = cMode;
        }

        private bool _AddNewPaymentMethod()
        {
            this.PaymentMethodID = clsPaymentMethodsDataAccess.AddNewPaymentMethod(this.DTO);
            return (this.PaymentMethodID.HasValue);
        }

        private bool _UpdatePaymentMethod()
        {
            return clsPaymentMethodsDataAccess.UpdatePaymentMethod(this.DTO);
        }

        public static clsPaymentMethod Find(int? ID)
        {
            clsPaymentMethodDTO dto = clsPaymentMethodsDataAccess.GetPaymentMethodInfoByID(ID);

            if (dto != null)
                return new clsPaymentMethod(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsPaymentMethodDTO> GetAllPaymentMethods()
        {
            return clsPaymentMethodsDataAccess.GetAllPaymentMethods();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPaymentMethod())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePaymentMethod();
            }

            return false;
        }

        public static bool DeletePaymentMethod(int? ID)
        {
            return clsPaymentMethodsDataAccess.DeletePaymentMethod(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsPaymentMethodsDataAccess.IsPaymentMethodExist(ID);
        }
    }
}