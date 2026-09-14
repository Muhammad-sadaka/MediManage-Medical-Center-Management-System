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
    public partial class frmAddPayment : Form
    {
        clsBill Bill = new clsBill();
        public frmAddPayment(int? bill)
        {
            InitializeComponent();
            Bill = clsBill.Find(bill); 
        }

        private void frmAddPayment_Load(object sender, EventArgs e)
        {
            cbPaymentMethod.DataSource = clsPaymentMethod.GetAllPaymentMethods();
            cbPaymentMethod.DisplayMember = "PaymentMethodName";

            ctrlPaymentHistory1.LoadDGVPayments(Bill.Bill_ID);

            if(Bill.AmountOfRemaining == 0)
                btnAddPayment.Enabled = false;
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            decimal? Amount = Convert.ToDecimal(tbAmount.Text);

            if (Bill.AmountOfRemaining < Amount)
            {
                MessageBox.Show("The Amount of paid is more than Amount Of Remaining.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Amount < 1)
            {
                MessageBox.Show("Add Amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPayment payment = new clsPayment();

            payment.Bill_ID = Bill.Bill_ID;
            payment.PaymentDate = DateTime.Now;
            payment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            payment.Amount = Amount;
            payment.PaymentMethodID = cbPaymentMethod.SelectedIndex + 1;

            if (payment.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateBill(Amount); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UpdateBill(decimal? Amount)
        {
            Bill.AmountOfPaid = Bill.AmountOfPaid + Amount;
            Bill.AmountOfRemaining = Bill.TotalAmount - Bill.AmountOfPaid;

            if (Bill.AmountOfRemaining == 0)
                Bill.PaymentStatusID = 1;
            else
                Bill.PaymentStatusID = 2;

            if (Bill.Save()) 
            {
                MessageBox.Show("Bill Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error:Bill Data Is not Saved Successfully.", "Did Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
