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
    public partial class ctrlBillItemHistory : UserControl
    {
        List<clsBillItemListDTO> BillItemList;

        public ctrlBillItemHistory()
        {
            InitializeComponent();
        }

        public void LoadDGVBillItems(clsBill Bill)
        {
            BillItemList = clsBillItem.GetAllBillItems(Bill.Bill_ID);
            RefreshBillsRecipesList();

            lblAmountRemaining.Text = "Amount Remaining: $" + Bill.AmountOfRemaining;
            lblAmountPaid.Text = "Amount Paid: $" + Bill.AmountOfPaid;
            lblTotalAmount.Text = "Total Amount: $" + Bill.TotalAmount;
            DGVBillItemList.Enabled = false;
        }

        public void LoadDGVBillItems(List<clsBillItemListDTO> BillItems)
        {
            BillItemList = BillItems;
            RefreshBillsRecipesList();

            decimal? Total = BillItemList.Sum(b => b.Total);
            lblAmountRemaining.Text = "Amount Remaining: $" + Total;
            lblAmountPaid.Text = "Amount Paid: $" + 0;
            lblTotalAmount.Text = "Total Amount: $" + Total;
        }

        public void ChangeGroubBoxText(string str)
        {
            groupBox1.Text = str;
        }

        private void ctrlBillItemHistory_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            DGVBillItemList.AutoGenerateColumns = false;
            DGVBillItemList.Columns.Clear();

            DGVBillItemList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServicTypeName", HeaderText = "Service Type", Name = "ServicTypeName" });

            DGVBillItemList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Description", Name = "Description" });

            DGVBillItemList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Price ($)", Name = "Price" });

            DGVBillItemList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Qty", Name = "Quantity" });

            DGVBillItemList.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Total", HeaderText = "Total ($)", Name = "Total" });

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Remove(X)";
            btnDelete.Text = "X";
            btnDelete.Name = "btnDelete";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            DGVBillItemList.Columns.Add(btnDelete);
        }

        private void RefreshBillsRecipesList()
        {
            DGVBillItemList.DataSource = BillItemList.Select(b => new
            {
                b.ServicTypeName,
                b.Description,
                b.Price,
                b.Quantity,
                b.Total
            }).ToList();
        }

        private void DGVBillItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ServiceType = DGVBillItemList.Rows[e.RowIndex].Cells["ServicTypeName"].Value.ToString();

            if (DGVBillItemList.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                if (BillItemList.RemoveAll(m => m.ServicTypeName == ServiceType) > 0)
                {
                    MessageBox.Show("Deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshBillsRecipesList();
                }
                else
                {
                    MessageBox.Show("Delete failed for This Bill Item.", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
