using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;

namespace PhamaceySystem.Inheratenz_Forms
{
    public partial class F_Master_Graid : F_Master_Inheretanz
    {
        public F_Master_Graid()
        {
            InitializeComponent();
            view_inheretanz_butomes(true, false, false, true, true, false, true);

        }
        public override void view_inheretanz_butomes(bool neew, bool add, bool add_save, bool edite, bool delete, bool clear, bool print)
        {
            if (neew)
            {
                bar_neew.Visibility = 0;
                sp_new.Visibility = 0;
            }
            if (add)
            {
                bar_add.Visibility = 0;
                sp_add.Visibility = 0;
            }
            if (add_save)
            {
                bar_add_save.Visibility = 0;
                sp_add_save.Visibility = 0;
            }
            if (edite)
            {
                bar_edit.Visibility = 0;
                sp_edite.Visibility = 0;
            }
            if (delete)
            {
                bar_delete.Visibility = 0;
                sp_delete.Visibility = 0;
            }
            if (clear)
            {
                bar_clear.Visibility = 0;
                sp_clear.Visibility = 0;
            }
            if (print)
            {
                bar_print.Visibility = 0;
                sp_print.Visibility = 0;
            }
        }
        public override void Title(string s_title)
        {
            lbl_tiltle.Text = s_title;
           // lbl_tiltle.BackColor = Properties.Settings.Default.titel_graid_colore;

        }
        public virtual void gv_DoubleClick(object sender, EventArgs e)
        {

        }

        public virtual void gv_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public virtual void comb_page_num_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public virtual void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        public virtual void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        public virtual void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }
    }
}
