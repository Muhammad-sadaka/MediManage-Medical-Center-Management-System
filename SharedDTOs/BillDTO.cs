using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class BillDTO
    {
    }
    public class clsBillListDTO
    {
        public int? Bill_ID { get; set; }
        public string PatientName { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }

        public clsBillListDTO(int? bill_ID, string PatientName, DateTime? billDate, decimal? totalAmount, string Status)
        {
            this.Bill_ID = bill_ID;
            this.PatientName = PatientName;
            this.BillDate = billDate;
            this.TotalAmount = totalAmount;
            this.Status = Status;
        }
    }

    public class clsBillDTO
    {
        public int? Bill_ID { get; set; }
        public int? PatientID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? AmountOfPaid { get; set; }
        public decimal? AmountOfRemaining { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? PaymentStatusID { get; set; }

        public clsBillDTO(int? bill_ID, int? patientID, int? createdByUserID, DateTime? billDate,
            decimal? amountOfPaid, decimal? amountOfRemaining, decimal? totalAmount, int? paymentStatusID)
        {
            this.Bill_ID = bill_ID;
            this.PatientID = patientID;
            this.CreatedByUserID = createdByUserID;
            this.BillDate = billDate;
            this.AmountOfPaid = amountOfPaid;
            this.AmountOfRemaining = amountOfRemaining;
            this.TotalAmount = totalAmount;
            this.PaymentStatusID = paymentStatusID;
        }
    }
}
