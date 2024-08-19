using DevExpress.XtraEditors;
using PhamaceySystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem
{
    public partial class F_Master_List : F_Master_Inheretanz
    {
        public F_Master_List()
        {
            InitializeComponent();
             view_inheretanz_butomes(false,true,false , true, true, false,true);
        }
        public override void view_inheretanz_butomes(bool neew, bool add, bool add_save, bool edite, bool delete, bool print, bool refresh)
        {

            if (neew && C_RoleManeger.GetRole("per_save"))
            {
                bar_neew.Visibility = 0;
                sp_new.Visibility = 0;
            }
            if (add && C_RoleManeger.GetRole("per_save"))
            {
                bar_add.Visibility = 0;
                sp_add.Visibility = 0;
            }
            if (add_save && C_RoleManeger.GetRole("per_save"))
            {
                bar_add_save.Visibility = 0;
                sp_add_save.Visibility = 0;
            }
            if (edite && C_RoleManeger.GetRole("per_edite"))
            {
                bar_edit.Visibility = 0;
                sp_edite.Visibility = 0;
            }
            if (delete && C_RoleManeger.GetRole("per_delete"))
            {
                bar_delete.Visibility = 0;
                sp_delete.Visibility = 0;
            }

            if (print && C_RoleManeger.GetRole("per_print"))
            {
                bar_print.Visibility = 0;
                sp_print.Visibility = 0;
            }
            if (refresh)
            {
                //bar_refresh.Visibility = 0;
                //sp_refresh.Visibility = 0;
            }

        }
        public virtual void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }
        public virtual void txt_addd_EditValueChanged(object sender, EventArgs e)
        {

        }

        public virtual void gv_DoubleClick(object sender, EventArgs e)
        {

        }

        public virtual void gv_KeyDown(object sender, KeyEventArgs e)
        {


        }
        public virtual void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Insert_Data();
            //if (e.KeyCode == Keys.F2)
            //    new();
            if (e.KeyCode == Keys.Delete)
                Delete_Data();
            if (e.KeyCode == Keys.Escape)
                clear_data(this.Controls);
        }

        private void lbl_tiltle_Click(object sender, EventArgs e)
        {

        }
    }
}
