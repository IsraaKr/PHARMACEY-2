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

namespace PhamaceySystem.Forms.Setting_Forms
{
    public partial class F_System_Record : F_Master_Grid
    {
        public F_System_Record()
        {
            InitializeComponent();
            Title(tit);
            bar_neew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_new.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_edite.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            this.Text = tit;
        }
        public string tit = "سجل النظام";

        ClsCommander<T_System_Record> cmdSystemRecord = new ClsCommander<T_System_Record>();
  

        T_System_Record TF_System_Record;
        int id;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
           
                cmdSystemRecord = new ClsCommander<T_System_Record>();
                TF_System_Record = cmdSystemRecord.Get_All().FirstOrDefault();
                if (TF_System_Record != null)
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
            C_Master.print_header(tit, gc);
        }

        public override bool Validate_Data()
        {
            int number_of_errores = 0;


            return (number_of_errores == 0);
        }


        private void Fill_Graid()
        {
            var data = (from med in cmdSystemRecord.Get_All()
                        select new
                        {
                            id = med.Id,                                               
                            titel = med.Tiltle,
                            op=med.op_name ,
                            tabl=med.tableName,
                            description = med.desicriptio,
                            date = med.created_date,
                            mac = med.Mac_Id,
                            devicename = med.Device_name,
                            fullName = med.Full_name,                         
                            user_id = med.User_id,
                           
                        }).OrderByDescending(l_id => l_id.id).ToList();
            //جلب جزء من البيانات
            if (data != null && data.Count > 0)
            {
                gc.DataSource = data;
               gv_column_names();
            }
        }
        private void gv_column_names()
        {
            gv.Columns[0].Caption = "الرقم ";
            gv.Columns[1].Caption = "العنوان";
            gv.Columns[2].Caption = "العملية";
            gv.Columns[3].Caption = "الجدول";
            gv.Columns[4].Caption = "التفصيل";
            gv.Columns[5].Caption = "تاريخ العملية ";
            gv.Columns[6].Caption = "ماك ";
            gv.Columns[7].Caption = "اسم الجهاز ";
            gv.Columns[8].Caption = "الاسم الكامل";
            gv.Columns[9].Caption = " المستخدم";
   

            gv.BestFitColumns();

            gv.OptionsView.ShowFooter = true;
            if (gv.Columns[0].Summary.Count == 0)

                gv.Columns[0].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[0].FieldName.ToString(), "عدد = {0}");


        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_System_Record = cmdSystemRecord.Get_By(c_id => c_id.Id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_System_Record = cmdSystemRecord.Get_By(c_id => c_id.Id == id).FirstOrDefault();
            }
        }

      
        public override void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }
      
    }
}

