using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class BillItemDTO
    {
    }
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

        public clsBillItemListDTO(string servicTypeName, string description, decimal? price, int? quantity, decimal? total, int? serviceTypeID)
        {
            this.ServicTypeName = servicTypeName;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Total = total;
            this.ServiceTypeID = serviceTypeID;
        }
    }

}
