﻿using DevExpress.Data;
using DevExpress.XtraGrid;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Store_OP_Forms;
using PhamaceySystem.Inheratenz_Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Dameg_op_Forms
{
    public partial class F_damage_item : F_Master_Grid
    {
        public F_damage_item()
        {
            InitializeComponent();
            Title(tit);
            this.Text = tit;
        }
        public string tit = "مواد فواتير الإتلاف";

        ClsCommander<T_Operation_Damage_Item> cmdDamegeItem = new ClsCommander<T_Operation_Damage_Item>();
     readonly    ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();

        T_Operation_Damage_Item TF_damege_Item;
        Boolean Is_Double_Click = false;
        int id;
        int med_id;
        int op_id;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdDamegeItem = new ClsCommander<T_Operation_Damage_Item>();
                TF_damege_Item = cmdDamegeItem.Get_All().FirstOrDefault();
                if (TF_damege_Item != null)
                    Fill_Graid();
                base.Get_Data(status_mess);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }
     
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    F_Dameg_Op f = new F_Dameg_Op(op_id);
                    f.ShowDialog();
                    Get_Data(string.Empty);
                }
                else
                    C_Master.Warning_Massege_Box("الرجاء اختيار عنصر لتعديله");

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            
                cmdDamegeItem.Detached_Data(TF_damege_Item);
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
                                cmdDamegeItem.Delete_Data(TF_damege_Item);
                                Classes.C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  بالرقم {med_id} بكمية {TF_damege_Item.dmg_item_quntity} من الفاتورة {op_id}");

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
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exception.FK_Exception))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
                Get_Data("");
                cmdDamegeItem.Detached_Data(TF_damege_Item);
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
            var data = (from med in cmdDamegeItem.Get_All()
                        join xxx in cmdMedician.Get_All()
                        on med.Med_id equals xxx.med_id into list
                        from yyy in list.DefaultIfEmpty()

                        select new
                        {
                            id = med.in_item_id,
                            med_id = med.Med_id,
                            med_name = yyy.med_name,
                            qun = med.dmg_item_quntity,
                            in_item_id = med.in_item_id,
                            opi = med.dmg_op_id
                        }).OrderBy(l_id => l_id.id).ToList();
            if (data != null && data.Count > 0)
            {
                gc.DataSource = data;
                Gv_column_names();

            }
        }
        private void Gv_column_names()
        {
            gv.Columns[0].Visible = false;
            gv.Columns[1].Caption = "رقم الدواء";
            gv.Columns[2].Caption = "اسم الدواء";
            gv.Columns[3].Caption = "الكمية التالفة";
            gv.Columns[4].Visible = false;
            gv.Columns[5].Caption = "رقم الفاتورة";

            gv.Columns[3].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[3].DisplayFormat.FormatString = "N0";

            if (gv.Columns[3].Summary.Count == 0)
            {

                gv.OptionsView.ShowFooter = true;
                gv.Columns[3].Summary.Add(DevExpress.Data.SummaryItemType.Sum, gv.Columns[3].FieldName.ToString(), "المجموع = {0}");
                gv.Columns[2].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[2].FieldName.ToString(), "عدد المواد = {0}");


            }
            if (gv.GroupSummary.Count == 0)
            {
                GridGroupSummaryItem item = new GridGroupSummaryItem();
                item.DisplayFormat = "_____مجموع الكميات= {0}";
                item.FieldName = gv.Columns[3].FieldName.ToString();
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
                TF_damege_Item = cmdDamegeItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
                op_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[5]).ToString());
                med_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[1]).ToString());

            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString());
                TF_damege_Item = cmdDamegeItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
                op_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[5]).ToString());
                med_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[1]).ToString());

            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            // if (TF_damege_Item != null)
            //Fill_Controls();
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