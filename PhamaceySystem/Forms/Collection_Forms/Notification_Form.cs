using PhamaceySystem.Forms.Medicin_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Collection_Forms
{
    public partial class Notification_Form : Form
    {
        public Notification_Form( string mess)
        {
            InitializeComponent();
            lbl_note.Text = mess;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_note_Click(object sender, EventArgs e)
        {
            F_Med_Minimem f = new F_Med_Minimem();
            f.ShowDialog();
        }
    }
}
