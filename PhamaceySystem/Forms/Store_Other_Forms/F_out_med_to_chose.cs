using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
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
    public partial class F_out_med_to_chose : F_Master_Inheretanz
    {
        public F_out_med_to_chose(int med_id  , int out_op_id , DateTime date , string timr , int op_type , int emp_id , int reciver_id )
        {
            InitializeComponent();
            med_idd = med_id;       
            out_op_idd = out_op_id;
            opp_type = op_type;
            datee =Convert.ToDateTime( date.ToString("yyyy/MM/dd"));
            time = timr;
             emp_f_id = emp_id;
             reciver_f_id = reciver_id;
     
            //   gv.OptionsBehavior.Editable   = true;
            view_inheretanz_butomes(false, true, false, false, false, true, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = "كميات الدواء المتوفرة ";
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
        ClsCommander<T_OPeration_Out_Item> cmdOppOutItem = new ClsCommander<T_OPeration_Out_Item>();
        ClsCommander<T_Store_Move> cmdStoreMove = new ClsCommander<T_Store_Move>();
        ClsCommander<T_Operation_Damage_Item> cmdOppDamItem = new ClsCommander<T_Operation_Damage_Item>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
 
        T_OPeration_IN_Item TF_OPeration_IN_Item;
        T_Medician TF_Medician;
        T_OPeration_Out_Item TF_OP_Out_Item;
        T_Operation_Damage_Item TF_OP_Dam_Item;
        T_Store_Move TF_Store_Move;
        Boolean Is_Double_Click = false;
        int opp_type;
        int med_idd;
        int in_item_idd;
        int out_op_idd;
        int in_op_idd;
        int item_id;
        int emp_f_id;
        int reciver_f_id;


        int out_item_quntity;
        DateTime datee;
        string time;
        public override void Get_Data(string status_mess)
        {
            try
            {
//clear_data(this.Controls);
                Is_Double_Click = false;
                cmdMedician = new ClsCommander<T_Medician>();
                TF_Medician = cmdMedician.Get_All().FirstOrDefault();
                if (TF_Medician != null)
                    Fill_Graid();
                base.Get_Data(status_mess);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }
        public override void Insert_Data()
        {
            int x = 0;
            for (int i = 0; i < gv.RowCount; i++)
            {
                in_item_idd = Convert.ToInt32(gv.GetRowCellValue(i, gv.Columns[0]));
                in_op_idd = Convert.ToInt32(gv.GetRowCellValue(i, gv.Columns[2]));
                int old_qunt = Convert.ToInt32(gv.GetRowCellValue(i, gv.Columns[6]));
                out_item_quntity = Convert.ToInt32(gv.GetRowCellValue(i, gv.Columns["الكمية المطلوبة"]));
                if (out_item_quntity > 0 && out_item_quntity <= old_qunt)
                {
                    insert_item();
                    update_In_item();
                    Get_Add_med_count();
                    Get_Add_move();
                    x++;
                }             
            }
            MessageBox.Show("تم الحفظ بنجاح!!! عدد المواد المدخلة هي  " + x);
            this.Close();
            Get_Data("i");
            base.Insert_Data();
        }
        private void Get_Add_move()
        {
            TF_Store_Move = new T_Store_Move();
            TF_Store_Move.qunt = out_item_quntity;
            TF_Store_Move.med_id = med_idd;
            TF_Store_Move.item_id = item_id;
            TF_Store_Move.op_id = out_op_idd;
            TF_Store_Move.emp_id = emp_f_id;

            if (opp_type == 2)
            {
                TF_Store_Move.op_type_id = Convert.ToInt32("2");
                TF_Store_Move.reciver_id = reciver_f_id;

            }
            else if (opp_type == 3)
                TF_Store_Move.op_type_id = Convert.ToInt32("3");

            TF_Store_Move.date = Convert.ToDateTime(datee.ToString("yyyy/MM/dd"));
            TF_Store_Move.time = time;

            cmdStoreMove.Insert_Data(TF_Store_Move);
        }
        private void Fill_Graid()
        {

            if (opp_type == 2)
            {
                var med_list = (from Emp in cmdOpInItem.Get_All().Where(l => l.is_out == false && l.Med_id == med_idd)
                                join xxx in cmdMedician.Get_All()
                                on Emp.Med_id equals xxx.med_id into list
                                from yyy in list.DefaultIfEmpty()
                                join place in cmdStorageplace.Get_All()
 on Emp.store_place_id equals place.id into plist
                                
                                from ppp in plist.DefaultIfEmpty()
                                select new
                                {
                                    item_id = Emp.in_item_id,
                                    med_id = Emp.Med_id,
                                    op_id = Emp.In_op_id,
                                    name = yyy.med_name,
                                    datee = Emp.in_item_expDate,
                                    place = ppp.name,
                                    quntatey = Emp.in_item_quntity - Emp.out_item_quntitey,

                                }).OrderBy(l => l.datee).Distinct();
                gc.DataSource = med_list;
            }
            else if (opp_type == 3)
            {
                var med_list = (from Emp in cmdOpInItem.Get_All().Where(l => l.is_out == false
                                                                        && l.Med_id == med_idd
                                                                         && l.in_item_expDate.Value.Month < DateTime.Today.Month
                                                                         && l.in_item_expDate.Value.Year <= DateTime.Today.Year)

                                join xxx in cmdMedician.Get_All()
                         on Emp.Med_id equals xxx.med_id into list
                                from yyy in list.DefaultIfEmpty()
                                join place in cmdStorageplace.Get_All()
                         on Emp.store_place_id equals place.id into plist

                                from ppp in plist.DefaultIfEmpty()
                                select new
                                {
                                    item_id = Emp.in_item_id,
                                    med_id = Emp.Med_id,
                                    op_id = Emp.In_op_id,
                                    name = yyy.med_name,
                                    datee =Convert.ToDateTime( Emp.in_item_expDate.Value.ToString("MM/yyyy")),
                                    place = ppp.name,
                                    quntatey = Emp.in_item_quntity - Emp.out_item_quntitey,

                                }).OrderBy(l => l.datee).Distinct();
                gc.DataSource = med_list;
            }
            gv.Columns[0].Visible = false;
            gv.Columns[1].Visible = false;
            gv.Columns[2].Visible = false;         
            gv.Columns[3].Caption = "الاسم";
            gv.Columns[3].OptionsColumn.AllowEdit = false;
            gv.Columns[4].Caption = "تاريخ انتهاء الصلاحية";

            gv.Columns[3].OptionsColumn.AllowEdit = false;
            gv.Columns[5].Caption = "مكان التخزين ";
            gv.Columns[3].OptionsColumn.AllowEdit = false;
            gv.Columns[6].Caption = "الكمية المتوفرة ";
            gv.Columns[3].OptionsColumn.AllowEdit = false;
            if (gv.Columns.Count<=7)
            {
                gv.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn());
                GridColumn col = gv.Columns.AddVisible("الكمية المتوفرة 2");
                col.UnboundType = UnboundColumnType.Integer;
                col.OptionsColumn.AllowEdit = true;
                col.FieldName = "الكمية المطلوبة";
                col.VisibleIndex = 7;
            }
                    
            gv.BestFitColumns();
        } 
       
        // ********************* اخراج المادة *******************
        public void Fill_Entitey_item()
        {
            TF_OP_Out_Item.out_item_quntity = out_item_quntity;
            TF_OP_Out_Item.out_B_It_note = null;
            TF_OP_Out_Item.Med_id = med_idd;

            TF_OP_Out_Item.out_op_id = out_op_idd;
            TF_OP_Out_Item.in_item_id = in_item_idd;

        }
        public void insert_item()
        {
            if (opp_type ==2)
            {
                TF_OP_Out_Item = new T_OPeration_Out_Item();
                Fill_Entitey_item();
                cmdOppOutItem.Insert_Data(TF_OP_Out_Item);
                Set_Auto_Id_item();
            }
            else if (opp_type==3)
            {
                TF_OP_Dam_Item = new T_Operation_Damage_Item();

                TF_OP_Dam_Item.dmg_item_quntity = out_item_quntity;
                TF_OP_Dam_Item.dmg_B_It_note = null;
                TF_OP_Dam_Item.Med_id = med_idd;

                TF_OP_Dam_Item.dmg_op_id = out_op_idd;
                TF_OP_Dam_Item.in_item_id = in_item_idd;
                cmdOppDamItem.Insert_Data(TF_OP_Dam_Item);

                var max_id = cmdOppDamItem.Get_All().Where(c_id => c_id.dmg_item_id ==
                        cmdOppDamItem.Get_All().Max(max => max.dmg_item_id)).FirstOrDefault();
                item_id = max_id == null ? 1 : (max_id.dmg_item_id);
            }
       
           
        }
        private void Set_Auto_Id_item()
        {
            var max_id = cmdOppOutItem.Get_All().Where(c_id => c_id.out_item_id ==
                         cmdOppOutItem.Get_All().Max(max => max.out_item_id)).FirstOrDefault();
            item_id = max_id == null ? 1 : (max_id.out_item_id );

        }
        //********************* توابع جرد الدواء ****************************
        private void Get_Add_med_count()
        {
            TF_Medician = new T_Medician();
            int id = med_idd;
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            if (opp_type == 2)
                TF_Medician.med_dam_count = TF_Medician.med_out_count + out_item_quntity;
            else if (opp_type == 3)
                TF_Medician.med_dam_count = TF_Medician.med_dam_count + out_item_quntity;

            TF_Medician.med_total_now = TF_Medician.med_total_now -out_item_quntity;
            cmdMedician.Update_Data(TF_Medician);
        }
   
        //*****************تعديل الإدخال*********************   
        public void Fill_Entitey_in_item()
        {
            int out_qunt = out_item_quntity;
            int in_id = in_item_idd;

            TF_OPeration_IN_Item = new T_OPeration_IN_Item();
            TF_OPeration_IN_Item = cmdOpInItem.Get_By(l => l.in_item_id == in_id).FirstOrDefault();

            TF_OPeration_IN_Item.out_item_quntitey = TF_OPeration_IN_Item.out_item_quntitey + out_qunt;
            if (TF_OPeration_IN_Item.out_item_quntitey == TF_OPeration_IN_Item.in_item_quntity)
                TF_OPeration_IN_Item.is_out = true;
        }
        public void update_In_item()
        {
            try
            {
                Fill_Entitey_in_item();
                cmdOpInItem.Update_Data(TF_OPeration_IN_Item);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }

        private void gc_Click(object sender, EventArgs e)
        {

        }

       
        Dictionary<int, int> dic_out = new Dictionary<int, int>();
        private void gv_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
     
            int row_index = e.ListSourceRowIndex;
            int outt = 0;//
          //  Convert.ToInt32(gv.GetListSourceRowCellValue(row_index, "الكمية المطلوبة"));
            if (e.Column.FieldName != "الكمية المطلوبة")
                return;
            if (e.IsGetData)
            {
                if (!dic_out.ContainsKey(row_index))
                {
                    dic_out.Add(row_index, outt);

                }
                e.Value = dic_out[row_index];
            
            }

            if (e.IsSetData)
            {
                dic_out[row_index] = Convert.ToInt32(e.Value);
              
            }
     
        }

         private void gv_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            var row = e.Row;
            int old_qunt = Convert.ToInt32(gv.GetFocusedRowCellValue( gv.Columns[6]));
            out_item_quntity = Convert.ToInt32(gv.GetFocusedRowCellValue( gv.Columns["الكمية المطلوبة"]));
            if (row == null)
                return;
            if (old_qunt < out_item_quntity || out_item_quntity <0)
            {
                e.Valid = false;
                gv.SetColumnError(gv.Columns["الكمية المطلوبة"], " يجب أن تكون الكمية المطلوبة أقل من الكمية المتوفرة و أكبر من الصفر");
            }
        }
        //مشان م تطلع رسالة الفاليديشن ا
        private void gv_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
    }
} 
