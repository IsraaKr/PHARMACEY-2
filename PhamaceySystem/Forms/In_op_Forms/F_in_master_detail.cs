using PhamaceySystem.Forms.Store_Forms;
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
    public partial class F_in_master_detail : F_Master_Inheretanz
    {
        public F_in_master_detail()
        {
            InitializeComponent();
            view_inheretanz_butomes(true, false, false, true, true, false, true, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = "فواتير الادخال";
        Boolean Is_Double_Click = false;
        DataTable dt_op;
        DataTable dt_item;
        DataSet ds;
        int id;

        public override void Get_Data(string status_mess)
        {
            ds = new DataSet();
            Is_Double_Click = false;
            Fill_Graid_op();
            Fill_Graid_item();
            dt_op.TableName = "T_OPeration_IN";
            dt_item.TableName = "T_OPeration_IN_Item";
            ds.Tables.Add(dt_op);
            ds.Tables.Add(dt_item);
            ds.Relations.Add("rel", dt_op.Columns["in_op_id"], dt_item.Columns["In_op_id"]);
            gc.DataSource = ds;
            gc.DataMember = "T_OPeration_IN";

            gv_column_names_op();
            gv_column_names_item();
            //get_op(status_mess);
            //get_item(status_mess);
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
                                //   cmdINOP.Delete_Data(TF_OPeration_IN);

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

        private void Fill_Graid_op()
        {

            dt_op = c_db.select(@"SELECT     T_OPeration_IN.in_op_id,
T_OPeration_IN.in_op_date, T_OPeration_IN.in_op_time, T_OPeration_IN.in_op_text,

                     T_OPeration_IN.donar_id,
T_Pers_Donars.Donar_name,
 T_OPeration_IN.donar_emp,T_OPeration_IN.emp_id, 
                      T_Pers_Emploee.Emp_name,   T_OPeration_IN.med_count
FROM         T_OPeration_IN INNER JOIN
                      T_Pers_Emploee ON T_OPeration_IN.emp_id = T_Pers_Emploee.Emp_id INNER JOIN
                      T_Pers_Donars ON T_OPeration_IN.donar_id = T_Pers_Donars.Donar_id");
            // if (dt_op != null && dt_op.Rows.Count > 0)
            //       gv_column_names_op();

        }
        private void gv_column_names_op()
        {
            gv.Columns[0].Caption = "الرقم";
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

        private void Fill_Graid_item()
        {
            dt_item = c_db.select(@" SELECT     T_OPeration_IN_Item.in_item_id,

T_Medician.med_name, 
T_OPeration_IN_Item.in_item_quntity,

                      T_Store_Placees.name,
T_OPeration_IN_Item.is_out,
T_OPeration_IN_Item.out_item_quntitey,
T_OPeration_IN_Item.In_op_id
FROM         T_OPeration_IN_Item INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_OPeration_IN ON T_OPeration_IN_Item.In_op_id = T_OPeration_IN.in_op_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id ");


            if (dt_item != null && dt_item.Rows.Count > 0)
            {

                gv_column_names_item();

            }
        }
        private void gv_column_names_item()
        {
            dt_item.Columns[0].Caption = "رقم المادة";

            dt_item.Columns[1].Caption = "اسم الدواء";
            dt_item.Columns[2].Caption = "الكمية المدخلة";
        
            dt_item.Columns[3].Caption = "مكان التخزين ";
            dt_item.Columns[4].Caption = "خارجة ";
            dt_item.Columns[5].Caption = "الكمية الخارجة ";
            dt_item.Columns[6].Caption = "رقم فاتورة الادخال ";

            gv.BestFitColumns();
        }
        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                //  TF_OPeration_IN = cmdINOP.Get_By(c_id => c_id.in_op_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                //  TF_OPeration_IN = cmdINOP.Get_By(c_id => c_id.in_op_id == id).FirstOrDefault();
            }
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_OPeration_IN != null)
            // Fill_Controls();
        }
    }
}
