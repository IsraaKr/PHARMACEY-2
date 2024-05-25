using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Store_Forms;
using PhamaceySystem.Forms.Store_OP_Forms;
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

namespace PhamaceySystem.Forms.Dameg_op_Forms
{
    public partial class F_damege_item : F_Master_Graid
    {
        public F_damege_item()
        {
            InitializeComponent();
            Title(tit);
            this.Text = tit;
        }
        public string tit = "مواد فواتير الإتلاف";

        ClsCommander<T_Operation_Damage_Item> cmdDamegeItem = new ClsCommander<T_Operation_Damage_Item>();
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();

        T_Operation_Damage_Item TF_damege_Item;
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
                    F_Dameg_Op f = new F_Dameg_Op(op_id);
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
                                cmdDamegeItem.Delete_Data(TF_damege_Item);

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
                            opi=med.dmg_op_id
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
            gv.Columns[3].Caption = "الكمية التالفة";
            gv.Columns[4].Visible = false;
            gv.Columns[5].Visible = false;


            gv.BestFitColumns();
        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString());
                TF_damege_Item = cmdDamegeItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
                op_id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[5]).ToString());

            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString());
                TF_damege_Item = cmdDamegeItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
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