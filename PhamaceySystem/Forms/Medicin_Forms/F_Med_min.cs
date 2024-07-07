using DevExpress.Utils.Svg;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Medicin_Forms
{
    public partial class F_Med_min : Form
    {
        public F_Med_min()
        {
            InitializeComponent();
            lbl_tiltle.Text = tit;
            this.Text = tit;
            lbl_tiltle.BackColor = Properties.Settings.Default.titel_master_colore;

        }


        public string tit = "الأدوية التي شارفت على الانتهاء";
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();


        T_Medician TF_Medician;
        //   bool Is_Double_Click = false;
     //   int id;
        public void Get_Data(string status_mess)
        {
            try
            {
                //  clear_data(this.Controls);
                //   Is_Double_Click = false;
                cmdMedician = new ClsCommander<T_Medician>();
                TF_Medician = cmdMedician.Get_All().FirstOrDefault();
                if (TF_Medician != null)
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
            var data = (from med in cmdMedician.Get_All().Where(l => l.med_total_now <= l.med_minimum + (l.med_minimum * 50 / 100))
                        select new
                        {
                            id = med.med_id,
                            code = med.med_code,
                            name = med.med_name,
                            min = med.med_minimum,
                            total = med.med_total_now

                        }).OrderBy(l_id => l_id.id);
            if (data != null && data.Count() > 0)
            {

                gc.DataSource = data;

                gv.Columns["id"].Visible = false;
                gv.Columns["code"].Caption = "الكود";
                gv.Columns["name"].Caption = "الاسم";
                gv.Columns["min"].Caption = "الحدالأدنى";
                gv.Columns[4].Caption = "الكميةالمتوفرة";

                gv.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gv.Columns[3].DisplayFormat.FormatString = "N0";

                gv.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gv.Columns[4].DisplayFormat.FormatString = "N0";

                gv.BestFitColumns();


            
            if (gv.Columns[4].Summary.Count == 0)
            {
           
                gv.OptionsView.ShowFooter = true;             
                gv.Columns[4].Summary.Add(DevExpress.Data.SummaryItemType.Sum , "total", "المجموع = {0}");
                gv.Columns[2].Summary.Add(DevExpress.Data.SummaryItemType.Count, "name", "عدد المواد = {0}");
            }
            if (gv.GroupSummary.Count == 0)
            {
                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.DisplayFormat = "_____مجموع الكميات= {0}";
                item.FieldName = "total";
                item.ShowInGroupColumnFooter = gv.Columns["show in group row"];
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gv.GroupSummary.Add(item);
            }
            }
        }


        private void F_Med_min_Load(object sender, EventArgs e)
        {
            Get_Data("");
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int total = 0;
            int min = 0;
            double per = 0;
            GridView gv = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                total = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns[4]).ToString());
                min = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns[3]).ToString());
                per = min + min * 50 / 100;
                if (total < min)
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.IndianRed);
                    e.Appearance.BackColor2 = Color.White;


                }
                //else if (total < per && total > min)
                //{
                //    e.Appearance.BackColor = Color.FromArgb(150, Color.LightYellow);
                //    e.Appearance.BackColor2 = Color.White;


                //}
            }
        }

        private void bar_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bar_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print_Data();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Get_Data("");
        }
    }
}