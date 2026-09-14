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
    public partial class frmAddBillItem : Form
    {
        public delegate void DataBackEventHandler(object sender, clsBillItemListDTO billItemList);

        public event DataBackEventHandler DataBack;

        public List<clsServiceTypeDTO> ServiceTypes = clsServiceType.GetAllServiceTypes();

        public frmAddBillItem()
        {
            InitializeComponent();
        }

        private void frmAddBillItem_Load(object sender, EventArgs e)
        {
            cbServiceType.DataSource = ServiceTypes.Select(t => t.ServicTypeName).ToList();
            cbServiceType.DisplayMember = "ServicTypeName";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? Quantity = Convert.ToInt16(numericUpDown1.Value);
            decimal? Total = clsBillItem.CalculateTotal(Convert.ToDecimal(tbPrice.Text),Quantity);

            clsBillItemListDTO billItemList = new clsBillItemListDTO
            (
              cbServiceType.Text.Trim(),
              tbDescription.Text.Trim(),
              Convert.ToDecimal(tbPrice.Text),
              Quantity,
              Total,
              ServiceTypes.Where(d => d.ServicTypeName == cbServiceType.Text).Select(d => d.ServiceTypeID).FirstOrDefault()
            );

            DataBack?.Invoke(this, billItemList);

            this.Close();
        }

        private void cbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPrice.Text = ServiceTypes.Where(d => d.ServicTypeName == cbServiceType.Text).Select(d => d.Price).FirstOrDefault().ToString();
        }
    }
}
