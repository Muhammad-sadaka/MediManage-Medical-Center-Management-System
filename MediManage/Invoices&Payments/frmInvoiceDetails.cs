using MediManage_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class frmInvoiceDetails : Form
    {
        int? BillID;
        public frmInvoiceDetails(int? billID)
        {
            InitializeComponent();
            BillID = billID;
        }

        private void frmInvoiceDetails_Load(object sender, EventArgs e)
        {
            clsBill Bill = clsBill.Find(BillID);
            lblBillDate.Text = Bill.BillDate.ToString();
            lblCreatedBy.Text = Bill.UserInfo.UserName;
            lblPatientName.Text = Bill.PatientInfo.PersonInfo.FullName;
            lblPaymentStatus.Text = Bill.PaymentStatusInfo.PaymentStatusName;


            ctrlPaymentHistory1.LoadDGVPayments(BillID);
            ctrlPaymentHistory1.ChangeGroubBoxText("Section 2: Payment History");

            ctrlBillItemHistory1.LoadDGVBillItems(Bill);
            ctrlBillItemHistory1.ChangeGroubBoxText("Section 3: Bill Items");
        }
    }
}
