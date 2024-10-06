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

namespace PhamaceySystem.Forms.Store_OP_Forms
{
    public partial class F_out_op_grid : F_Master_Grid
    {
        public F_out_op_grid()
        {
            InitializeComponent();
            Title(tit);
            this.Text = tit;
        }
        public string tit = "فواتير الإخراج";

        ClsCommander<T_OPeration_Out> cmdOutOp = new ClsCommander<T_OPeration_Out>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Recivers> cmdReciver = new ClsCommander<T_Pers_Recivers>();

        T_OPeration_Out TF_OPeration_out;
        Boolean Is_Double_Click = false;
        int id;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdOutOp = new ClsCommander<T_OPeration_Out>();
                //    row_to_show = Properties.Settings.Default.gc_row_count;
                TF_OPeration_out = cmdOutOp.Get_All().FirstOrDefault();
                if (TF_OPeration_out != null)
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
            try
            {
                F_Out_Op f = new F_Out_Op();
                f.ShowDialog();

                Get_Data("");
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    F_Out_Op f = new F_Out_Op(id);
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
                                cmdOutOp.Delete_Data(TF_OPeration_out);
                                Classes.C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  بالرقم {TF_OPeration_out.out_op_id} ");

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
                cmdOutOp.Detached_Data(TF_OPeration_out);
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
            var data = (from med in cmdOutOp.Get_All()
                        join xxx in cmdReciver.Get_All()
                         on med.reciver_id equals xxx.id into list
                        from yyy in list.DefaultIfEmpty()
                        join place in cmdEmp.Get_All()
on med.emp_id equals place.Emp_id into plist

                        from ppp in plist.DefaultIfEmpty()
                        select new
                        {
                            id = med.out_op_id,
                            date = med.out_op_date,
                            time = med.out_op_time,
                            text = med.out_op_text,
                            rec_id = med.reciver_id,
                            reciver = yyy.name,
                            emp_rec = med.reciver_name,
                            emp_id = med.emp_id,
                            emp = ppp.Emp_name,
                            count = med.med_count
                        }).OrderBy(l_id => l_id.id).ToList();
            //جلب جزء من البيانات
            if (data != null && data.Count > 0)
            {
                gc.DataSource = data;
                gv_column_names();
            }
        }
        private void gv_column_names()
        {
            gv.Columns[0].Caption = "رقم الفاتورة";
            gv.Columns[1].Caption = "التاريخ";
            gv.Columns[2].Caption = "الوقت";
            gv.Columns[3].Caption = "البيان";
            gv.Columns[4].Visible = false;
            gv.Columns[5].Caption = "ةالجهة المستلم ";
            gv.Columns[6].Caption = "المستلم ";
            gv.Columns[7].Visible = false;
            gv.Columns[8].Caption = "الموظف ";
            gv.Columns[9].Caption = "عدد المواد  ";

            gv.BestFitColumns();


            gv.OptionsView.ShowFooter = true;
            if (gv.Columns[0].Summary.Count == 0)
          
                gv.Columns[0].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[0].FieldName.ToString(), "العدد = {0}");

        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OPeration_out = cmdOutOp.Get_By(c_id => c_id.out_op_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OPeration_out = cmdOutOp.Get_By(c_id => c_id.out_op_id == id).FirstOrDefault();
            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (  TF_OPeration_out != null)
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

