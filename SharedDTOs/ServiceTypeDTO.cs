using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class ServiceTypeDTO
    {
    }
    public class clsServiceTypeDTO
    {
        public int? ServiceTypeID { get; set; }
        public string ServicTypeName { get; set; }
        public decimal? Price { get; set; }

        public clsServiceTypeDTO(int? serviceTypeID, string servicTypeName, decimal? price)
        {
            this.ServiceTypeID = serviceTypeID;
            this.ServicTypeName = servicTypeName;
            this.Price = price;
        }
    }
}
