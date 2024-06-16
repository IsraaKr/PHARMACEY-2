using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
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

namespace PhamaceySystem.Forms.Store_Forms
{
    public partial class F_In_OP_Graid : F_Master_Graid
    {
        public F_In_OP_Graid()
        {
            InitializeComponent();

            Title(tit);
            this.Text = tit;
        }
        public string tit = "فواتير الادخال";

        ClsCommander<T_OPeration_IN> cmdINOP = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();

        T_OPeration_IN TF_OPeration_IN;
        Boolean Is_Double_Click = false;
        int id;
        int row_to_show;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdINOP = new ClsCommander<T_OPeration_IN>();
                //  row_to_show = Properties.Settings.Default.gc_row_count;
                TF_OPeration_IN = cmdINOP.Get_All().FirstOrDefault();
                if (TF_OPeration_IN != null)
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
                F_In_Op f = new F_In_Op();
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
                    F_In_Op f = new F_In_Op(id);
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
                                cmdINOP.Delete_Data(TF_OPeration_IN);

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
            var data = (from med in cmdINOP.Get_All()
                        join xxx in cmdDonars.Get_All()
                         on med.donar_id equals xxx.Donar_id into list
                        from yyy in list.DefaultIfEmpty()
                        join place in cmdEmp.Get_All()
on med.emp_id equals place.Emp_id into plist

                        from ppp in plist.DefaultIfEmpty()
                        select new
                        {
                            id = med.in_op_id,
                            date = med.in_op_date,
                            time = med.in_op_time,
                            text = med.in_op_text,
                            don_id = med.donar_id,
                            donar = yyy.Donar_name,
                            emp_donar = med.donar_emp,
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
            gv.Columns[5].Caption = "المتبرع ";
            gv.Columns[6].Caption = "المسلم ";
            gv.Columns[7].Visible = false;
            gv.Columns[8].Caption = "الموظف ";
            gv.Columns[9].Caption = "عدد المواد  ";

            gv.BestFitColumns();
        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OPeration_IN = cmdINOP.Get_By(c_id => c_id.in_op_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OPeration_IN = cmdINOP.Get_By(c_id => c_id.in_op_id == id).FirstOrDefault();
            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_OPeration_IN != null)
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
