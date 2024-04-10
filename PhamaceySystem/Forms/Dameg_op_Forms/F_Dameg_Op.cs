using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Person_Forms;
using PhamaceySystem.Forms.Store_Other_Forms;
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
    public partial class F_Dameg_Op : F_Master_Inheretanz
    {
        public F_Dameg_Op()
        {
            InitializeComponent();

            view_inheretanz_butomes(true, false, false, false, false, false, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = "اتلاف  مادة / damage Operation";
        public F_Dameg_Op(int op_id)
        {
            id_toUpdate = op_id;
            InitializeComponent();
            Title(tit);
            this.Text = tit;
            view_inheretanz_butomes(true, true, false, false, false, false, true);
        }
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Recivers> cmdReciver = new ClsCommander<T_Pers_Recivers>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_Damage> cmdOpDam = new ClsCommander<T_OPeration_Damage>();
        ClsCommander<T_Operation_Damage_Item> cmdOppDamItem = new ClsCommander<T_Operation_Damage_Item>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
        ClsCommander<T_Store_Move> cmdStoreMove = new ClsCommander<T_Store_Move>();


        T_OPeration_IN_Item TF_OPeration_IN_Item;
        T_OPeration_Damage TF_OP_Dam;
        T_Operation_Damage_Item TF_OP_Dam_Item;
        T_Medician TF_Medician;
        T_Store_Move TF_Store_Move;

        int is_op_insert = 0;
        DateTime d = DateTime.Now;
        int id_toUpdate = 0;
        Boolean Is_Double_Click = false;
        int med_id_chose = 0;
        int old_med_Quntitey;
        int old_med_id;
        int old_item_id = 0;
        DataTable dt;
        public override void Get_Data(string status_mess)
        {
            try
            {
                // clear_data(this.Controls);

                Set_Auto_Id_item();
                Set_Auto_Id_op();

                out_op_dateDateEdit.DateTime = Convert.ToDateTime(d.ToShortDateString());
                out_op_timeTimeSpanEdit.EditValue = Convert.ToDateTime(d.ToShortDateString());

                Is_Double_Click = false;
                btn_visible(false);

                cmdMedician = new ClsCommander<T_Medician>();
                cmdMedician = new ClsCommander<T_Medician>();
                cmdEmp = new ClsCommander<T_Pers_Emploee>();
                cmdReciver = new ClsCommander<T_Pers_Recivers>();
                cmdStorageplace = new ClsCommander<T_Store_Placees>();
                cmdOpDam = new ClsCommander<T_OPeration_Damage>();
                cmdOppDamItem = new ClsCommander<T_Operation_Damage_Item>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();


                GetEmp_Data();
                GetMed_Data();
                //    Get_Store_med();
                //  GetStoragePlace_Data();
                is_op_insert = 0;
                Get_OP_Med_count_Data();


                //   med_countTextEdit1.Text = "0";
                if (id_toUpdate != 0)
                {
                    TF_OP_Dam = new T_OPeration_Damage();
                    TF_OP_Dam = cmdOpDam.Get_By(i => i.dam_OP_id == id_toUpdate).FirstOrDefault();
                    Get_OP_Med_count_Data();

                    Fill_Controls_op();
                    Fill_Graid_item();
                }
                base.Get_Data(status_mess);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }
        private void btn_visible(bool states)
        {
            if (states)
            {
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }
        public override void Print_Data()
        {
            C_Master.print_header("- تفاصيل فاتورة الاخراج رقم -"
                      + out_op_idTextEdit.Text + " - تاريخ -" + out_op_dateDateEdit.Text
                      , gc);
        }
        public override void Insert_Data()
        {
            try
            {
                if (id_toUpdate == 0)
                {

                }
                else
                {
                    update_op();
                }

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public override void clear_data(Control.ControlCollection s_controls)
        {
            base.clear_data(s_controls);
            Set_Auto_Id_op();
            Set_Auto_Id_item();

        }
        public override void neew()
        {
            base.neew();
            Get_Data("");
            Set_Auto_Id_op();
            Set_Auto_Id_item();
            gc.DataSource = null;
            gv.Columns.Clear();

        }

        //*****************عملية الإتلاف*********************
        public bool Validate_Data_op()
        {
            int number_of_errores = 0;
            number_of_errores += out_op_idTextEdit.is_text_valid() ? 0 : 1;
            //   number_of_errores += reciver_empTextEdit.is_text_valid() ? 0 : 1;


            if (emp_idSearchLookUpEdit.EditValue == null)
            {
                number_of_errores += 1;
                emp_idSearchLookUpEdit.ErrorText = "هذا الحقل مطلوب";
            }

            return (number_of_errores == 0);
        }
        public void Fill_Entitey_op()
        {

            TF_OP_Dam.dam_op_date = Convert.ToDateTime(out_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            //TF_OP_Dam.dam_op_time = (TimeSpan?)out_op_timeTimeSpanEdit.EditValue;
            TF_OP_Dam.dam_op_text = out_op_textTextEdit.Text;
            TF_OP_Dam.dam_op_state = Convert.ToBoolean(out_op_stateCheckEdit.CheckState);
            TF_OP_Dam.med_count = Convert.ToInt32(med_countTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_OP_Dam.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString().Replace(",", string.Empty));
            TF_OP_Dam.op_type_id = Convert.ToInt32("3");

        }
        public void Fill_Controls_op()
        {
            out_op_idTextEdit.Text = TF_OP_Dam.dam_OP_id.ToString();
            out_op_dateDateEdit.DateTime = Convert.ToDateTime(TF_OP_Dam.dam_op_date);
            out_op_timeTimeSpanEdit.EditValue = TF_OP_Dam.dam_op_time;
            out_op_textTextEdit.Text = TF_OP_Dam.dam_op_text;
            out_op_stateCheckEdit.Checked = Convert.ToBoolean(TF_OP_Dam.dam_op_state);
            med_countTextEdit1.Text = TF_OP_Dam.med_count.ToString();
            emp_idSearchLookUpEdit.EditValue = TF_OP_Dam.emp_id;

        }
        public void insert_op()
        {
            var check = cmdOpDam.Get_All().Where(x => x.dam_OP_id == Convert.ToInt32(out_op_idTextEdit.Text)).FirstOrDefault();
            if (check == null)
            {
                is_op_insert = 1;
                TF_OP_Dam = new T_OPeration_Damage();
                Fill_Entitey_op();
                cmdOpDam.Insert_Data(TF_OP_Dam);


                var max_id = cmdOpDam.Get_All().Where(c_id => c_id.dam_OP_id ==
                         cmdOpDam.Get_All().Max(max => max.dam_OP_id)).FirstOrDefault();
                out_op_idTextEdit.Text = max_id.dam_OP_id.ToString();
            }
        }
        private void update_op()
        {
            if (Validate_Data_op())
            {
                Fill_Entitey_op();
                Get_OP_Med_count_Data();
                cmdOpDam.Update_Data(TF_OP_Dam);
                id_toUpdate = 0;
            }

        }
        private void Set_Auto_Id_op()
        {
            var max_id = cmdOpDam.Get_All().Where(c_id => c_id.dam_OP_id ==
                         cmdOpDam.Get_All().Max(max => max.dam_OP_id)).FirstOrDefault();
            out_op_idTextEdit.Text = max_id == null ? "1" : (max_id.dam_OP_id + 1).ToString();
        }


        //*****************مواد الفاتورة*********************
        public bool Validate_Data_item()
        {
            int number_of_errores = 0;
            number_of_errores += out_item_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += out_item_quntityTextEdit1.is_text_valid() ? 0 : 1;

            if (Med_idSearchlookupEdit.EditValue == null)
            {
                number_of_errores += 1;
                Med_idSearchlookupEdit.ErrorText = "هذا الحقل مطلوب";

            }
            if (out_item_quntityTextEdit1.Text != string.Empty)
            {
                int out_item_qun = Convert.ToInt32(out_item_quntityTextEdit1.Text.Replace(",", string.Empty));
                int all_in_qun = Convert.ToInt32(all_in_item_quntityTextEdit.Text.Replace(",", string.Empty));

                if (out_item_qun > all_in_qun || out_item_qun < 0)
                {
                    number_of_errores += 1;
                    out_item_quntityTextEdit1.ErrorText = "يجب أن تكون القيمة المدخلة أكبر من صفر و أقل من الكمية المتوفرة";

                }
            }
            return (number_of_errores == 0);
        }
        public void Fill_Entitey_item()
        {
            TF_OP_Dam_Item.dmg_item_quntity = Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_OP_Dam_Item.dmg_B_It_note = out_B_It_noteMemoEdit.Text;
            TF_OP_Dam_Item.Med_id = med_id_chose;

            TF_OP_Dam_Item.dmg_op_id = Convert.ToInt32(out_op_idTextEdit.Text);
            TF_OP_Dam_Item.in_item_id = int.Parse(dt.Rows[0][6].ToString().ToString().Replace(",", string.Empty));
        }
        public void insert_item()
        {
            TF_OP_Dam_Item = new T_Operation_Damage_Item();
            Fill_Entitey_item();
            cmdOppDamItem.Insert_Data(TF_OP_Dam_Item);
        }
        public void update_item()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (Validate_Data_item() && gv.RowCount > 0 && TF_OP_Dam_Item != null)
                    {

                        Fill_Entitey_item();
                        cmdOppDamItem.Update_Data(TF_OP_Dam_Item);
                        old_item_id = Convert.ToInt32(out_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
                    }
                }
                else
                    C_Master.Warning_Massege_Box("يجب اختيار مادة من الجدول لتعديلها");
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public void delete_item()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (C_Master.Qustion_Massege_Box(C_Master.mas_del) == DialogResult.Yes)
                    {
                        if (gv.RowCount > 0)
                            foreach (int row_id in gv.GetSelectedRows())
                            {
                                Get_Row_ID(row_id);
                                cmdOppDamItem.Delete_Data(TF_OP_Dam_Item);
                                old_item_id = Convert.ToInt32(out_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
                            }




                    }
                }
                else
                    C_Master.Warning_Massege_Box("  بالضغط مرتين يجب اختيار عنصر من الجدول لحذفه");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exeption.FK_Exeption))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        private void Set_Auto_Id_item()
        {
            var max_id = cmdOppDamItem.Get_All().Where(c_id => c_id.dmg_item_id ==
                         cmdOppDamItem.Get_All().Max(max => max.dmg_item_id)).FirstOrDefault();
            out_item_idTextEdit.Text = max_id == null ? "1" : (max_id.dmg_item_id + 1).ToString();

        }
        private void Fill_Graid_item()
        {
            int id = Convert.ToInt32(out_op_idTextEdit.Text);

            DataTable data_source = c_db.select(@"SELECT     T_Operation_Damage_Item.dmg_item_id, T_Operation_Damage_Item.Med_id, T_Medician.med_code, T_Medician.med_name, 
                      T_Operation_Damage_Item.dmg_item_quntity
FROM         T_Operation_Damage_Item INNER JOIN
                      T_Medician ON T_Operation_Damage_Item.Med_id = T_Medician.med_id
WHERE        (dbo.T_Operation_Damage_Item.dmg_op_id = " + id + ")");
            if (data_source != null && data_source.Rows.Count > 0)
            {
                gc.DataSource = data_source;

                //                gv.Columns[0].Visible = false;
                //                gv.Columns[1].Visible = false;
                //                gv.Columns[2].Caption = "كود الدواء";
                //                gv.Columns[3].Caption = "اسم الدواء";

                //                gv.Columns[4].Caption = "الكمية";

                //                gv.Columns[5].Caption = "تاريخ الانتهاء ";
                //                gv.Columns[6].Visible = false;
                //                gv.Columns[7].Caption = " موقع التخزين ";
                //                gv.Columns[8].Visible = false;
                //                gv.BestFitColumns();

            }
        }
        private void clear_item()
        {
            all_in_item_quntityTextEdit.Text = string.Empty;
            out_item_quntityTextEdit1.Text = string.Empty;
            Med_idSearchlookupEdit.EditValue = null;

            ItemForin_item_quntity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            ItemForin_item_quntity3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            Set_Auto_Id_item();
        }
        private void Fill_Controls_Item()
        {
            out_item_idTextEdit.Text = TF_OP_Dam_Item.dmg_item_id.ToString();
            out_item_quntityTextEdit1.Text = TF_OP_Dam_Item.dmg_item_quntity.ToString();
            //  out_item_expDateDateEdit.DateTime = Convert.ToDateTime(TF_OP_Out_Item.out_item_expDate);
            out_B_It_noteMemoEdit.Text = TF_OP_Dam_Item.dmg_B_It_note;
            Med_idSearchlookupEdit.EditValue = TF_OP_Dam_Item.Med_id;
            //  med_storage_place_idSearchLookUpEdit.EditValue = TF_OP_Out_Item.store_place_id;
            out_op_idTextEdit.Text = TF_OP_Dam_Item.T_OPeration_Damage.ToString();
        }

        //********************* توابع جرد الدواء ****************************
        private void Get_Add_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count + Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Medician.med_total_now = TF_Medician.med_total_now - Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            cmdMedician.Update_Data(TF_Medician);
        }
        private void Get_Delete_med_count()
        {
            TF_Medician = new T_Medician();

            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == old_med_id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count - Convert.ToInt32(out_item_quntityTextEdit1.Text);
            TF_Medician.med_total_now = TF_Medician.med_total_now - Convert.ToInt32(out_item_quntityTextEdit1.Text);
            cmdMedician.Update_Data(TF_Medician);
            old_med_id = 0;
        }
        private void Get_Update_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count - old_med_Quntitey + Convert.ToInt32(out_item_quntityTextEdit1.Text);
            TF_Medician.med_total_now = TF_Medician.med_total_now - old_med_Quntitey + Convert.ToInt32(out_item_quntityTextEdit1.Text);
            cmdMedician.Update_Data(TF_Medician);
            old_med_Quntitey = 0;
        }


        //********************* توابع حركة المستودع ****************************
        private void Get_Add_move()
        {

            TF_Store_Move = new T_Store_Move();

            TF_Store_Move.qunt = Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue.ToString().Replace(",", string.Empty));
            TF_Store_Move.item_id = Convert.ToInt32(out_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_id = Convert.ToInt32(out_op_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_type_id = Convert.ToInt32("3");
            TF_Store_Move.date = Convert.ToDateTime(out_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            //   TF_Store_Move.time = (TimeSpan?)out_op_timeTimeSpanEdit.EditValue;

            cmdStoreMove.Insert_Data(TF_Store_Move);
        }
        private void Get_Delete_move()
        {
            TF_Store_Move = new T_Store_Move();

            TF_Store_Move = cmdStoreMove.Get_By(l => l.item_id == old_item_id & l.op_type_id == 3).FirstOrDefault();

            cmdStoreMove.Delete_Data(TF_Store_Move);
        }
        private void Get_Update_move()
        {
            TF_Store_Move = new T_Store_Move();
            TF_Store_Move = cmdStoreMove.Get_By(l => l.item_id == old_item_id & l.op_type_id == 3).FirstOrDefault();

            TF_Store_Move.qunt = Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue.ToString().Replace(",", string.Empty));

            cmdStoreMove.Update_Data(TF_Store_Move);
        }

        //*******************تعبة الداتا***********************

        public void GetEmp_Data()
        {
            var emp_list = (from Emp in cmdEmp.Get_All()
                            select new
                            {
                                id = Emp.Emp_id,
                                name = Emp.Emp_name
                            }).OrderBy(id => id.id);
            if (emp_list != null && emp_list.Count() > 0)
            {
                emp_idSearchLookUpEdit.slkp_iniatalize_data(emp_list, "name", "id");
                emp_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                emp_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }
        }

        public void GetMed_Data()
        {//جلب الدواء من جدول الأدوية بحيث كميته اكبر من 0
            //var med_list = (from Emp in cmdMedician.Get_All().Where(l => l.med_total_now > 0)
            //                select new
            //                {
            //                    id = Emp.med_id,
            //                    name = Emp.med_name
            //                }).OrderBy(id => id.id);

           DataTable med_list = c_db.select(@"SELECT     T_OPeration_IN_Item.Med_id, T_Medician.med_name, T_Medician.med_total_now, T_OPeration_IN_Item.in_item_expDate
FROM         T_OPeration_IN_Item INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id
WHERE     (T_OPeration_IN_Item.is_out = 'false') " +
         "   AND ( MONTH( T_OPeration_IN_Item.in_item_expDate) < " + d.Month + " )" +
       "   AND(T_Medician.med_total_now > 0) "+
         "  AND(year(T_OPeration_IN_Item.in_item_expDate) <= " + d.Year + ") ");

            if (med_list != null && med_list.Rows.Count > 0)
            {
                Med_idSearchlookupEdit.slkp_iniatalize_data(med_list, "med_name", "Med_id");
                Med_idSearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }

        }
        public void Get_Store_med()
        {
            int med_idd = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            if (med_idd > 0)
            {
                var med_list = (from Emp in cmdOpInItem.Get_All().Where(l => l.is_out == false  
                                                                        && l.Med_id == med_idd 
                                                                         &&  l.in_item_expDate.Value.Month < DateTime.Today.Month
                                                                         && l.in_item_expDate.Value.Year <= DateTime.Today.Year)
                                select new
                                {
                                    item_id = Emp.in_item_id,
                                    med_id = Emp.Med_id,
                                    op_id = Emp.In_op_id,
                                    name = Emp.T_Medician.med_name,
                                    quntatey = Emp.in_item_quntity - Emp.out_item_quntitey,
                                    datee = Emp.in_item_expDate,
                                    place = Emp.T_Store_Placees.name,
                                }).OrderBy(l => l.datee).Distinct();


                if (med_list != null && med_list.Count() == 1)
                {
                    get_info_store_med(med_idd);

                }
                else
                    if (med_list != null && med_list.Count() > 1)
                {
                    if (is_op_insert == 0 && Validate_Data_op())
                    {
                        insert_op();

                        //  int item_in_id = Convert.ToInt32(filter_date_searchLookUpEdit.EditValue);
                        int out_op_id = Convert.ToInt32(out_op_idTextEdit.Text);
                        DateTime d = out_op_dateDateEdit.DateTime;
                        F_out_med_to_chose f = new F_out_med_to_chose(med_idd, out_op_id, d, "", 3);
                        f.ShowDialog();
                        Fill_Graid_item();
                        GetMed_Data();
                        Get_OP_Med_count_Data();

                        //Get_Store_med();
                        clear_item();
                        update_op();
                    }
                    else if (is_op_insert == 1 && Validate_Data_op())
                    {
                        //  int item_in_id = Convert.ToInt32(filter_date_searchLookUpEdit.EditValue);
                        int out_op_id = Convert.ToInt32(out_op_idTextEdit.Text);
                        DateTime d = out_op_dateDateEdit.DateTime;
                        F_out_med_to_chose f = new F_out_med_to_chose(med_idd, out_op_id, d, "", 3);
                        f.ShowDialog();
                        GetMed_Data();
                        Fill_Graid_item();
                        Get_OP_Med_count_Data();
                        //Get_Store_med();
                        clear_item();
                        update_op();
                    }
                }
            }
        }
        private void get_info_store_med(int med_idd)
        {
            dt = c_db.select(@"SELECT    T_Medician.med_name,
                                         T_OPeration_IN_Item.in_item_quntity, 
                             T_OPeration_IN_Item.out_item_quntitey,
                            T_OPeration_IN_Item.in_item_expDate, 
                             T_Store_Placees.name ,
                             T_OPeration_IN_Item.In_op_id ,
                             T_OPeration_IN_Item.in_item_id
FROM         T_OPeration_IN_Item INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id
WHERE     (T_OPeration_IN_Item.is_out = 'false')
         AND (T_Medician.med_id = " + med_idd + ")" +
         "   AND ( MONTH( T_OPeration_IN_Item.in_item_expDate) < " + d.Month + " )" +
         "  AND(year(T_OPeration_IN_Item.in_item_expDate) <= " + d.Year + ") ");

            if (dt.Rows.Count == 1)
            {
                ItemForin_item_quntity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForin_item_quntity3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                int in_count_item = int.Parse(dt.Rows[0][1].ToString());
                int out_count_item = int.Parse(dt.Rows[0][2].ToString());
                all_in_item_quntityTextEdit.Text = (in_count_item - out_count_item).ToString();
                dateTimePicker1.Text = dt.Rows[0][3].ToString();
                placeTextEdit2.Text = dt.Rows[0][4].ToString();



            }
        }
        public void Get_OP_Med_count_Data()
        {
            if (out_op_idTextEdit.Text == string.Empty || out_op_idTextEdit.Text == null)
            {
                med_countTextEdit1.Text = "0";
            }
            else
            {
                int op_id = Convert.ToInt32(out_op_idTextEdit.Text.ToString().Replace(",", string.Empty));
                var count = cmdOppDamItem.Get_All().Where(x => x.dmg_op_id == op_id).Count().ToString();
                med_countTextEdit1.Text = count;
            }

        }

        //*****************ازرار استيراد البيانات*******************************

        private void btn_add_emp_Click(object sender, EventArgs e)
        {
            F_Emp f = new F_Emp();
            f.ShowDialog();

            GetEmp_Data();

        }

        //*******************اظهار الداتا في الكومبو**************
        private void Med_idSearchlookupEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdMedician.Get_By(id => id.med_id == e_id).FirstOrDefault().med_name;
                med_id_chose = cmdMedician.Get_By(id => id.med_id == e_id).FirstOrDefault().med_id;

            }
            else
                e.DisplayText = "";
        }
        private void donar_idSearchLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdReciver.Get_By(id => id.id == e_id).FirstOrDefault().name;
            }
            else
                e.DisplayText = "";
        }
        private void emp_idSearchLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdEmp.Get_By(id => id.Emp_id == e_id).FirstOrDefault().Emp_name;
            }
            else
                e.DisplayText = "";
        }

        //***********************أحداث الغريد*************************
        private void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            btn_visible(true);
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_OP_Dam_Item != null)
                Fill_Controls_Item();
        }
        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }
        private void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
            btn_visible(true);

        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OP_Dam_Item = cmdOppDamItem.Get_By(c_id => c_id.dmg_item_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_OP_Dam_Item = cmdOppDamItem.Get_By(c_id => c_id.dmg_item_id == id).FirstOrDefault();
            }
        }


        //******************أزرار الاضافة و الحذف و التعديل*********************
        private void btn_add_item_Click(object sender, EventArgs e)
        {
            if (out_item_quntityTextEdit1.Text == string.Empty)
            {
                out_item_quntityTextEdit1.ErrorText = "هذا الحقل مطلوب";
            }
            else if (Validate_Data_op() && Validate_Data_item())
            {
                if (is_op_insert == 0 && Validate_Data_op())
                    insert_op();
                if (Validate_Data_item())
                    insert_item();
                Fill_Graid_item();
                update_In_item();
                Get_Add_med_count();
                Get_Add_move();
                GetMed_Data();
                clear_item();
                Get_OP_Med_count_Data();
                update_op();

            }

        }

        private void btn_edite_item_Click(object sender, EventArgs e)
        {
            update_item();
            Get_Update_med_count();
            Get_OP_Med_count_Data();
            Get_Update_move();
            GetMed_Data();
            update_op();
            btn_visible(false);
            clear_item();
            Fill_Graid_item();
        }

        private void btn_delet_item_Click(object sender, EventArgs e)
        {
            delete_item();
            Get_Delete_med_count();
            Get_OP_Med_count_Data();
            GetMed_Data();
            Get_Delete_move();
            update_op();
            btn_visible(false);
            clear_item();
            Fill_Graid_item();
        }

        private void Med_idSearchlookupEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            Get_Store_med();

        }


        //*****************تعديل الإدخال*********************      
        public void Fill_Entitey_in_item()
        {

            int out_qunt = Convert.ToInt32(out_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            int in_id = int.Parse(dt.Rows[0][6].ToString());
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
                if (out_item_quntityTextEdit1.Text != string.Empty)
                {
                    Fill_Entitey_in_item();
                    cmdOpInItem.Update_Data(TF_OPeration_IN_Item);
                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }

        private void Med_idSearchlookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            // Get_Store_med();
        }

        private void med_countTextEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void out_item_idTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
