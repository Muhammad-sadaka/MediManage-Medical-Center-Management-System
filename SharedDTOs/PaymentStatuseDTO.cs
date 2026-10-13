using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class PaymentStatuseDTO
    {
    }
    public class clsPaymentStatusDTO
    {
        public int? PaymentStatusID { get; set; }
        public string PaymentStatusName { get; set; }

        public clsPaymentStatusDTO(int? paymentStatusID, string paymentStatusName)
        {
            this.PaymentStatusID = paymentStatusID;
            this.PaymentStatusName = paymentStatusName;
        }
    }
}
