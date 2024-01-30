using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Person_Forms;
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
    public partial class F_In_Op : F_Master_Inheretanz
    {
        public F_In_Op()
        {
            InitializeComponent();
            Title("ادخال  مادة / In Operation");

            view_inheretanz_butomes(true, false, false, false, false, false, true);
        }
        public F_In_Op(int op_id)
        {
            id_toUpdate = op_id;
            InitializeComponent();
            Title("ادخال  مادة / In Operation");

            view_inheretanz_butomes(true, true, false, false, false, false, true);
        }
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_IN> cmdOpIn = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

        T_OPeration_IN TF_OP_IN;
        T_OPeration_IN_Item TF_OP_IN_Item;
        T_Medician TF_Medician;

        int is_op_insert = 0;
        DateTime d = DateTime.Today;
        int id_toUpdate = 0;
        Boolean Is_Double_Click = false;
        int old_med_Quntitey;
        int old_med_id;

        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                btn_visible(false);
      
                cmdMedician = new ClsCommander<T_Medician>();
                cmdEmp = new ClsCommander<T_Pers_Emploee>();
                cmdDonars = new ClsCommander<T_Pers_Donars>();
                cmdStorageplace = new ClsCommander<T_Store_Placees>();
                cmdOpIn = new ClsCommander<T_OPeration_IN>();
                cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

                GetDonars_Data();
                GetEmp_Data();
                GetMed_Data();
                GetStoragePlace_Data();
                is_op_insert = 0;
                old_med_Quntitey = 0;
                old_med_id = 0;
                Get_OP_Med_count_Data();

                Set_Auto_Id_item();
                Set_Auto_Id_op();

                //   med_countTextEdit1.Text = "0";
                if (id_toUpdate != 0)
                {
                    TF_OP_IN = new T_OPeration_IN();
                    TF_OP_IN = cmdOpIn.Get_By(i => i.in_op_id == id_toUpdate).FirstOrDefault();

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
            C_Master.print_header("- تفاصيل فاتورة الادخال رقم -"
                      + in_op_idTextEdit.Text + " - تاريخ -" + in_op_dateDateEdit.Text
                      + "-المتبرع-" + donar_idSearchLookUpEdit.Text, gc);
        }
        public override void Insert_Data()
        {
            try
            {
                if (id_toUpdate == 0)
                {
                    if (is_op_insert == 0 && Validate_Data_op())
                        insert_op();

                    if (Validate_Data_item())
                        insert_item();
                }
                else
                {
                    update_op();
                    //base.Update_Data();
                    //Get_Data("u");
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

        //*****************عملية الادخال*********************
        public bool Validate_Data_op()
        {
            int number_of_errores = 0;
            number_of_errores += in_op_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += donar_empTextEdit.is_text_valid() ? 0 : 1;

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
            TF_OP_IN.in_op_time = (TimeSpan?)in_op_timeTimeSpanEdit.EditValue;
            TF_OP_IN.in_op_text = in_op_textTextEdit.Text;
            TF_OP_IN.in_op_state = Convert.ToBoolean(in_op_stateCheckEdit.CheckState);
            TF_OP_IN.med_count = Convert.ToInt32(med_countTextEdit1.Text);
            TF_OP_IN.donar_emp = donar_empTextEdit.Text;
            TF_OP_IN.donar_id = Convert.ToInt32(donar_idSearchLookUpEdit.EditValue);
            TF_OP_IN.emp_id = Convert.ToInt32(emp_idSearchLookUpEdit.EditValue);
            TF_OP_IN.op_type_id = Convert.ToInt32("1");

        }
        public void Fill_Controls_op()
        {
            in_op_idTextEdit.Text = TF_OP_IN.in_op_id.ToString();
            in_op_dateDateEdit.DateTime = Convert.ToDateTime(TF_OP_IN.in_op_date);
            in_op_timeTimeSpanEdit.EditValue = TF_OP_IN.in_op_time;
            in_op_textTextEdit.Text = TF_OP_IN.in_op_text;
            in_op_stateCheckEdit.Checked = Convert.ToBoolean(TF_OP_IN.in_op_state);
            donar_empTextEdit.Text = TF_OP_IN.donar_emp;
            donar_idSearchLookUpEdit.EditValue = TF_OP_IN.donar_id;
            emp_idSearchLookUpEdit.EditValue = TF_OP_IN.emp_id;
            med_countTextEdit1.Text = TF_OP_IN.med_count.ToString();
        }
        public void insert_op()
        {
            var check = cmdOpIn.Get_All().Where(x => x.in_op_id == Convert.ToInt32(in_op_idTextEdit.Text)).FirstOrDefault();
            if (check == null)
            {
                is_op_insert = 1;
                TF_OP_IN = new T_OPeration_IN();
                Fill_Entitey_op();
                cmdOpIn.Insert_Data(TF_OP_IN);
                //base.Insert_Data();
                //Get_Data("i");
            }
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
            var max_id = cmdOpIn.Get_All().Where(c_id => c_id.in_op_id ==
                         cmdOpIn.Get_All().Max(max => max.in_op_id)).FirstOrDefault();
            in_op_idTextEdit.Text = max_id == null ? "1" : (max_id.in_op_id + 1).ToString();
        }

        //*****************مواد الفاتورة*********************
        public bool Validate_Data_item()
        {
            int number_of_errores = 0;
            number_of_errores += in_item_idTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += in_item_quntityTextEdit.is_text_valid() ? 0 : 1;

            if (Med_idSearchlookupEdit.EditValue == null)
            {
                number_of_errores += 1;
                Med_idSearchlookupEdit.ErrorText = "هذا الحقل مطلوب";
            }
            if (med_storage_place_idSearchLookUpEdit.EditValue == null)
            {
                number_of_errores += 1;
                med_storage_place_idSearchLookUpEdit.ErrorText = "هذا الحقل مطلوب";
            }

            return (number_of_errores == 0);
        }
        public void Fill_Entitey_item()
        {
            TF_OP_IN_Item.in_item_quntity = Convert.ToInt32(in_item_quntityTextEdit.Text);
            TF_OP_IN_Item.in_item_expDate = Convert.ToDateTime(in_item_expDateDateEdit.DateTime.ToString("yyyy/MM/dd"));
            TF_OP_IN_Item.in_B_It_note = in_B_It_noteMemoEdit.Text;
            TF_OP_IN_Item.Med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_OP_IN_Item.store_place_id = Convert.ToInt32(med_storage_place_idSearchLookUpEdit.EditValue);
            TF_OP_IN_Item.In_op_id = TF_OP_IN.in_op_id;
            TF_OP_IN_Item.is_out = false;
            TF_OP_IN_Item.out_item_quntitey = 0;
        }
        public void insert_item()
        {
            TF_OP_IN_Item = new T_OPeration_IN_Item();
            Fill_Entitey_item();
            cmdOpInItem.Insert_Data(TF_OP_IN_Item);

            //base.Insert_Data();
            //Get_Data("i");
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
                        //base.Update_Data();
                        //Get_Data("u");
                        
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
                                cmdOpInItem.Delet_Data(TF_OP_IN_Item);
                            }
                        //base.Delete_Data();
                        //Get_Data("d");
     

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
            var max_id = cmdOpInItem.Get_All().Where(c_id => c_id.in_item_id ==
                         cmdOpInItem.Get_All().Max(max => max.in_item_id)).FirstOrDefault();
            in_item_idTextEdit.Text = max_id == null ? "1" : (max_id.in_item_id + 1).ToString();
        }
        private void Fill_Graid_item()
        {
            int id = Convert.ToInt32(in_op_idTextEdit.Text);

            DataTable data_source = c_db.select(@"SELECT        dbo.T_OPeration_IN_Item.in_item_id,
                                                        dbo.T_Medician.med_id,
                                                    dbo.T_Medician.med_code,
                                                   dbo.T_Medician.med_name,
                                                    dbo.T_OPeration_IN_Item.in_item_quntity, 
                         dbo.T_OPeration_IN_Item.in_item_expDate,
                       dbo.T_Store_Placees.id, 
                         dbo.T_Store_Placees.name, 
                           dbo.T_OPeration_IN_Item.In_op_id
FROM            dbo.T_OPeration_IN_Item INNER JOIN
                         dbo.T_Store_Placees ON dbo.T_OPeration_IN_Item.store_place_id = dbo.T_Store_Placees.id INNER JOIN
                         dbo.T_Medician ON dbo.T_OPeration_IN_Item.Med_id = dbo.T_Medician.med_id
WHERE        (dbo.T_OPeration_IN_Item.In_op_id = " + id + ")");
            if (data_source != null && data_source.Rows.Count > 0)
            {
                gc.DataSource = data_source;

                gv.Columns[0].Visible = false;
                gv.Columns[1].Visible = false;
                gv.Columns[2].Caption = "كود الدواء";
                gv.Columns[3].Caption = "اسم الدواء";

                gv.Columns[4].Caption = "الكمية";

                gv.Columns[5].Caption = "تاريخ الانتهاء ";
                gv.Columns[6].Visible = false;
                gv.Columns[7].Caption = " موقع التخزين ";
                gv.Columns[8].Visible = false;
                gv.BestFitColumns();
            }
        }
        private void clear_item()
        {
            med_storage_place_idSearchLookUpEdit.EditValue = null;
            in_item_quntityTextEdit.Text = string.Empty;
            Med_idSearchlookupEdit.EditValue = null;

            Set_Auto_Id_item();
        }
        private void Fill_Controls_Item()
        {
            in_item_idTextEdit.Text = TF_OP_IN_Item.in_item_id.ToString();
            in_item_quntityTextEdit.Text = TF_OP_IN_Item.in_item_quntity.ToString();
            in_item_expDateDateEdit.DateTime = Convert.ToDateTime(TF_OP_IN_Item.in_item_expDate);
            in_B_It_noteMemoEdit.Text = TF_OP_IN_Item.in_B_It_note;
            Med_idSearchlookupEdit.EditValue = TF_OP_IN_Item.Med_id;
            med_storage_place_idSearchLookUpEdit.EditValue = TF_OP_IN_Item.store_place_id;
            in_op_idTextEdit.Text = TF_OP_IN_Item.In_op_id.ToString();

        }

        //********************* توابع جرد الدواء ****************************
        private void Get_Add_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_in_count = TF_Medician.med_in_count + Convert.ToInt32(in_item_quntityTextEdit.Text);
            TF_Medician.med_total_now = TF_Medician.med_total_now + Convert.ToInt32(in_item_quntityTextEdit.Text);
            cmdMedician.Update_Data(TF_Medician);
        }
        private void Get_Delete_med_count()
        {
            TF_Medician = new T_Medician();
         
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == old_med_id).FirstOrDefault();
            TF_Medician.med_in_count = TF_Medician.med_in_count - Convert.ToInt32(in_item_quntityTextEdit.Text);
            TF_Medician.med_total_now = TF_Medician.med_total_now - Convert.ToInt32(in_item_quntityTextEdit.Text);
            cmdMedician.Update_Data(TF_Medician);
            old_med_id = 0;
        }
        private void Get_Update_med_count()
        {
            TF_Medician = new T_Medician();
            int id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
            TF_Medician = cmdMedician.Get_All().Where(l => l.med_id == id).FirstOrDefault();
            TF_Medician.med_in_count = TF_Medician.med_in_count -old_med_Quntitey+ Convert.ToInt32(in_item_quntityTextEdit.Text);
            TF_Medician.med_total_now = TF_Medician.med_total_now -old_med_Quntitey + Convert.ToInt32(in_item_quntityTextEdit.Text);
            cmdMedician.Update_Data(TF_Medician);
            old_med_Quntitey = 0;
        }


        //*******************تعبة الداتا***********************

        public void GetStoragePlace_Data()
        {
            var place_list = (from Emp in cmdStorageplace.Get_All()
                              select new
                              {
                                  id = Emp.id,
                                  name = Emp.name,
                                  groupp = Emp.groupe,
                                  shufel = Emp.shufel
                              }).OrderBy(id => id.id);
            if (place_list != null && place_list.Count() > 0)
            {
                med_storage_place_idSearchLookUpEdit.slkp_iniatalize_data(place_list, "name", "id");
                med_storage_place_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                med_storage_place_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
                med_storage_place_idSearchLookUpEdit.Properties.View.Columns[2].Caption = "مجموعة الرفوف ";
                med_storage_place_idSearchLookUpEdit.Properties.View.Columns[3].Caption = "رقم الرف ";

            }
        }
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
                //     emp_idSearchLookUpEdit.Properties.DataSource = emp_list;
                emp_idSearchLookUpEdit.slkp_iniatalize_data(emp_list, "name", "id");
                emp_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                emp_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }
        }
        public void GetDonars_Data()
        {
            var Donar_list = (from Emp in cmdDonars.Get_All()
                              select new
                              {
                                  id = Emp.Donar_id,
                                  name = Emp.Donar_name
                              }).OrderBy(id => id.id);
            if (Donar_list != null && Donar_list.Count() > 0)
            {
                //     emp_idSearchLookUpEdit.Properties.DataSource = emp_list;
                donar_idSearchLookUpEdit.slkp_iniatalize_data(Donar_list, "name", "id");
                donar_idSearchLookUpEdit.Properties.View.Columns[0].Caption = "الرقم";
                donar_idSearchLookUpEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }

        }
        public void GetMed_Data()
        {

            var med_list = (from Emp in cmdMedician.Get_All()
                            select new
                            {
                                id = Emp.med_id,
                                name = Emp.med_name
                            }).OrderBy(id => id.id);
            if (med_list != null && med_list.Count() > 0)
            {
                Med_idSearchlookupEdit.slkp_iniatalize_data(med_list, "name", "id");
                Med_idSearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit.Properties.View.Columns[1].Caption = "الاسم ";
            }

        }

        public void Get_OP_Med_count_Data()
        {
            int op_id = Convert.ToInt32(in_op_idTextEdit.Text);
            var count = cmdOpInItem.Get_All().Where(x => x.In_op_id == op_id).Count().ToString();
            med_countTextEdit1.Text = count;

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
       
            F_Store_Places f = new F_Store_Places();
            f.ShowDialog();
            GetStoragePlace_Data();
        }



        //*******************اظهار الداتا في الكومبو**************
        private void Med_idSearchlookupEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdMedician.Get_By(id => id.med_id == e_id).FirstOrDefault().med_name;
            }
            else
                e.DisplayText = "";
        }
        private void med_storage_place_idSearchLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdStorageplace.Get_By(id => id.id == e_id).FirstOrDefault().name;
            }
            else
                e.DisplayText = "";
        }
        private void donar_idSearchLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdDonars.Get_By(id => id.Donar_id == e_id).FirstOrDefault().Donar_name;
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
            if (TF_OP_IN_Item != null)
            {
                Fill_Controls_Item();
                old_med_Quntitey = Convert.ToInt32(in_item_quntityTextEdit.Text);
                old_med_id = Convert.ToInt32(Med_idSearchlookupEdit.EditValue);
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
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]));
                TF_OP_IN_Item = cmdOpInItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]));
                TF_OP_IN_Item = cmdOpInItem.Get_By(c_id => c_id.in_item_id == id).FirstOrDefault();
            }
        }


        //******************أزرار الاضافة و الحذف و التعديل*********************
        private void btn_add_item_Click(object sender, EventArgs e)
        {
            if (Validate_Data_op())
            {
                Insert_Data();
                Fill_Graid_item();
                Get_Add_med_count();
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
            update_op();
            btn_visible(false);
            clear_item();
            Fill_Graid_item();
        }
    }
}
