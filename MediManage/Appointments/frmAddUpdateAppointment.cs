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
    public partial class frmAddUpdateAppointment : Form
    {
        public frmAddUpdateAppointment()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd   hh:mm tt";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
