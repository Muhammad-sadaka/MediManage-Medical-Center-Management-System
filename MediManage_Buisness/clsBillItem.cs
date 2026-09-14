using System;
using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{

    public class clsBillItem
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsBillItemDTO BillItemDTO
        {
            get
            {
                return new clsBillItemDTO
                (
                    this.BillItemID,
                    this.Bill_ID,
                    this.ServiceTypeID,
                    this.Description,
                    this.Amount,
                    this.Total
                );
            }
        }

        public int? BillItemID { get; set; }
        public int? Bill_ID { get; set; }
        public int? ServiceTypeID { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public decimal? Total { get; set; }

        public clsBillItem(clsBillItemDTO dto, enMode cMode = enMode.AddNew)
        {
            this.BillItemID = dto.BillItemID;
            this.Bill_ID = dto.Bill_ID;
            this.ServiceTypeID = dto.ServiceTypeID;
            this.Description = dto.Description;
            this.Amount = dto.Amount;
            this.Total = dto.Total;
            this.Mode = cMode;
        }

        private bool _AddNewBillItem()
        {
            this.BillItemID = clsBillItemsDataAccess.AddNewBillItem(this.BillItemDTO);
            return (this.BillItemID.HasValue);
        }

        private bool _UpdateBillItem()
        {
            return clsBillItemsDataAccess.UpdateBillItem(this.BillItemDTO);
        }

        public static clsBillItem Find(int? ID)
        {
            clsBillItemDTO dto = clsBillItemsDataAccess.GetBillItemInfoByID(ID);

            if (dto != null)
                return new clsBillItem(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsBillItemListDTO> GetAllBillItems(int? BillID)
        {
            return clsBillItemsDataAccess.GetAllBillItems(BillID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBillItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBillItem();
            }

            return false;
        }

        public static bool DeleteBillItem(int? ID)
        {
            return clsBillItemsDataAccess.DeleteBillItem(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsBillItemsDataAccess.IsBillItemExist(ID);
        }

        public static decimal CalculateTotal(decimal? Price , int? Quantity)
        {
            return Price.Value * Quantity.Value;
        }
    }
}