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
    public partial class ctrlPaymentHistory : UserControl
    {
        public ctrlPaymentHistory()
        {
            InitializeComponent();
        }

        public void LoadDGVPayments(int? BillID)
        {
            DGVPaymentHistory.DataSource = clsPayment.GetAllPayments(BillID);
        }

        public void ChangeGroubBoxText(string str)
        {
            groupBox2.Text = str;
        }
    }
}
