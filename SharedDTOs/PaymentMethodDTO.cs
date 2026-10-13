using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class PaymentMethodDTO
    {
    }
    public class clsPaymentMethodDTO
    {
        public int? PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }

        public clsPaymentMethodDTO(int? paymentMethodID, string paymentMethodName)
        {
            this.PaymentMethodID = paymentMethodID;
            this.PaymentMethodName = paymentMethodName;
        }
    }
}
