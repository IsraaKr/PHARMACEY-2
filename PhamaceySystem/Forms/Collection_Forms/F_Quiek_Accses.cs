using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Store_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms
{
    public partial class F_Quiek_Accses : Form
    {
        public F_Quiek_Accses()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            F_Med f = new F_Med();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            F_In_Op f = new F_In_Op();
            f.MdiParent = this.MdiParent;
            f.ShowDialog();
        }

        private void F_Quiek_Accses_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            F_Out_Op f = new F_Out_Op();
            f.MdiParent = this.MdiParent;
            f.ShowDialog();
        }
    }
}

