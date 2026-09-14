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
    public partial class frmAnalysisDetails : Form
    {
        public frmAnalysisDetails(int AnalysisID)
        {
            InitializeComponent();
            ctrlAnalysisInfo1.LoadAnalysisInfoData(AnalysisID);
        }
    }
}
