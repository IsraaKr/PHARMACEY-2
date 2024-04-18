using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class F_Store_Med_ExpDate : Form
    {
        public F_Store_Med_ExpDate()
        {
            InitializeComponent();
            Get_Data("");
            this.Text = tit;
            lbl_tiltle.Text = tit;
            lbl_tiltle.BackColor = Properties.Settings.Default.titel_master_colore;

        }
        public string tit = "الأدوية المنتهية الصلاحية";
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

        T_OPeration_IN_Item TF_OP_IN_Item;

        T_Medician TF_Medician;
        Boolean Is_Double_Click = false;
        int id;
        public void Get_Data(string status_mess)
        {
            try
            {

                Is_Double_Click = false;
                cmdMedician = new ClsCommander<T_Medician>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

                TF_OP_IN_Item = cmdOpInItem.Get_All().FirstOrDefault();
                if (TF_OP_IN_Item != null)
                    Fill_Graid();


            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }




        public void Print_Data()
        {

            C_Master.print_header(lbl_tiltle.Text, gc);
        }



        private void Fill_Graid()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            if (month != 12)
            {
                month = month+1;
              
            }
           else if (month ==12)
            {
                month = 1;
                year = year + 1;

            }
            cmdMedician = new ClsCommander<T_Medician>();
            gc.DataSource = (from med in cmdOpInItem.Get_All().Where(l => l.in_item_expDate.Value.Month < month
                             && l.in_item_expDate.Value.Year <=year
                             && l.is_out != true)
                             join xxx in cmdMedician.Get_All()
                             on med.Med_id equals xxx.med_id into list
                             from yyy in list.DefaultIfEmpty()
                             select new
                             {
                                 id = med.in_item_id,
                                 med_id = med.Med_id,
                                 code =yyy.med_code,
                                 name = yyy.med_name,
                                 quntetey =yyy.med_total_now,
                                 datee = med.in_item_expDate,

                             }).OrderBy(l_id => l_id.id);

            gv.Columns["id"].Visible = false;
            gv.Columns[1].Visible = false;

            gv.Columns["code"].Caption = "الكود";
            gv.Columns["name"].Caption = "الاسم";
            gv.Columns[4].Caption = " الكمية الموجودة ";
            gv.Columns[5].Caption = "تاريخ انتهاء الصلاحية";

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

        public void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_Medician != null)
            // Fill_Controls();
        }

    
        public void gv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DateTime exp_date ;
            DateTime d = DateTime.Today;
            int yeare = d.Year;
            int month = d.Month;
            GridView gv = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                exp_date = Convert.ToDateTime(gv.GetRowCellValue(e.RowHandle, gv.Columns[5]).ToString());
               
                if (exp_date.Month < month && exp_date.Year <= yeare)
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.IndianRed);
                    e.Appearance.BackColor2 = Color.White;

                }
            }
        }

        private void gc_Click(object sender, EventArgs e)
        {

        }

        private void bar_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print_Data();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Get_Data("");
        }

        private void bar_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
