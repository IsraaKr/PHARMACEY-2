using PhamaceySystem.Classes;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Store_Forms;
using PhamaceySystem.Forms.Store_OP_Forms;
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
            SetRoles();
        }
        private void SetRoles()
        {
           
            if (!C_RoleManeger.GetRole("per_in"))
            {
                btn_in_op.Enabled = false;

            }
            if (!C_RoleManeger.GetRole("per_out"))
            {
                btn_out_op.Enabled = false;


            }
            if (!C_RoleManeger.GetRole("per_dam"))
            {
                btn_dam_op.Enabled = false;

            }
            if (!C_RoleManeger.GetRole("per_med"))
            {
                btn_add_med.Enabled = false;

            }
            if (!C_RoleManeger.GetRole("per_thwabet"))
            {
            }
            if (!C_RoleManeger.GetRole("per_rep"))
            {

            }
            if (!C_RoleManeger.GetRole("per_sysRecord"))
            {

            }
            if (!C_RoleManeger.GetRole("per_seting"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Users"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Db"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Db"))
            {

            }
            
            if (!C_RoleManeger.GetRole("per_save"))
            {
                btn_add_med.Enabled = false;
            }
            
            if (!C_RoleManeger.GetRole("per_delete"))
            {

            }
            
             if (!C_RoleManeger.GetRole("per_edite"))
            {

            }
            
            if (!C_RoleManeger.GetRole("per_print"))
            {

            }
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
          //  f.MdiParent = this.MdiParent;
            f.ShowDialog();
        }

        private void F_Quiek_Accses_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            F_Out_Op f = new F_Out_Op();
          //  f.MdiParent = this.MdiParent;
            f.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            F_Med f = new F_Med();
          //  f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            F_Dameg_Op f = new F_Dameg_Op();
           // f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

