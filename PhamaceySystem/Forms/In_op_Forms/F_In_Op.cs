﻿using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Person_Forms;
using PhamaceySystem.Forms.Store_Other_Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Store_Forms
{
    public partial class F_In_Op : F_Master_Inheretanz
    {
        public F_In_Op()
        {
            InitializeComponent();
            SetRoles();
            view_inheretanz_butomes(true, false, false, false, false, true, true);
            Title(tit);
            this.Text = tit;
        }

        public string tit = "ادخال  مادة / In Operation";

        public F_In_Op(int op_id)
        {
            id_toUpdate = op_id;
            InitializeComponent();
            SetRoles();
            Title(tit);
            this.Text = tit;
            view_inheretanz_butomes(true, true, false, false, false, true, false);

        }
        private void SetRoles()
        {

            if (!C_RoleManeger.GetRole("per_in"))
            {
               

            }
            if (!C_RoleManeger.GetRole("per_out"))
            {
             

            }
            if (!C_RoleManeger.GetRole("per_dam"))
            {
               
            }
            if (!C_RoleManeger.GetRole("per_med"))
            {
                btn_add_med.Enabled = false;
            }
            if (!C_RoleManeger.GetRole("per_thwabet"))
            {
                btn_add_emp.Enabled = false;
                btn_add_donar.Enabled = false;
                btn_add_store_place.Enabled = false;
            }
            if (!C_RoleManeger.GetRole("per_rep"))
            {

            }
            if (!C_RoleManeger.GetRole("per_sysRecord"))
            {

            }
            if (!C_RoleManeger.GetRole("per_seting"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Users"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Db"))
            {

            }
            if (!C_RoleManeger.GetRole("per_Db"))
            {

            }

            if (!C_RoleManeger.GetRole("per_save"))
            {
                btn_add_item.Enabled = false;
            }

            if (!C_RoleManeger.GetRole("per_delete"))
            {
                btn_delet_item.Enabled = false;
            }

            if (!C_RoleManeger.GetRole("per_edite"))
            {

            }

            if (!C_RoleManeger.GetRole("per_print"))
            {

            }
        }

        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();

        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_IN> cmdOpIn = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
        ClsCommander<T_Store_Move> cmdStoreMove = new ClsCommander<T_Store_Move>();

        T_OPeration_IN TF_OP_IN;
        T_OPeration_IN_Item TF_OP_IN_Item;
        T_Medician TF_Medician;
        T_Store_Move TF_Store_Move;

        int is_op_insert = 0;
        DateTime d = DateTime.Now;
        int id_toUpdate = 0;
        Boolean Is_Double_Click = false;
        int old_med_Quntitey = 0;
        int old_med_id = 0;
        int old_item_id = 0;
        int old_in_op = 0;


        List<int> id_store_places;
        List<int> quntettey_list;
        int curent_pace_id = 0;
        int curent_quntety = 0;
        public override void Get_Data(string status_mess)
        {
            try
            {
                //  clear_data(this.Controls);
                Set_Auto_Id_op();
                Set_Auto_Id_item();
                in_op_dateDateEdit.DateTime = Convert.ToDateTime(d.ToShortDateString());
                in_item_expDateDateEdit.DateTime = Convert.ToDateTime(d.ToShortDateString());
                dtp_op_time.Value = Convert.ToDateTime(d.ToShortTimeString());
                Is_Double_Click = false;
                btn_visible(false);
                cmdMedician = new ClsCommander<T_Medician>();
                cmdShape = new ClsCommander<T_Med_Shape>();
                cmdEmp = new ClsCommander<T_Pers_Emploee>();
                cmdDonars = new ClsCommander<T_Pers_Donars>();
                cmdStorageplace = new ClsCommander<T_Store_Placees>();
                cmdOpIn = new ClsCommander<T_OPeration_IN>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
                cmdStoreMove = new ClsCommander<T_Store_Move>();

                GetDonars_Data();
                GetEmp_Data();
                GetMed_Data();
                is_op_insert = 0;
                old_med_Quntitey = 0;
                old_med_id = 0;
                Get_OP_Med_count_Data();
                GetStoragePlace_Data_MulleyCheck();
                btn_add_item.Enabled = true;

                //   med_countTextEdit1.Text = "0";
                if (id_toUpdate != 0)
                {
                    try
                    {

                   
                    TF_OP_IN = new T_OPeration_IN();
                    TF_OP_IN = cmdOpIn.Get_By(i => i.in_op_id == id_toUpdate).FirstOrDefault();

                    Fill_Controls_op();
                    Fill_Graid_item();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.InnerException.InnerException.ToString());
                    }
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
                //layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                //layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        public override void Print_Data()
        {
            C_Master.print_header(
                "- تفاصيل فاتورة الادخال رقم -" +
                    in_op_idTextEdit.Text +
                    " - تاريخ -" +
                    in_op_dateDateEdit.Text +
                    "-المتبرع-" +
                    donar_idSearchLookUpEdit.Text,
                gc);
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
                    Classes.C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  برقم {TF_OP_IN.in_op_id} ");

                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
      
                cmdOpIn.Detached_Data(TF_OP_IN);
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
            clear_op();
            clear_item();

        }

        //*****************عملية الادخال*********************
        public bool Validate_Data_op()
        {
            int number_of_errores = 0;
            number_of_errores += in_op_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += donar_empTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += in_op_dateDateEdit.is_text_valid() ? 0 : 1;
            //  number_of_errores += dateTimePicker1.is_text_valid() ? 0 : 1;

            if (donar_idSearchLookUpEdit.EditValue == null)
            {
                number_of_errores += 1;
                donar_idSearchLookUpEdit.ErrorText = "هذا الحقل مطلوب";
            }
            if (emp_idSearchLookUpEdit.EditValue == null)
            {
                number_of_errores += 1;
                emp_idSearchLookUpEdit.ErrorText = "هذا الحقل مطلوب";
            }

            return (number_of_errores == 0);
        }

        public void Fill_Entitey_op()
        {
            TF_OP_IN.in_op_date = Convert.ToDateTime(in_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_OP_IN.in_op_time = dtp_op_time.Text;
            TF_OP_IN.in_op_text = in_op_textTextEdit.Text;
            TF_OP_IN.in_op_state = Convert.ToBoolean(in_op_stateCheckEdit.CheckState);
            TF_OP_IN.med_count = Convert.ToInt32(med_countTextEdit1.Text.ToString().Replace(",", string.Empty));
            TF_OP_IN.donar_emp = donar_empTextEdit.Text;
            TF_OP_IN.donar_id = Convert.ToInt32(
                donar_idSearchLookUpEdit.EditValue.ToString());
            TF_OP_IN.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString());
            TF_OP_IN.op_type_id = Convert.ToInt32("1");
        }

        public void Fill_Controls_op()
        {
            in_op_idTextEdit.Text = TF_OP_IN.in_op_id.ToString();
            in_op_dateDateEdit.DateTime = Convert.ToDateTime(TF_OP_IN.in_op_date);
            in_op_textTextEdit.Text = TF_OP_IN.in_op_text;
            dtp_op_time.Text = TF_OP_IN.in_op_time.ToString();
            in_op_stateCheckEdit.Checked = Convert.ToBoolean(TF_OP_IN.in_op_state);
            donar_empTextEdit.Text = TF_OP_IN.donar_emp;
            donar_idSearchLookUpEdit.EditValue = TF_OP_IN.donar_id;
            emp_idSearchLookUpEdit.EditValue = TF_OP_IN.emp_id;
            med_countTextEdit1.Text = TF_OP_IN.med_count.ToString();
        }

        public void insert_op()
        {
            var check = cmdOpIn.Get_All()
                .Where(x => x.in_op_id == Convert.ToInt32(in_op_idTextEdit.Text.ToString().Replace(",", string.Empty)))
                .FirstOrDefault();
            if (check == null)
            {
                is_op_insert = 1;
                TF_OP_IN = new T_OPeration_IN();
                Fill_Entitey_op();
                cmdOpIn.Insert_Data(TF_OP_IN);
                Classes.C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  برقم {TF_OP_IN.in_op_id} ");

                var max_id = cmdOpIn.Get_All()
                    .Where(c_id => c_id.in_op_id == cmdOpIn.Get_All().Max(max => max.in_op_id))
                    .FirstOrDefault();
                in_op_idTextEdit.Text = max_id.in_op_id.ToString();
            }
        }
        private void clear_op()
        {
            in_op_dateDateEdit.DateTime = DateTime.Today;
            in_op_textTextEdit.Text = string.Empty;
            dtp_op_time.Text = DateTime.Today.ToShortTimeString();
            donar_empTextEdit.Text = string.Empty;
            donar_idSearchLookUpEdit.EditValue = null;
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
                cmdOpIn.Update_Data(TF_OP_IN);
                id_toUpdate = 0;
            }
        }

        private void Set_Auto_Id_op()
        {
            try
            {

           
            var max_id = cmdOpIn.Get_All()
                .Where(c_id => c_id.in_op_id == cmdOpIn.Get_All().Max(max => max.in_op_id))
                .FirstOrDefault();
            in_op_idTextEdit.Text = max_id == null ? "1" : (max_id.in_op_id + 1).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }

        }

        //*****************مواد الفاتورة*********************
        public bool Validate_Data_item()
        {
            int number_of_errores = 0;
            number_of_errores += in_item_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += in_item_quntityTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += in_item_expDateDateEdit.is_text_valid() ? 0 : 1;

            if (Med_idSearchlookupEdit.EditValue == null)
            {
                number_of_errores += 1;
                Med_idSearchlookupEdit.ErrorText = "هذا الحقل مطلوب";
            }
            if (checkedComboBoxEdit_Store_Place.EditValue.ToString() == string.Empty)
            {
                number_of_errores += 1;
                checkedComboBoxEdit_Store_Place.ErrorText = "هذا الحقل مطلوب";
            }

            return (number_of_errores == 0);
        }

        public void Fill_Entitey_item()
        {

            TF_OP_IN_Item.in_item_expDate = Convert.ToDateTime(in_item_expDateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_OP_IN_Item.in_B_It_note = in_B_It_noteMemoEdit.Text;
            TF_OP_IN_Item.Med_id = Convert.ToInt32(
                Med_idSearchlookupEdit.EditValue.ToString());

            TF_OP_IN_Item.In_op_id = TF_OP_IN.in_op_id;
            TF_OP_IN_Item.is_out = false;
            TF_OP_IN_Item.out_item_quntitey = 0;
        }

        public void insert_item()
        {

            TF_OP_IN_Item = new T_OPeration_IN_Item();
            Fill_Entitey_item();

            TF_OP_IN_Item.in_item_quntity = curent_quntety;
            TF_OP_IN_Item.store_place_id = curent_pace_id;

            cmdOpInItem.Insert_Data(TF_OP_IN_Item);
            Classes.C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  بالرقم {TF_OP_IN_Item.Med_id} بكمية {TF_OP_IN_Item.in_item_quntity} من الفاتورة {TF_OP_IN_Item.In_op_id}");

            var max_id = cmdOpInItem.Get_All()
            .Where(c_id => c_id.in_item_id == cmdOpInItem.Get_All().Max(max => max.in_item_id))
            .FirstOrDefault();
            in_item_idTextEdit.Text = max_id == null ? "1" : (max_id.in_item_id).ToString();


        }

        public void update_item()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (Validate_Data_item() && gv.RowCount > 0 && TF_OP_IN_Item != null)
                    {
                        Fill_Entitey_item();
                        cmdOpInItem.Update_Data(TF_OP_IN_Item);
                        old_item_id = Convert.ToInt32(in_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
                        Classes.C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  بالرقم {TF_OP_IN_Item.Med_id} بكمية {TF_OP_IN_Item.in_item_quntity} من الفاتورة {TF_OP_IN_Item.In_op_id}");


                    }
                }
                else
                    C_Master.Warning_Massege_Box("يجب اختيار مادة من الجدول لتعديلها");
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
             
                cmdOpIn.Detached_Data(TF_OP_IN);
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
                                cmdOpInItem.Delete_Data(TF_OP_IN_Item);
                                Classes.C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  بالرقم {old_med_id} بكمية {TF_OP_IN_Item.in_item_quntity} من الفاتورة {old_in_op}");


                                old_item_id = Convert.ToInt32(
                                    in_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
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
                    cmdOpIn.Detached_Data(TF_OP_IN);
                    cmdOpInItem.Detached_Data(TF_OP_IN_Item);
                    return 0;
                }
                else
                {
                    Get_Data(ex.InnerException.InnerException.ToString());
                    return 0;
                }
                Get_Data("");
                cmdOpInItem.Detached_Data(TF_OP_IN_Item);
            }
        }

        private void Set_Auto_Id_item()
        {
            try
            {

          
            var max_id = cmdOpInItem.Get_All()
                .Where(c_id => c_id.in_item_id == cmdOpInItem.Get_All().Max(max => max.in_item_id))
                .FirstOrDefault();
            in_item_idTextEdit.Text = max_id == null ? "1" : (max_id.in_item_id + 1).ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }

        }

        private void Fill_Graid_item()
        {
            int id = Convert.ToInt32(in_op_idTextEdit.Text);

            DataTable data_source = C_DB.Select(
                @"SELECT     T_OPeration_IN_Item.in_item_id, T_Medician.med_id, T_Medician.med_code, T_Medician.med_name, T_Med_Shape.med_shape_name, 
                      T_OPeration_IN_Item.in_item_quntity, T_OPeration_IN_Item.in_item_expDate, T_Store_Placees.id, T_Store_Placees.name, T_OPeration_IN_Item.In_op_id
FROM         T_OPeration_IN_Item INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id left OUTER JOIN
                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id
WHERE        (dbo.T_OPeration_IN_Item.In_op_id = " +
                    id +
                    ")");
            if (data_source != null && data_source.Rows.Count > 0)
            {
                gc.DataSource = data_source;

                gv.Columns[0].Visible = false;
                gv.Columns[1].Visible = false;
                gv.Columns[2].Caption = "كود الدواء";
                gv.Columns[3].Caption = "اسم الدواء";
                gv.Columns[4].Caption = "شكل الدواء";
                gv.Columns[5].Caption = "الكمية";
                gv.Columns[6].Caption = "تاريخ الانتهاء ";
                gv.Columns[7].Visible = false;
                gv.Columns[8].Caption = " موقع التخزين ";
                gv.Columns[9].Visible = false;
                gv.BestFitColumns();

                gv.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gv.Columns[5].DisplayFormat.FormatString = "N0";

                gv.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gv.Columns[6].DisplayFormat.FormatString = "MM/yyyy";

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
            checkedComboBoxEdit_Store_Place.EditValue = "";
            checkedComboBoxEdit_Store_Place.Text = "";
            checkedComboBoxEdit_Store_Place.SetEditValue("");
            in_item_quntityTextEdit.Text = string.Empty;
            Med_idSearchlookupEdit.EditValue = null;
            btn_add_item.Enabled = true;
            Set_Auto_Id_item();
        }

        private void Fill_Controls_Item()
        {
            in_item_idTextEdit.Text = TF_OP_IN_Item.in_item_id.ToString();
            in_item_quntityTextEdit.Text = TF_OP_IN_Item.in_item_quntity.ToString();
            in_item_expDateDateEdit.DateTime = Convert.ToDateTime(TF_OP_IN_Item.in_item_expDate);
            in_B_It_noteMemoEdit.Text = TF_OP_IN_Item.in_B_It_note;
            Med_idSearchlookupEdit.EditValue = TF_OP_IN_Item.Med_id;
            checkedComboBoxEdit_Store_Place.SetEditValue(TF_OP_IN_Item.store_place_id);
            in_op_idTextEdit.Text = TF_OP_IN_Item.In_op_id.ToString();
        }

        //********************* توابع جرد الدواء ****************************
        private void Get_Add_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);

            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_in_count = TF_Medician.med_in_count +
                curent_quntety;
            TF_Medician.med_total_now = TF_Medician.med_total_now +
                curent_quntety;
            cmdMedician.Update_Data(TF_Medician);
        }

        private void Get_Delete_med_count()
        {
            TF_Medician = new T_Medician();

            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == old_med_id).FirstOrDefault();
            TF_Medician.med_in_count = TF_Medician.med_in_count -
                Convert.ToInt32(in_item_quntityTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Medician.med_total_now = TF_Medician.med_total_now -
                Convert.ToInt32(in_item_quntityTextEdit.Text.ToString().Replace(",", string.Empty));
            cmdMedician.Update_Data(TF_Medician);

        }


        //********************* توابع حركة المستودع ****************************
        private void Get_Add_move()
        {
            TF_Store_Move = new T_Store_Move();

            TF_Store_Move.qunt = curent_quntety;
            TF_Store_Move.med_id = Convert.ToInt32(
                Med_idSearchlookupEdit.EditValue.ToString());
            TF_Store_Move.item_id = Convert.ToInt32(in_item_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_id = Convert.ToInt32(in_op_idTextEdit.Text.ToString().Replace(",", string.Empty));
            TF_Store_Move.op_type_id = Convert.ToInt32("1");
            TF_Store_Move.date = Convert.ToDateTime(in_op_dateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_Store_Move.time = dtp_op_time.Text;
            TF_Store_Move.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue.ToString());
            TF_Store_Move.reciver_id = null;
            TF_Store_Move.donar_id = Convert.ToInt32(donar_idSearchLookUpEdit.EditValue.ToString());
            TF_Store_Move.place_id = curent_pace_id;
            cmdStoreMove.Insert_Data(TF_Store_Move);
        }

        private void Get_Delete_move()
        {
            TF_Store_Move = new T_Store_Move();

            TF_Store_Move = cmdStoreMove.Get_By(l => l.item_id == old_item_id & l.op_type_id == 1).FirstOrDefault();

            cmdStoreMove.Delete_Data(TF_Store_Move);
        }


        //*******************تعبة الداتا***********************


        public void GetStoragePlace_Data_MulleyCheck()
        {
            try
            {

            var place_list = (from Emp in cmdStorageplace.Get_All()
                              select new { id = Emp.id, name = Emp.name, groupp = Emp.groupe, shufel = Emp.shufel }).OrderBy(
                id => id.id);
            if (place_list != null && place_list.Count() > 0)
            {
                checkedComboBoxEdit_Store_Place.chb_comb_iniatalize_data(place_list, "name", "id");
                //med_storage_place_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                //med_storage_place_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
                //med_storage_place_idSearchLookUpEdit.Properties.View.Columns[2].Caption = "مجموعة الرفوف ";
                //med_storage_place_idSearchLookUpEdit.Properties.View.Columns[3].Caption = "رقم الرف ";
            }

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
        }

        public void GetEmp_Data()
        {
            try
            {

    
            var emp_list = (from Emp in cmdEmp.Get_All() select new { id = Emp.Emp_id, name = Emp.Emp_name }).OrderBy(
                id => id.id);
            if (emp_list != null && emp_list.Count() > 0)
            {
                //     emp_idSearchLookUpEdit.Properties.DataSource = emp_list;
                emp_idSearchLookUpEdit.slkp_iniatalize_data(emp_list, "name", "id");
                emp_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                emp_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }
        }
            catch (Exception ex)
            {

               MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
}

        public void GetDonars_Data()
        {
            try
            {

            
            var Donar_list = (from Emp in cmdDonars.Get_All() select new { id = Emp.Donar_id, name = Emp.Donar_name }).OrderBy(
                id => id.id);
            if (Donar_list != null && Donar_list.Count() > 0)
            {
                //     emp_idSearchLookUpEdit.Properties.DataSource = emp_list;
                donar_idSearchLookUpEdit.slkp_iniatalize_data(Donar_list, "name", "id");
                donar_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                donar_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
        }

        public void GetMed_Data()
        {
            try
            {

          
            var med_list = (from Emp in cmdMedician.Get_All()
                            join shape in cmdShape.Get_All()
on Emp.med_shape_id equals shape.med_shape_id into slist

                            from sss in slist.DefaultIfEmpty()
                            select new { id = Emp.med_id, name = Emp.med_name, shape = sss.med_shape_name }).OrderBy(
                id => id.id);
            if (med_list != null && med_list.Count() > 0)
            {
                Med_idSearchlookupEdit.slkp_iniatalize_data(med_list, "name", "id");
                Med_idSearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit.Properties.View.Columns[1].Caption = "الاسم";
                Med_idSearchlookupEdit.Properties.View.Columns[2].Caption = "الشكل";

            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
        }

        public void Get_OP_Med_count_Data()
        {
            try
            {

          
            int op_id = Convert.ToInt32(in_op_idTextEdit.Text);
            var count = cmdOpInItem.Get_All().Where(x => x.In_op_id == op_id).Count().ToString();
            med_countTextEdit1.Text = count;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.InnerException.ToString());
            }
        }

        //*****************ازرار استيراد البيانات*******************************
        private void btn_add_donar_Click(object sender, EventArgs e)
        {
            F_Donars f = new F_Donars();
            f.ShowDialog();

            GetDonars_Data();
        }

        private void btn_add_emp_Click(object sender, EventArgs e)
        {
            F_Emp f = new F_Emp();
            f.ShowDialog();

            GetEmp_Data();
        }

        private void btn_add_med_Click(object sender, EventArgs e)
        {
            F_Med f = new F_Med();
            f.ShowDialog();

            GetMed_Data();
        }

        private void btn_add_store_place_Click(object sender, EventArgs e)
        {
            F_place_store f = new F_place_store();
            f.ShowDialog();
            GetStoragePlace_Data_MulleyCheck();
        }


        //*******************اظهار الداتا في الكومبو**************
        private void Med_idSearchlookupEdit_CustomDisplayText(
            object sender,
            DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdMedician.Get_By(id => id.med_id == e_id).FirstOrDefault().med_name;
            }
            else
                e.DisplayText = "";
        }


        private void donar_idSearchLookUpEdit_CustomDisplayText(
            object sender,
            DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdDonars.Get_By(id => id.Donar_id == e_id).FirstOrDefault().Donar_name;
            }
            else
                e.DisplayText = "";
        }

        private void emp_idSearchLookUpEdit_CustomDisplayText(
            object sender,
            DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
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
            btn_visible(true);
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_OP_IN_Item != null)
            {
                Fill_Controls_Item();
                old_med_Quntitey = Convert.ToInt32(in_item_quntityTextEdit.Text.ToString().Replace(",", string.Empty));
                old_med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
                old_in_op = Convert.ToInt32(in_op_idTextEdit.Text.ToString().Replace(",", string.Empty));


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
            btn_visible(true);
        }

        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString());
                TF_OP_IN_Item = cmdOpInItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(
                    gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString());
                TF_OP_IN_Item = cmdOpInItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
            }
        }


        //******************أزرار الاضافة و الحذف و التعديل*********************
        private void btn_add_item_Click(object sender, EventArgs e)
        {
            if (Validate_Data_op() && Validate_Data_item())
            {
                try
                {
                    quntety_in_places();
                    for (int i = 0; i < id_store_places.Count; i++)
                    {
                        curent_pace_id = id_store_places[i];
                        curent_quntety = quntettey_list[i];
                        // if(is_op_insert == 0 && Validate_Data_op())
                        insert_op();
                        //   if(Validate_Data_item())
                        insert_item();
                        Fill_Graid_item();
                        Get_Add_med_count();
                        Get_Add_move();
                        Get_OP_Med_count_Data();
                        update_op();
                    }
                    clear_item();

                }
                catch (Exception ex)
                {
                    Get_Data(ex.InnerException.InnerException.ToString());
                }
            }
        }

        private void btn_edite_item_Click(object sender, EventArgs e)
        {
            //update_item();
            //Get_Update_med_count();
            //Get_OP_Med_count_Data();
            //Get_Update_move();
            //update_op();
            //btn_visible(false);
            //clear_item();
            //Fill_Graid_item();
            //btn_add_item.Enabled = true;
        }

        private void btn_delet_item_Click(object sender, EventArgs e)
        {
            int done = delete_item();
            if (done == 1)
            {
                Get_Delete_med_count();
                Get_OP_Med_count_Data();
                Get_Delete_move();
                update_op();
                btn_visible(false);

            }
            clear_item();
            Fill_Graid_item();
            btn_add_item.Enabled = true;
            old_med_id = 0;
            old_med_id = 0;
            old_med_Quntitey = 0;
            btn_visible(false);
        }


        private void checkedComboBoxEdit_Store_Place_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //التحقق من وجود عناصر محددة
            if (checkedComboBoxEdit_Store_Place.Properties.Items.GetCheckedValues().Count() > 0)
            {
                id_store_places = new List<int>();
                // إضافة العناصر المحددة
                foreach (var item in checkedComboBoxEdit_Store_Place.Properties.Items.GetCheckedValues())
                {
                    int id = int.Parse(item.ToString());
                    if (!id_store_places.Contains(id))
                    {
                        id_store_places.Add(id);
                    }
                }

                List<object> uncheckedValues = GetUnCheckedValues();

                // إزالة العناصر التي تم إلغاء تحديدها
                foreach (var item in uncheckedValues)
                {
                    int x = Convert.ToInt32(item.ToString());
                    if (id_store_places.Contains(x))
                    {
                        id_store_places.Remove(x);

                    }
                }

            }

        }
        private List<object> GetUnCheckedValues()
        {
            List<object> uncheckedValues = new List<object>();

            for (int i = 0; i < checkedComboBoxEdit_Store_Place.Properties.Items.Count; i++)
            {
                if (Convert.ToBoolean(checkedComboBoxEdit_Store_Place.Properties.Items[i].CheckState) == false)
                {
                    uncheckedValues.Add(checkedComboBoxEdit_Store_Place.Properties.Items[i].Value);
                }
            }

            return uncheckedValues;
        }



        private void quntety_in_places()
        {
            int total_all = Convert.ToInt32(in_item_quntityTextEdit.Text.ToString().Replace(",", string.Empty));

            quntettey_list = new List<int>();
            //   int albaqe = total_all;
            if (total_all < id_store_places.Count)
            {
                checkedComboBoxEdit_Store_Place.ErrorText = " يجب أن تكون الكمية أصغر أو تساوي " + id_store_places.Count;

            }
            else if (total_all >= id_store_places.Count)
            {

                int quantityPerShelf = total_all / id_store_places.Count;
                int remainingQuantity = total_all % id_store_places.Count;

                for (int i = 0; i < id_store_places.Count; i++)
                {

                    int quantity = quantityPerShelf;
                    if (i < remainingQuantity)
                    {
                        quantity++;
                    }

                    quntettey_list.Add(quantity);

                }
            }

        }
    }


}

