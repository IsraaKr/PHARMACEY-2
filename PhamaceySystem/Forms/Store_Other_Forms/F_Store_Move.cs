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
    public partial class F_Store_Move : F_Master_Grid
    {
        public F_Store_Move()
        {
            InitializeComponent();
            bar_edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_add_save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            bar_neew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_edite.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
           sp_add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
           sp_delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_add_save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            sp_new.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


            //      view_inheretanz_butomes(false,false, false, false, false, false, true);
            this.Text = tit;
            Title(tit);
        }
        public string tit = "حركة المستودع";
        DataTable dt_op;
        DataSet ds;
        int id;

        public override void Get_Data(string status_mess)
        {
            ds = new DataSet();
            Fill_Graid_op();
            gc.DataSource = dt_op;

            gv_column_names_op();

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

        private void Fill_Graid_op()
        {

            dt_op = C_DB.Select(@" SELECT     T_Store_Move.id,
T_OPeration_Type.OP_type_name ,
T_Store_Move.date, 
T_Store_Move.time, 
T_Medician.med_name,
 T_Med_Shape.med_shape_name, 
T_Store_Move.qunt, 
                      T_Pers_Recivers.name AS reciver_name,
T_Pers_Emploee.Emp_name,
T_Pers_Donars.Donar_name, 
T_Store_Placees.name AS place_name
FROM         T_Store_Move LEFT OUTER JOIN
                      T_Store_Placees ON T_Store_Move.place_id = T_Store_Placees.id LEFT OUTER JOIN
                      T_Pers_Recivers ON T_Store_Move.reciver_id = T_Pers_Recivers.id LEFT OUTER JOIN
                      T_Pers_Emploee ON T_Store_Move.emp_id = T_Pers_Emploee.Emp_id LEFT OUTER JOIN
                      T_Pers_Donars ON T_Store_Move.donar_id = T_Pers_Donars.Donar_id LEFT OUTER JOIN
                      T_OPeration_Type ON T_Store_Move.op_type_id = T_OPeration_Type.OP_type_id LEFT OUTER JOIN
                      T_Medician ON T_Store_Move.med_id = T_Medician.med_id LEFT OUTER JOIN
                      T_Med_Shape on T_Medician.med_shape_id =T_Med_Shape.med_shape_id
      ");
        }
        private void gv_column_names_op()
        {
            gv.Columns[0].Caption = "الرقم";
            gv.Columns[1].Caption = "اسم العملية";
            gv.Columns[2].Caption = "التاريخ";
            gv.Columns[3].Caption = "الوقت";
            gv.Columns[4].Caption = "الدواء";
            gv.Columns[5].Caption = "الشكل";
           gv.Columns[6].Caption = "الكمية ";
            gv.Columns[7].Caption = "المستلم ";
            gv.Columns[8].Caption = "الموظف ";
            gv.Columns[9].Caption = "المتبرع ";
            gv.Columns[10].Caption = "مكان التخزين";

            gv.BestFitColumns();

            gv.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[6].DisplayFormat.FormatString = "N0";


        }
        public  void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Insert_Data();
            //if (e.KeyCode == Keys.F2)
            //    new();
            if (e.KeyCode == Keys.Delete)
                Delete_Data();
            if (e.KeyCode == Keys.Escape)
                clear_data(this.Controls);
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
       
    }
}
