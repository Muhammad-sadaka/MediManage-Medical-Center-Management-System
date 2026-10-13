using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class PaymentDTO
    {
    }
    public class clsPaymentListDTO
    {
        public string PatientName { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentMethod { get; set; }

        public clsPaymentListDTO(string patientName, DateTime? paymentDate, decimal? amount, string paymentMethod)
        {
            this.PatientName = patientName;
            this.PaymentDate = paymentDate;
            this.Amount = amount;
            this.PaymentMethod = paymentMethod;
        }
    }


    public class clsPaymentDTO
    {
        public int? PaymentID { get; set; }
        public int? Bill_ID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CreatedByUserID { get; set; }
        public decimal? Amount { get; set; }
        public int? PaymentMethodID { get; set; }

        public clsPaymentDTO(int? paymentID, int? bill_ID, DateTime? paymentDate, int? createdByUserID, decimal? amount, int? paymentMethodID)
        {
            this.PaymentID = paymentID;
            this.Bill_ID = bill_ID;
            this.PaymentDate = paymentDate;
            this.CreatedByUserID = createdByUserID;
            this.Amount = amount;
            this.PaymentMethodID = paymentMethodID;
        }
    }
}
