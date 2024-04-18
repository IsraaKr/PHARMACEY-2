using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Report_Forms
{
    public partial class F_Viewer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public F_Viewer(object f)
        {
            Form = f;
            InitializeComponent();
        }
        public F_Viewer()
        {
          
            InitializeComponent();
        }
        object Form;
        private void F_Viewer_Load(object sender, EventArgs e)
        {
            //var x = new XtraReporttest();
            //documentViewer1.DocumentSource = x;
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
