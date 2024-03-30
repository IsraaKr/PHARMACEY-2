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
    public partial class F_Viewer : Form
    {
        public F_Viewer(Form f)
        {
            Form = f;
            InitializeComponent();
        }
        Form Form;
        private void F_Viewer_Load(object sender, EventArgs e)
        {
            documentViewer1.DocumentSource = Form;
        }
    }
}
