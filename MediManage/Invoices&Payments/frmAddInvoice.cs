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
    public partial class frmAddInvoice : Form
    {
        public frmAddInvoice()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmInvoiceDetails frm  = new frmInvoiceDetails();
            frm.ShowDialog();
        }
    }
}
