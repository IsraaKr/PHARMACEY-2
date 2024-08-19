﻿using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
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

            view_inheretanz_butomes(true, false, false, false, false, true,true);

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
            view_inheretanz_butomes(true, true, false, false, false, true,true);
        }
 ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
  ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
  ClsCommander<T_OPeration_Damage> cmdOpDam = new ClsCommander<T_OPeration_Damage>();
  ClsCommander<T_Operation_Damage_Item> cmdOppDamItem = new ClsCommander<T_Operation_Damage_Item>();
  ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
  ClsCommander<T_Store_Move> cmdStoreMove = new ClsCommander<T_Store_Move>();
  ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();
  ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();

        T_OPeration_IN_Item TF_OPeration_IN_Item;
        T_OPeration_Damage TF_OP_Dam;
        T_Operation_Damage_Item TF_OP_Dam_Item;
        T_Medician TF_Medician;
        T_Store_Move TF_Store_Move;

        int is_op_insert = 0;
  readonly      DateTime d = DateTime.Now;
        int id_toUpdate = 0;
        Boolean Is_Double_Click = false;
        int med_id_chose = 0;
        int old_med_Quntitey;
        int old_med_id;
        int old_item_id = 0;
        int old_IN_item_id = 0;
        int old_dam_op = 0;
        DataTable dt;
        public override void Get_Data(string status_mess)
        {
            try
            {
                // clear_data(this.Controls);

                Set_Auto_Id_item();
                Set_Auto_Id_op();

                dam_op_dateDateEdit.DateTime = Convert.ToDateTime(d.ToShortDateString());
                dtp_op_time.Value = Convert.ToDateTime(d.ToShortTimeString());
               dtp_op_time.CalendarTitleBackColor = dam_op_dateDateEdit.BackColor;
                dtp_op_time.CalendarMonthBackground = dam_op_dateDateEdit.BackColor;

                Is_Double_Click = false;
                Btn_visible(false);

                cmdMedician = new ClsCommander<T_Medician>();
                cmdMedician = new ClsCommander<T_Medician>();
                cmdEmp = new ClsCommander<T_Pers_Emploee>();
                cmdOpDam = new ClsCommander<T_OPeration_Damage>();
                cmdOppDamItem = new ClsCommander<T_Operation_Damage_Item>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
                cmdStorageplace = new ClsCommander<T_Store_Placees>();
                GetEmp_Data();
                GetMed_Data();
                //    Get_Store_med();
                //  GetStoragePlace_Data();
                is_op_insert = 0;
                Get_OP_Med_count_Data();
                btn_add_item.Enabled = true;

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
        private void Btn_visible(bool states)
        {
            if (states)
            {
             //   layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
             //   layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }
        public override void Print_Data()
        {
            C_Master.print_header("- تفاصيل فاتورة الإتلاف رقم -"
                      + dam_op_idTextEdit.Text + " - تاريخ -" + dam_op_dateDateEdit.Text
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
                   Classes. C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  برقم {TF_OP_Dam.dam_OP_id} ");

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
            btn_add_item.Enabled = true;

        }
        public override void neew()
        {
            base.neew();
            Get_Data("");
            Set_Auto_Id_op();
            Set_Auto_Id_item();
            gc.DataSource = null;
            gv.Columns.Clear(); 
            btn_add_item.Enabled = true;
            Clear_op();
            clear_item();
        }

        //*****************عملية الإتلاف*********************
        public bool Validate_Data_op()
        {
            int number_of_errores = 0;
            number_of_errores += dam_op_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += dam_op_textTextEdit.is_text_valid() ? 0 : 1;


            if (emp_idSearchLookUpEdit.EditValue == null)
            {
                number_of_errores += 1;
                emp_idSearchLookUpEdit.ErrorText = "هذا الحقل مطلوب";
            }

            return (number_of_errores == 0);
        }
        public void Fill_Entitey_op()
        {

            TF_OP_Dam.dam_op_date = Convert.ToDateTime(dam_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_OP_Dam.dam_op_time = dtp_op_time.Text;
            TF_OP_Dam.dam_op_text = dam_op_textTextEdit.Text;
            TF_OP_Dam.dam_op_state = Convert.ToBoolean(out_op_stateCheckEdit.CheckState);
            TF_OP_Dam.med_count = Convert.ToInt32(med_countTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_OP_Dam.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString());
            TF_OP_Dam.op_type_id = Convert.ToInt32("3");

        }
        public void Fill_Controls_op()
        {
            dam_op_idTextEdit.Text = TF_OP_Dam.dam_OP_id.ToString();
            dam_op_dateDateEdit.DateTime = Convert.ToDateTime(TF_OP_Dam.dam_op_date);
            dtp_op_time.Text = TF_OP_Dam.dam_op_time;
            dam_op_textTextEdit.Text = TF_OP_Dam.dam_op_text;
            out_op_stateCheckEdit.Checked = Convert.ToBoolean(TF_OP_Dam.dam_op_state);
            med_countTextEdit1.Text = TF_OP_Dam.med_count.ToString();
            emp_idSearchLookUpEdit.EditValue = TF_OP_Dam.emp_id;

        }
        public void Insert_op()
        {
            var check = cmdOpDam.Get_All().Where(x => x.dam_OP_id == Convert.ToInt32(dam_op_idTextEdit.Text)).FirstOrDefault();
            if (check == null)
            {
                is_op_insert = 1;
                TF_OP_Dam = new T_OPeration_Damage();
                Fill_Entitey_op();
                cmdOpDam.Insert_Data(TF_OP_Dam);
             Classes.   C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  برقم {TF_OP_Dam.dam_OP_id} ");



                var max_id = cmdOpDam.Get_All().Where(c_id => c_id.dam_OP_id ==
                         cmdOpDam.Get_All().Max(max => max.dam_OP_id)).FirstOrDefault();
                dam_op_idTextEdit.Text = max_id.dam_OP_id.ToString();
            }
        }
        private void Clear_op()
        {
            dam_op_dateDateEdit.DateTime = DateTime.Today;
            dam_op_textTextEdit.Text = string.Empty;
            dtp_op_time.Text = DateTime.Today.ToShortTimeString();
          
            emp_idSearchLookUpEdit.EditValue = null;
            med_countTextEdit1.Text = "0";

            Set_Auto_Id_op();
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
            dam_op_idTextEdit.Text = max_id == null ? "1" : (max_id.dam_OP_id + 1).ToString();
        }


        //*****************مواد الفاتورة*********************
        public bool Validate_Data_item()
        {
            int number_of_errores = 0;
            number_of_errores += dam_item_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += dam_item_quntityTextEdit1.is_text_valid() ? 0 : 1;

            if (Med_idSearchlookupEdit.EditValue == null)
            {
                number_of_errores += 1;
                Med_idSearchlookupEdit.ErrorText = "هذا الحقل مطلوب";

            }
            if (dam_item_quntityTextEdit1.Text != string.Empty)
            {
                int out_item_qun = Convert.ToInt32(dam_item_quntityTextEdit1.Text.Replace(",", string.Empty));
                int all_in_qun = Convert.ToInt32(all_in_item_quntityTextEdit.Text.Replace(",", string.Empty));

                if (out_item_qun > all_in_qun || out_item_qun < 0)
                {
                    number_of_errores += 1;
                    dam_item_quntityTextEdit1.ErrorText = "يجب أن تكون القيمة المدخلة أكبر من صفر و أقل من الكمية المتوفرة";

                }
            }
            return (number_of_errores == 0);
        }
        public void Fill_Entitey_item()
        {
            TF_OP_Dam_Item.dmg_item_quntity = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_OP_Dam_Item.dmg_B_It_note = out_B_It_noteMemoEdit.Text;
            TF_OP_Dam_Item.Med_id = med_id_chose;

            TF_OP_Dam_Item.dmg_op_id = Convert.ToInt32(dam_op_idTextEdit.Text);
            TF_OP_Dam_Item.in_item_id = int.Parse(dt.Rows[0][8].ToString().ToString());
        }
        public void Insert_item()
        {
            TF_OP_Dam_Item = new T_Operation_Damage_Item();
            Fill_Entitey_item();
            cmdOppDamItem.Insert_Data(TF_OP_Dam_Item);
         Classes.   C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  بالرقم {TF_OP_Dam_Item.Med_id} بكمية {TF_OP_Dam_Item.dmg_item_quntity} من الفاتورة {TF_OP_Dam_Item.dmg_op_id}");

            var max_id = cmdOppDamItem.Get_All().Where(c_id => c_id.dmg_item_id ==
                        cmdOppDamItem.Get_All().Max(max => max.dmg_item_id)).FirstOrDefault();
            dam_item_idTextEdit.Text = max_id == null ? "1" : (max_id.dmg_item_id ).ToString();
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
                     Classes.   C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  بالرقم {TF_OP_Dam_Item.Med_id} بكمية {TF_OP_Dam_Item.dmg_item_quntity} من الفاتورة {TF_OP_Dam_Item.dmg_op_id}");

                        old_item_id = Convert.ToInt32(dam_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
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
        public int delete_item()
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
                             Classes.   C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  بالرقم {old_med_id} بكمية {TF_OP_Dam_Item.dmg_item_quntity} من الفاتورة {old_dam_op}");

                                old_item_id = Convert.ToInt32(dam_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
                                return 1;
                            }

                        return 1;
                    }
                    else
                    {
                        clear_item();
                        return 0;
                    }
                }
                else

                {
                    C_Master.Warning_Massege_Box("  بالضغط مرتين يجب اختيار عنصر من الجدول لحذفه");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exception.FK_Exception))
                {
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                    cmdOpDam.Detached_Data(TF_OP_Dam);
                    cmdOppDamItem.Detached_Data(TF_OP_Dam_Item);
                    cmdOpInItem.Detached_Data(TF_OPeration_IN_Item);
                    return 0;

                }
                else
                {
                    Get_Data(ex.InnerException.InnerException.ToString());
                    return 0;
                }
            }
        }
        private void Set_Auto_Id_item()
        {
            var max_id = cmdOppDamItem.Get_All().Where(c_id => c_id.dmg_item_id ==
                         cmdOppDamItem.Get_All().Max(max => max.dmg_item_id)).FirstOrDefault();
            dam_item_idTextEdit.Text = max_id == null ? "1" : (max_id.dmg_item_id + 1).ToString();

        }
        private void Fill_Graid_item()
        {
            int id = Convert.ToInt32(dam_op_idTextEdit.Text);

            DataTable data_source = C_DB.Select(@"SELECT     T_Operation_Damage_Item.dmg_item_id,
T_Operation_Damage_Item.Med_id, T_Medician.med_code, T_Medician.med_name, T_Med_Shape.med_shape_name, 
                      T_Operation_Damage_Item.dmg_item_quntity, T_Operation_Damage_Item.in_item_id, T_OPeration_IN_Item.in_item_expDate, T_OPeration_IN_Item.store_place_id, 
                      T_Store_Placees.name
FROM         T_Operation_Damage_Item INNER JOIN
                      T_Medician ON T_Operation_Damage_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_OPeration_IN_Item ON T_Operation_Damage_Item.in_item_id = T_OPeration_IN_Item.in_item_id AND 
                      T_Medician.med_id = T_OPeration_IN_Item.Med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id INNER JOIN
                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id  WHERE        (dbo.T_Operation_Damage_Item.dmg_op_id = " + id + ")");
            gc.DataSource = data_source;
            if (data_source != null && data_source.Rows.Count > 0)
            {
             
                gv.Columns[0].Visible = false;
                gv.Columns[1].Visible = false;
                gv.Columns[2].Caption = "كود الدواء"; ;
                gv.Columns[3].Caption = "اسم الدواء";
                gv.Columns[4].Caption = "شكل الدواء";
                gv.Columns[5].Caption = "الكمية";
                gv.Columns[6].Visible = false;
                gv.Columns[7].Caption = "انتهاء الصلاحية";
                gv.Columns[8].Visible = false;
                gv.Columns[9].Caption = "مكان التخزين";

                gv.BestFitColumns();
                gv.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gv.Columns[5].DisplayFormat.FormatString = "N0";

                gv.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gv.Columns[7].DisplayFormat.FormatString = "MM/yyyy";

                if (gv.Columns[5].Summary.Count == 0)
                {
               
                    gv.OptionsView.ShowFooter = true;
                gv.Columns[5].Summary.Add(DevExpress.Data.SummaryItemType.Sum, gv.Columns[5].FieldName.ToString(), "المجموع = {0}");
                gv.Columns[3].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[3].FieldName.ToString(), "عدد المواد = {0}");
                }
                if (gv.GroupSummary.Count == 0)
                {
                    DevExpress.XtraGrid.GridGroupSummaryItem item = new DevExpress.XtraGrid.GridGroupSummaryItem();
                    item.DisplayFormat = "_____مجموع الكميات= {0}";
                    item.FieldName = gv.Columns[5].FieldName.ToString();
                    item.ShowInGroupColumnFooter = gv.Columns["show in group row"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gv.GroupSummary.Add(item);
                }
            }
        }
        private void clear_item()
        {
            all_in_item_quntityTextEdit.Text = string.Empty;
            dam_item_quntityTextEdit1.Text = string.Empty;
            Med_idSearchlookupEdit.EditValue = null;

            ItemForin_item_quntity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            ItemForin_item_quntity3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            btn_add_item.Enabled = true;

            Set_Auto_Id_item();
        }
        private void Fill_Controls_Item()
        {
            dam_item_idTextEdit.Text = TF_OP_Dam_Item.dmg_item_id.ToString();
            dam_item_quntityTextEdit1.Text = TF_OP_Dam_Item.dmg_item_quntity.ToString();
            //  out_item_expDateDateEdit.DateTime = Convert.ToDateTime(TF_OP_Out_Item.out_item_expDate);
            out_B_It_noteMemoEdit.Text = TF_OP_Dam_Item.dmg_B_It_note;
            Med_idSearchlookupEdit.EditValue = TF_OP_Dam_Item.Med_id;
            //  med_storage_place_idSearchLookUpEdit.EditValue = TF_OP_Out_Item.store_place_id;
            dam_op_idTextEdit.Text = TF_OP_Dam_Item.dmg_op_id.ToString();
        }

        //********************* توابع جرد الدواء ****************************
        private void Get_Add_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count + Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Medician.med_total_now = TF_Medician.med_total_now - Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            cmdMedician.Update_Data(TF_Medician);
        }
        private void Get_Delete_med_count()
        {
            TF_Medician = new T_Medician();

            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == old_med_id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count - Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Medician.med_total_now = TF_Medician.med_total_now + Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            cmdMedician.Update_Data(TF_Medician);
           
        }
        private void Get_Update_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_dam_count = TF_Medician.med_dam_count - old_med_Quntitey + Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Medician.med_total_now = TF_Medician.med_total_now - old_med_Quntitey + Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            cmdMedician.Update_Data(TF_Medician);
            old_med_Quntitey = 0;
        }


        //********************* توابع حركة المستودع ****************************
        private void Get_Add_move()
        {

            TF_Store_Move = new T_Store_Move();

            TF_Store_Move.qunt = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue.ToString());
            TF_Store_Move.item_id = Convert.ToInt32(dam_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_id = Convert.ToInt32(dam_op_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_type_id = Convert.ToInt32("3");
            TF_Store_Move.date = Convert.ToDateTime(dam_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_Store_Move.time = dtp_op_time.Text;
            TF_Store_Move.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString());
            TF_Store_Move.reciver_id = null;
            TF_Store_Move.donar_id = null;
            TF_Store_Move.place_id = null;
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

            TF_Store_Move.qunt = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue.ToString());
            TF_Store_Move.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString());

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
    {
            
            //جلب الدواء من جدول الأدوية بحيث كميته اكبر من 0
//            //var med_list = (from Emp in cmdMedician.Get_All().Where(l => l.med_total_now > 0)
//            //                select new
//            //                {
//            //                    id = Emp.med_id,
//            //                    name = Emp.med_name
//            //                }).OrderBy(id => id.id);

//           DataTable med_list = C_DB.select(@"SELECT     T_OPeration_IN_Item.Med_id, T_Medician.med_name, T_Med_Shape.med_shape_name, T_Medician.med_total_now, T_OPeration_IN_Item.in_item_expDate
//FROM         T_OPeration_IN_Item INNER JOIN
//                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id left JOIN
//                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id
//WHERE     (T_OPeration_IN_Item.is_out = 'false') " +
//         "   AND ( MONTH( T_OPeration_IN_Item.in_item_expDate) < " + d.Month + " )" +
//       "   AND(T_Medician.med_total_now > 0) "+
//         "  AND(year(T_OPeration_IN_Item.in_item_expDate) <= " + d.Year + ") ");

//            if (med_list != null && med_list.Rows.Count > 0)
//            {
//                Med_idSearchlookupEdit.slkp_iniatalize_data(med_list, "med_name", "Med_id");
//                Med_idSearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
//                Med_idSearchlookupEdit.Properties.View.Columns[1].Caption = "الاسم";
//                Med_idSearchlookupEdit.Properties.View.Columns[2].Caption = "الشكل";
//                Med_idSearchlookupEdit.Properties.View.Columns[3].Caption = "الاجمالي";
//                Med_idSearchlookupEdit.Properties.View.Columns[4].Caption = "انتهاء الصلاحية";
//جلب الدواء من جدول الأدوية بحيث كميته اكبر من 0
            var med_list = (from Emp in cmdMedician.Get_All().Where(l => l.med_total_now > 0)


                            join shape in cmdShape.Get_All()
on Emp.med_shape_id equals shape.med_shape_id into slist

                            from sss in slist.DefaultIfEmpty()
                            select new
                            {
                                id = Emp.med_id,
                                name = Emp.med_name,
                                shape = sss.med_shape_name

                            }).OrderBy(id => id.id);
            if (med_list != null && med_list.Count() > 0)
            {
                Med_idSearchlookupEdit.slkp_iniatalize_data(med_list, "name", "id");
                Med_idSearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit.Properties.View.Columns[1].Caption = "الاسم ";
                Med_idSearchlookupEdit.Properties.View.Columns[2].Caption = "الشكل ";

            }


            }

        
        public void Get_Store_med()
        {
            //int med_idd = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            //if (med_idd > 0)
            //{
                //var med_list = (from Emp in cmdOpInItem.Get_All().Where(l => l.is_out == false  
                //                                                        && l.Med_id == med_idd 
                //                                                         &&  l.in_item_expDate.Value.Month < DateTime.Today.Month
                //                                                         && l.in_item_expDate.Value.Year <= DateTime.Today.Year)

                //                join xxx in cmdMedician.Get_All()
                //           on Emp.Med_id equals xxx.med_id into list
                //                from yyy in list.DefaultIfEmpty()
                //                join place in cmdStore_place.Get_All()
                //          on Emp.store_place_id equals place.id into plist
                //                from ppp in plist.DefaultIfEmpty()
                //                join shape in cmdShape.Get_All()
                //            on yyy.med_shape_id equals shape.med_shape_id into slist

                //                from sss in slist.DefaultIfEmpty()


                //                select new
                //                {
                //                    item_id = Emp.in_item_id,
                //                    med_id = Emp.Med_id,
                //                    op_id = Emp.In_op_id,
                //                    name =yyy.med_name,
                //                    shape=sss.med_shape_name,
                //                    quntatey = Emp.in_item_quntity - Emp.out_item_quntitey,
                //                    datee = Emp.in_item_expDate,
                //                    place = ppp.name,
                //                }).OrderBy(l => l.datee).Distinct();
                int med_idd = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
                if (med_idd > 0)
                {
                    var med_list = (from Emp in cmdOpInItem.Get_All().Where(l => l.is_out == false && l.Med_id == med_idd)
                                    join xxx in cmdMedician.Get_All()
                               on Emp.Med_id equals xxx.med_id into list
                                    from yyy in list.DefaultIfEmpty()
                                    join place in cmdStorageplace.Get_All()
                              on Emp.store_place_id equals place.id into plist
                                    from ppp in plist.DefaultIfEmpty()
                                    join shape in cmdShape.Get_All()
    on yyy.med_shape_id equals shape.med_shape_id into slist

                                    from sss in slist.DefaultIfEmpty()

                                    select new
                                    {
                                        item_id = Emp.in_item_id,
                                        med_id = Emp.Med_id,
                                        op_id = Emp.In_op_id,
                                        name = yyy.med_name,
                                        shape = sss.med_shape_name,
                                        quntatey = Emp.in_item_quntity - Emp.out_item_quntitey,
                                        datee = Emp.in_item_expDate,
                                        place = ppp.name,
                                    }).OrderBy(l => l.datee);//.Distinct();


                //    if (med_list != null && med_list.Count() == 1)
                //{
                //    get_info_store_med(med_idd);

                //}
                //else
                    if (med_list != null && med_list.Count() >= 1)
                {
                    if (is_op_insert == 0 && Validate_Data_op())
                    {
                        Insert_op();

                        //  int item_in_id = Convert.ToInt32(filter_date_searchLookUpEdit.EditValue);
                        int out_op_id = Convert.ToInt32(dam_op_idTextEdit.Text);
                        DateTime d = dam_op_dateDateEdit.DateTime;
                        string t = dtp_op_time.Text;
                        int emp= Convert.ToInt32(emp_idSearchLookUpEdit.EditValue);
                        F_out_med_to_chose f = new F_out_med_to_chose(med_idd, out_op_id, d,t, 3 , emp ,0);
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
                        int out_op_id = Convert.ToInt32(dam_op_idTextEdit.Text);
                        DateTime d = dam_op_dateDateEdit.DateTime;
                        string t = dtp_op_time.Text;
                        int emp = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue);
                        F_out_med_to_chose f = new F_out_med_to_chose(med_idd, out_op_id, d,t, 3, emp ,0);
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
            //            dt = C_DB.select(@"SELECT    T_Medician.med_name,
            //                                         T_OPeration_IN_Item.in_item_quntity, 
            //                             T_OPeration_IN_Item.out_item_quntitey,
            //                            T_OPeration_IN_Item.in_item_expDate, 
            //                             T_Store_Placees.name ,
            //                             T_OPeration_IN_Item.In_op_id ,
            //                             T_OPeration_IN_Item.in_item_id
            //FROM         T_OPeration_IN_Item INNER JOIN
            //                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
            //                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id
            //WHERE     (T_OPeration_IN_Item.is_out = 'false')
            //         AND (T_Medician.med_id = " + med_idd + ")" +
            //         "   AND ( MONTH( T_OPeration_IN_Item.in_item_expDate) < " + d.Month + " )" +
            //         "  AND(year(T_OPeration_IN_Item.in_item_expDate) <= " + d.Year + ") ");

            //            if (dt.Rows.Count == 1)
            //            {
            //                ItemForin_item_quntity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //                ItemForin_item_quntity3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            //                int in_count_item = int.Parse(dt.Rows[0][1].ToString());
            //                int out_count_item = int.Parse(dt.Rows[0][2].ToString());
            //                all_in_item_quntityTextEdit.Text = (in_count_item - out_count_item).ToString();
            //                dtp_exp_date.Text = dt.Rows[0][3].ToString();
            //                placeTextEdit2.Text = dt.Rows[0][4].ToString();

            dt = C_DB.Select(@"SELECT     T_Medician.med_name,
T_Med_Shape.med_shape_name,
T_OPeration_IN_Item.in_item_quntity, 
T_OPeration_IN_Item.out_item_quntitey, 
                      T_Medician.med_total_now,
T_OPeration_IN_Item.in_item_expDate, 
T_Store_Placees.name, 
T_OPeration_IN_Item.In_op_id, 
T_OPeration_IN_Item.in_item_id
FROM         T_OPeration_IN_Item INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id left JOIN
                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id
WHERE     (T_OPeration_IN_Item.in_item_id  =  " + old_IN_item_id + ") AND (T_Medician.med_id = " + med_idd + ")");

            if (dt.Rows.Count == 1)
            {
                ItemForin_item_quntity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForin_item_quntity3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                int in_count_item = int.Parse(dt.Rows[0][2].ToString());
                int out_count_item = int.Parse(dt.Rows[0][3].ToString());
                //all_in_item_quntityTextEdit.Text = (in_count_item - out_count_item).ToString();
                all_in_item_quntityTextEdit.Text = (dt.Rows[0][4].ToString());

                dtp_exp_date.Text = dt.Rows[0][5].ToString();
                placeTextEdit2.Text = dt.Rows[0][6].ToString();



            }

        
        }
        public void Get_OP_Med_count_Data()
        {
            if (dam_op_idTextEdit.Text == string.Empty || dam_op_idTextEdit.Text == null)
            {
                med_countTextEdit1.Text = "0";
            }
            else
            {
                int op_id = Convert.ToInt32(dam_op_idTextEdit.Text.ToString().Replace(",", string.Empty));
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
            btn_add_item.Enabled = false;
            Btn_visible(true);
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_OP_Dam_Item != null)
            {
                Fill_Controls_Item();
                old_IN_item_id = Convert.ToInt32(TF_OP_Dam_Item.in_item_id);

                old_item_id = Convert.ToInt32(dam_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
                old_med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
                old_med_Quntitey = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
                dam_item_quntityTextEdit1.Enabled = false;
                Med_idSearchlookupEdit.Enabled = false;
         old_dam_op = Convert.ToInt32(dam_op_idTextEdit.Text.ToString().Replace(",", string.Empty));

            }
        }
        private void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }
        private void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
            Btn_visible(true);

        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString());
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
            if (dam_item_quntityTextEdit1.Text == string.Empty)
            {
                dam_item_quntityTextEdit1.ErrorText = "هذا الحقل مطلوب";
            }
            else if (Validate_Data_op() && Validate_Data_item())
            {
                if (is_op_insert == 0 && Validate_Data_op())
                    Insert_op();
                if (Validate_Data_item())
                    Insert_item();
                Fill_Graid_item();
                update_In_item_with_Add();
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
            //update_item();
            //Get_Update_med_count();
            //Get_OP_Med_count_Data();
            //Get_Update_move();
            //GetMed_Data();
            //update_op();
            //btn_visible(false);
            //clear_item();
            //Fill_Graid_item();
        }

        private void btn_delet_item_Click(object sender, EventArgs e)
        {
            int done = delete_item();
            if (done == 1)
            {
                update_In_item_with_Delete();
            Get_Delete_med_count();
            Get_OP_Med_count_Data();
            GetMed_Data();
            Get_Delete_move();
            update_op();
            Btn_visible(false);
            }
            clear_item();
            Fill_Graid_item();

            dam_item_quntityTextEdit1.Enabled = true;
            Med_idSearchlookupEdit.Enabled = true;
            btn_add_item.Enabled = true;

            old_med_id = 0;
            old_med_id = 0;
            old_med_Quntitey = 0;
            old_IN_item_id = 0;
            Btn_visible(false);

        }

        private void Med_idSearchlookupEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            Get_Store_med();

        }


        //*****************تعديل الإدخال*********************      
      
        public void update_In_item_with_Add()
        {
            try
            {
                if (dam_item_quntityTextEdit1.Text != string.Empty)
                {
                    int out_qunt = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
                    int in_id = int.Parse(dt.Rows[0][8].ToString());
                    TF_OPeration_IN_Item = new T_OPeration_IN_Item();
                    TF_OPeration_IN_Item = cmdOpInItem.Get_By(l => l.in_item_id == in_id).FirstOrDefault();

                    TF_OPeration_IN_Item.out_item_quntitey = TF_OPeration_IN_Item.out_item_quntitey + out_qunt;
                    if (TF_OPeration_IN_Item.out_item_quntitey == TF_OPeration_IN_Item.in_item_quntity)
                        TF_OPeration_IN_Item.is_out = true;
                    else
                        TF_OPeration_IN_Item.is_out = false;
                    cmdOpInItem.Update_Data(TF_OPeration_IN_Item);
                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public void update_In_item_with_Delete()
        {
            try
            {
                if (dam_item_quntityTextEdit1.Text != string.Empty)
                {
                    int med_idd = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);

                    get_info_store_med(med_idd);
                    int out_qunt = Convert.ToInt32(dam_item_quntityTextEdit1.Text.ToString().Replace(",", string.Empty));
                    int in_id = int.Parse(dt.Rows[0][8].ToString());
                    TF_OPeration_IN_Item = new T_OPeration_IN_Item();
                    TF_OPeration_IN_Item = cmdOpInItem.Get_By(l => l.in_item_id == in_id).FirstOrDefault();

                    TF_OPeration_IN_Item.out_item_quntitey = TF_OPeration_IN_Item.out_item_quntitey - out_qunt;
                    if (TF_OPeration_IN_Item.out_item_quntitey == TF_OPeration_IN_Item.in_item_quntity)
                        TF_OPeration_IN_Item.is_out = true;
                    else
                        TF_OPeration_IN_Item.is_out = false;

                    cmdOpInItem.Update_Data(TF_OPeration_IN_Item);
                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
   
    }
}
