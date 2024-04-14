using PhamaceySystem.Forms.Store_Other_Forms;
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
    public partial class F_exp_date_notification : Form
    {
        public F_exp_date_notification(string title, string mess)
        {
            InitializeComponent();
            lbl_note.Text = title;
            labelControl1.Text = mess;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void lbl_note_Click(object sender, EventArgs e)
        {
            F_Store_Med_ExpDate f = new F_Store_Med_ExpDate();
            f.ShowDialog();
        }

  

        private void labelControl1_Click(object sender, EventArgs e)
        {
            F_Store_Med_ExpDate f = new F_Store_Med_ExpDate();
            f.ShowDialog();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            F_Store_Med_ExpDate f = new F_Store_Med_ExpDate();
            f.ShowDialog();
        }

        private void F_exp_date_notification_Click(object sender, EventArgs e)
        {
            F_Store_Med_ExpDate f = new F_Store_Med_ExpDate();
            f.ShowDialog();
        }
    }
}

