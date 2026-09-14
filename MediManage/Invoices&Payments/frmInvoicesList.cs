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
    public partial class frmInvoicesList : Form
    {
        List<clsBillListDTO> BillsData = clsBill.GetAllBills();

        public frmInvoicesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddInvoice frm = new frmAddInvoice();
            frm.ShowDialog();
            RefreshBillsList();
        }

        private void frmInvoicesList_Load(object sender, EventArgs e)
        {
            foreach (string s in clsPaymentStatus.GetAllPaymentStatuses().Select(p => p.PaymentStatusName).ToList()) cbStatuses.Items.Add(s);
            cbStatuses.SelectedIndex = 0;

            SetupDataGridViewColumns();
            RefreshBillsList();
        }

        private void SetupDataGridViewColumns()
        {
            DGVInvoicesList.AutoGenerateColumns = false;
            DGVInvoicesList.Columns.Clear();

            DGVInvoicesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Bill_ID", HeaderText = "ID", Name = "Bill_ID" });

            DGVInvoicesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PatientName", HeaderText = "Patient Name", Name = "PatientName" });

            DGVInvoicesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BillDate", HeaderText = "Date", Name = "BillDate" });

            DGVInvoicesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalAmount", HeaderText = "Total Amount", Name = "TotalAmount" });

            DGVInvoicesList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status" });

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.HeaderText = "Actions";
            btnView.Text = "View";
            btnView.Name = "btnView";
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.UseColumnTextForButtonValue = true;
            DGVInvoicesList.Columns.Add(btnView);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Pay";
            btnDelete.Name = "btnPay";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVInvoicesList.Columns.Add(btnDelete);
        }

        private void RefreshBillsList()
        {
            var billsData = clsBill.GetAllBills();

            BillsData = billsData;

            DGVInvoicesList.DataSource = billsData.Select(p => new
            {
                p.Bill_ID,
                p.PatientName,
                p.BillDate,
                p.TotalAmount,
                p.Status
            }).ToList();

            lblTotalRecords.Text = $"Total: {DGVInvoicesList.RowCount} records";
        }

        private void DGVInvoicesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int BillID = Convert.ToInt32(DGVInvoicesList.Rows[e.RowIndex].Cells["Bill_ID"].Value);

            if (DGVInvoicesList.Columns[e.ColumnIndex].Name == "btnView")
            {
                frmInvoiceDetails frm = new frmInvoiceDetails(BillID);
                frm.ShowDialog();
            }
            else if (DGVInvoicesList.Columns[e.ColumnIndex].Name == "btnPay")
            {
                frmAddPayment frm = new frmAddPayment(BillID);
                frm.ShowDialog();
                RefreshBillsList();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DGVInvoicesList.DataSource = BillsData.Select(b => new
            {
                b.Bill_ID,
                b.PatientName,
                b.BillDate,
                b.TotalAmount,
                b.Status
            }).Where(b => b.BillDate.Value.Date == dateTimePicker1.Value.Date).ToList();

            lblTotalRecords.Text = $"Total: {DGVInvoicesList.RowCount} records";
        }

        private void cbStatuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatuses.SelectedIndex == 0)
                dateTimePicker1_ValueChanged(null, null);
            else
            {
                DGVInvoicesList.DataSource = BillsData.Select(b => new
                {
                    b.Bill_ID,
                    b.PatientName,
                    b.BillDate,
                    b.TotalAmount,
                    b.Status
                }).Where(b => b.Status == cbStatuses.SelectedItem.ToString()).ToList();
                lblTotalRecords.Text = $"Total: {DGVInvoicesList.RowCount} records";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPatient.Text) && tbPatient.Text != "Enter Patient Name...")
            {
                DGVInvoicesList.DataSource = BillsData.Select(b => new
                {
                    b.Bill_ID,
                    b.PatientName,
                    b.BillDate,
                    b.TotalAmount,
                    b.Status
                }).Where(E => E.PatientName.StartsWith(tbPatient.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                DGVInvoicesList.DataSource = BillsData.Select(b => new
                {
                    b.Bill_ID,
                    b.PatientName,
                    b.BillDate,
                    b.TotalAmount,
                    b.Status
                }).ToList();
            }

            lblTotalRecords.Text = $"Total: {DGVInvoicesList.RowCount} records";
        }

        private void tbPatient_Enter(object sender, EventArgs e)
        {
            if (tbPatient.Text == "Enter Patient Name...")
                tbPatient.Clear();
            tbPatient.ForeColor = Color.Black;
        }

        private void tbPatient_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPatient.Text))
            {
                tbPatient.ForeColor = Color.Gray;
                tbPatient.Text = "Enter Patient Name...";
            }
        }
    }
}
