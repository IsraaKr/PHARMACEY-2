using DevExpress.XtraEditors;
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
             view_inheretanz_butomes(false,true,false , true, true, true, false,true);
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
