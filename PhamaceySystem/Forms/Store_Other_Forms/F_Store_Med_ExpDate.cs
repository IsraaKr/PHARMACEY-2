using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Inheratenz_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Store_Other_Forms
{
    public partial class F_Store_Med_ExpDate : F_Master_Graid
    {
        public F_Store_Med_ExpDate()
        {
            InitializeComponent();
     
            view_inheretanz_butomes(true, false, false, false, false, false, true);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "الأدوية المنتهية الصلاحية";
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
     
        T_OPeration_IN_Item TF_OP_IN_Item;

        T_Medician TF_Medician;
        Boolean Is_Double_Click = false;
        int id;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdMedician = new ClsCommander<T_Medician>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

                TF_OP_IN_Item = cmdOpInItem.Get_All().FirstOrDefault();
                if (TF_OP_IN_Item != null)
                    Fill_Graid();
                base.Get_Data(status_mess);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }
        public override void neew()
        {

        }
        public override void Update_Data()
        {


        }
        public override void Delete_Data()
        {


        }
        public override void clear_data(Control.ControlCollection s_controls)
        {
            base.clear_data(s_controls);

        }
        public override void Print_Data()
        {
            base.Print_Data();
            C_Master.print_header(lbl_tiltle.Text, gc);
        }



        private void Fill_Graid()
        {
            gc.DataSource = (from med in cmdOpInItem.Get_All().Where(l => l.in_item_expDate <= DateTime.Today)
                             select new
                             {
                                 id = med.in_item_id,
                                 med_id= med.T_Medician.med_id,
                                 code = med.T_Medician.med_code,
                                 name = med.T_Medician.med_name,
                                 quntetey = med.in_item_quntity,
                                 datee = med.in_item_expDate,
                                 
                             }).OrderBy(l_id => l_id.id);

            gv.Columns["id"].Visible = false;
            gv.Columns[2].Visible = false;

            gv.Columns["code"].Caption = "الكود";
            gv.Columns["name"].Caption = "الاسم";
            gv.Columns[3].Caption = "الكمية ";
            gv.Columns[4].Caption = "تاريخ انتهاء الصلاحية";

            gv.BestFitColumns();
        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]));
                TF_Medician = cmdMedician.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]));
                TF_Medician = cmdMedician.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_Medician != null)
            // Fill_Controls();
        }

        public override void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }
        public override void gv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }
    }
}
