using MediManage.Global_Classes;
using MediManage_Business;
using MediManage_DataAccess;
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
        List<clsBillItemListDTO> BillItemList = new List<clsBillItemListDTO>();

        clsBill Bill = new clsBill();
        frmAddBillItem frm = new frmAddBillItem();

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
            frm = new frmAddBillItem();
            frm.DataBack += Form2_DataBack;
            frm.ShowDialog();
            ctrlBillItemHistory1.LoadDGVBillItems(BillItemList);
        }

        private void Form2_DataBack(object sender, clsBillItemListDTO BillItemList)
        {
            this.BillItemList.Add(BillItemList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clsPatient.IsExist(tbNationalNo.Text))
            {
                ctrlPatientInfoSummary1.LoadPatientInfoData(tbNationalNo.Text);
                Bill.PatientID = ctrlPatientInfoSummary1.PatientID;
            }
            else
            {
                MessageBox.Show("No Patient Found With This National No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Bill.PatientID.HasValue)
            {
                MessageBox.Show("Search about Examination First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BillItemList.Count < 1)
            {
                MessageBox.Show("You should add at least one Bill Item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bill.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Bill.BillDate = DateTime.Now;
            Bill.AmountOfPaid = 0;
            Bill.AmountOfRemaining = BillItemList.Sum(b => b.Total);
            Bill.TotalAmount = Bill.AmountOfRemaining;
            Bill.PaymentStatusID = 3;

            if (Bill.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var Item in BillItemList)
            {
                clsBillItem billItem = new clsBillItem( new clsBillItemDTO
                (
                    null,
                    Bill.Bill_ID,
                    Item.ServiceTypeID,
                    Item.Description,
                    Item.Quantity,
                    Item.Total
                ));
                billItem.Save();
            }
        }

        private void frmAddInvoice_Load(object sender, EventArgs e)
        {
            tbNationalNo.Enter += clsUIActions.tbNationalNo_Enter;
            tbNationalNo.Leave += clsUIActions.tbNationalNo_Leave;
        }
    }
}
