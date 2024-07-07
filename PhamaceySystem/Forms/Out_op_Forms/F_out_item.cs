using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Store_Forms;
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

namespace PhamaceySystem.Forms.Out_op_Forms
{
    public partial class F_out_item : F_Master_Graid
    {
        public F_out_item()
        {
            InitializeComponent();
            Title(tit);
            this.Text = tit;
        }
        public string tit = "مواد فواتير الإخراج"  ;

        ClsCommander<T_OPeration_Out_Item> cmdOutItem = new ClsCommander<T_OPeration_Out_Item>();
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();

        T_OPeration_Out_Item TF_out_Item;
        Boolean Is_Double_Click = false;
        int id;
        int op_id;
        //  int row_to_show;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdOutItem = new ClsCommander<T_OPeration_Out_Item>();
                TF_out_Item = cmdOutItem.Get_All().FirstOrDefault();
                if (TF_out_Item != null)
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
            //try
            //{
            //    F_In_Op f = new F_In_Op();
            //    f.ShowDialog();

            //    Get_Data("");
            //}
            //catch (Exception ex)
            //{
            //    Get_Data(ex.InnerException.InnerException.ToString());
            //}
        }
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    F_Out_Op f = new F_Out_Op(op_id);
                    f.ShowDialog();
                    Get_Data("");
                }
                else
                    C_Master.Warning_Massege_Box("الرجاء اختيار عنصر لتعديله");

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }


        }
        public override void Delete_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (C_Master.Qustion_Massege_Box(C_Master.mas_del) == DialogResult.Yes)
                    {
                        if (gv.RowCount > 0)
                        {
                            foreach (int row_id in gv.GetSelectedRows())
                            {
                                Get_Row_ID(row_id);
                                cmdOutItem.Delete_Data(TF_out_Item);

                            }
                            base.Delete_Data();
                            Get_Data("d");
                        }
                    }
                    else
                        C_Master.Warning_Massege_Box("الرجاء اختيار عنصر من الجدول لحذفه");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exeption.FK_Exeption))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
            }
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
            var data = (from med in cmdOutItem.Get_All()
                        join xxx in cmdMedician.Get_All()
                         on med.Med_id equals xxx.med_id into list
                        from yyy in list.DefaultIfEmpty()
                        join shape in cmdShape.Get_All()
 on yyy.med_shape_id equals shape.med_shape_id into slist

                        from sss in slist.DefaultIfEmpty()
                        select new
                        {
                            id = med.in_item_id,
                            med_id = med.Med_id,
                            med_name = yyy.med_name,
                            shape=sss.med_shape_name,
                            qun = med.out_item_quntity,
                           in_item_id = med.in_item_id,
                op_i=med.out_op_id
                        }).OrderBy(l_id => l_id.id).ToList();
            if (data != null && data.Count > 0)
            {
                gc.DataSource = data;
                gv_column_names();

            }
        }
        private void gv_column_names()
        {
            gv.Columns[0].Visible = false;
            gv.Columns[1].Caption = "رقم الدواء";
            gv.Columns[2].Caption = "اسم الدواء";
            gv.Columns[3].Caption = "الشكل";
            gv.Columns[4].Caption = "الكمية الخارجة";
            gv.Columns[5].Visible = false;
            gv.Columns[6].Caption = "رقم الفاتورة";


            gv.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[4].DisplayFormat.FormatString = "N0";

            if (gv.Columns[4].Summary.Count == 0)
            {
          
                gv.OptionsView.ShowFooter = true;
            gv.Columns[4].Summary.Add(DevExpress.Data.SummaryItemType.Sum, gv.Columns[4].FieldName.ToString(), "المجموع = {0}");
            gv.Columns[2].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[2].FieldName.ToString(), "عدد المواد = {0}");
            }
            if (gv.GroupSummary.Count == 0)
            {
                DevExpress.XtraGrid.GridGroupSummaryItem item = new DevExpress.XtraGrid.GridGroupSummaryItem();
                item.DisplayFormat = "_____مجموع الكميات= {0}";
                item.FieldName = gv.Columns[4].FieldName.ToString();
                item.ShowInGroupColumnFooter = gv.Columns["show in group row"];
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gv.GroupSummary.Add(item);
            }
            gv.BestFitColumns();
        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString());
                TF_out_Item = cmdOutItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
                op_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[5]).ToString());

            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString());
                TF_out_Item = cmdOutItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
                op_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[5]).ToString());

            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_out_Item != null)
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
