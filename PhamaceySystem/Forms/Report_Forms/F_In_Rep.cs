using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Report_Forms
{
    public partial class F_In_Rep :F_Master_Inheretanz
    {
        public F_In_Rep()
        {
            InitializeComponent();
            view_inheretanz_butomes(false, false, false, false, false, true, false);

            load_gc(sqll + group + having);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "تقرير الإدخال";

        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_IN> cmdOpIn = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();


        DataTable dt;

        string sqll = @"  SELECT     T_OPeration_IN.in_op_id,
T_OPeration_IN.in_op_date,
T_OPeration_IN.in_op_time,
T_OPeration_IN.in_op_text,
T_OPeration_IN.med_count, 
                      T_OPeration_IN_Item.in_item_id,
T_Medician.med_code,
T_Medician.med_name, 
T_OPeration_IN_Item.in_item_quntity,
T_OPeration_IN_Item.in_item_expDate,
T_OPeration_IN_Item.is_out, 
                      T_OPeration_IN_Item.out_item_quntitey, 
T_Pers_Donars.Donar_name, 
T_Pers_Emploee.Emp_name, 
                      T_Store_Placees.name AS place_name
FROM         T_OPeration_IN INNER JOIN
                      T_Pers_Emploee ON T_OPeration_IN.emp_id = T_Pers_Emploee.Emp_id INNER JOIN
                      T_Pers_Donars ON T_OPeration_IN.donar_id = T_Pers_Donars.Donar_id INNER JOIN
                      T_OPeration_IN_Item ON T_OPeration_IN.in_op_id = T_OPeration_IN_Item.In_op_id INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id  ";
        private void gv_column_names()
        {
            gv.Columns[0].Caption = "الرقم";
            gv.Columns[1].Caption = "التاريخ";
            gv.Columns[2].Caption = "الوقت";
            gv.Columns[3].Visible = false;
            gv.Columns[4].Visible = false;
            gv.Columns[5].Visible=false;
            gv.Columns[6].Caption = "الكود";
            gv.Columns[7].Caption = "الاسم";
            gv.Columns[8].Caption="الكمية";
            gv.Columns[9].Caption = "انتهاءالصلاحية";
            gv.Columns[10].Caption = "خارجة";
            gv.Columns[11].Visible = false;
            gv.Columns[12].Caption = "المتبرع";
            gv.Columns[13].Caption = "الموظف";
            gv.Columns[14].Caption = "التخزين";
            gv.BestFitColumns();

            gv.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[8].DisplayFormat.FormatString = "N0";

            gv.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gv.Columns[9].DisplayFormat.FormatString = "MM/yyyy";

            if (gv.Columns[8].Summary.Count == 0)
            {
                gv.OptionsView.ShowFooter = true;
                gv.Columns[8].Summary.Add(DevExpress.Data.SummaryItemType.Sum, gv.Columns[8].FieldName.ToString(), "المجموع = {0}");
                gv.Columns[7].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[7].FieldName.ToString(), "عدد المواد = {0}");
            }

            if (gv.GroupSummary.Count == 0)
            {
                DevExpress.XtraGrid.GridGroupSummaryItem item = new DevExpress.XtraGrid.GridGroupSummaryItem();
                item.DisplayFormat = "_____مجموع الكميات= {0}";
                item.FieldName = gv.Columns[8].FieldName.ToString();
                item.ShowInGroupColumnFooter = gv.Columns["show in group row"];
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gv.GroupSummary.Add(item);
            }
        }

        string group = @"  ";

        string having = @" ";

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
                store_place_SearchlookupEdit2.slkp_iniatalize_data(place_list, "name", "id");
                store_place_SearchlookupEdit2.Properties.View.Columns[0].Caption = "الرقم";
                store_place_SearchlookupEdit2.Properties.View.Columns[1].Caption = "الاسم ";
                store_place_SearchlookupEdit2.Properties.View.Columns[2].Caption = "مجموعة الرفوف ";
                store_place_SearchlookupEdit2.Properties.View.Columns[3].Caption = "رقم الرف ";

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
                emp_SearchlookupEdit21.slkp_iniatalize_data(emp_list, "name", "id");
                emp_SearchlookupEdit21.Properties.View.Columns[0].Caption = "الرقم";
                emp_SearchlookupEdit21.Properties.View.Columns[1].Caption = "الاسم ";
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
                donar_searchLookUpEdit12.slkp_iniatalize_data(Donar_list, "name", "id");
                donar_searchLookUpEdit12.Properties.View.Columns[0].Caption = "الرقم";
                donar_searchLookUpEdit12.Properties.View.Columns[1].Caption = "الاسم ";
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
                Med_idSearchlookupEdit1.slkp_iniatalize_data(med_list, "name", "id");
                Med_idSearchlookupEdit1.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit1.Properties.View.Columns[1].Caption = "الاسم ";
            }

        }
        public void GetIn_op_Data()
        {
            var med_list = (from Emp in cmdOpIn.Get_All()
                            select new
                            {
                                id = Emp.in_op_id,
                                date = Emp.in_op_date,
                                count = Emp.med_count

                            }).OrderBy(id => id.id);
            if (med_list != null && med_list.Count() > 0)
            {
                in_op_SearchlookupEdit.slkp_iniatalize_data(med_list, "id", "id");
                in_op_SearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                in_op_SearchlookupEdit.Properties.View.Columns[1].Caption = "التاريخ ";
                in_op_SearchlookupEdit.Properties.View.Columns[2].Caption = "عدد المواد ";
            }

        }
        public override void Print_Data()
        {
            base.Print_Data();
            C_Master.print_header(tit, gc);
        }

        public override void Get_Data(string status_mess)
        {
            GetDonars_Data();
            GetEmp_Data();
            GetMed_Data();
            GetStoragePlace_Data();
            GetIn_op_Data();


            base.Get_Data("");
        }
        private void load_gc(string query)
        {
            gc.DataSource = null;
            gv.Columns.Clear();
            dt = C_DB.Select(query);
            gc.DataSource = dt;
            gv_column_names();
            gv.ExpandAllGroups();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            clear_all();
            load_gc(sqll + group + having);
        }

        private void clear_all()
        {
            clear_data(this.Controls);
            chb_from_to.Checked = false;
            Med_idSearchlookupEdit1.EditValue = null;
            donar_searchLookUpEdit12.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            store_place_SearchlookupEdit2.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            is_out_SearchlookupEdit1.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            donar_searchLookUpEdit12.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;
            store_place_SearchlookupEdit2.Text = string.Empty;
            //  in_op_SearchlookupEdit.Text = string.Empty;
            is_out_SearchlookupEdit1.Text = string.Empty;
           
            exp_date.Text =string.Empty;

            from_dateTimePicker1.Text = DateTime.Today.ToShortDateString();
            to_dateTimePicker2.Text = DateTime.Today.ToShortDateString(); 
        }

        private void chb_from_to_CheckedChanged(object sender, EventArgs e)
        {
          //  clear_data(this.Controls);
            if (chb_from_to.Checked)
            {
                from_dateTimePicker1.Enabled = true;
                to_dateTimePicker2.Enabled = true;
            }
            else if (chb_from_to.Checked == false)
            {
                from_dateTimePicker1.Enabled = false;
                to_dateTimePicker2.Enabled = false;
            }
        }       

        private void btn_view_serch_Click(object sender, EventArgs e)
        {
            string s = sqll + " where ";

            if (in_op_SearchlookupEdit.Text != string.Empty)
                s = s + " T_OPeration_IN.in_op_id  =" + Convert.ToInt32(in_op_SearchlookupEdit.EditValue) + "    AND";

            if (Med_idSearchlookupEdit1.Text != string.Empty)
                s = s + "  T_OPeration_IN_Item.Med_id  =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + "    AND";

            if (store_place_SearchlookupEdit2.Text != string.Empty)
                s = s + "   T_OPeration_IN_Item.store_place_id =" + Convert.ToInt32(store_place_SearchlookupEdit2.EditValue) + "   AND ";

            if (emp_SearchlookupEdit21.Text != string.Empty)
                s = s + " T_OPeration_IN.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + "   AND";

            if (is_out_SearchlookupEdit1.Text != string.Empty)
                {
                if (is_out_SearchlookupEdit1.Text == "out")
                    s = s + "  T_OPeration_IN_Item.is_out = 'true' " + "    AND";

                else if (is_out_SearchlookupEdit1.Text == "in")
                    s = s + "  T_OPeration_IN_Item.is_out = 'false' " + "    AND";
            }
            if (donar_searchLookUpEdit12.Text != string.Empty)
                s = s + "T_OPeration_IN.donar_id =" + Convert.ToInt32(donar_searchLookUpEdit12.EditValue) + "    AND ";

            if (exp_date.Text != string.Empty)
                s = s + " ( month (T_OPeration_IN_Item.in_item_expDate) = " + exp_date.DateTime.Month + " " +
                   " and  year (T_OPeration_IN_Item.in_item_expDate) = " + exp_date.DateTime.Year + "  ) " + "    AND ";

            if (chb_from_to.Checked == true &&
                from_dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + "  (T_OPeration_IN_Item.in_item_expDate between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + "   AND ";

            if (in_op_dateDateEdit.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + " ( month (T_OPeration_IN.in_op_date) = " + in_op_dateDateEdit.Value.Month + " " +
                " and  year (T_OPeration_IN.in_op_date) = " + in_op_dateDateEdit.Value.Year + " "+
                 " and DAY(T_OPeration_IN.in_op_date)=  " + in_op_dateDateEdit.Value.Day + " ) " + "    AND ";
         
            s = s.Substring(0, s.Length - 6);
            s = s + group + having;
            load_gc(s);
            clear_all();
        }


        private void in_op_SearchlookupEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdOpIn.Get_By(id => id.in_op_id == e_id).FirstOrDefault().in_op_id.ToString();
            }
            else
                e.DisplayText = "";
        }

        private void Med_idSearchlookupEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdMedician.Get_By(id => id.med_id == e_id).FirstOrDefault().med_name;
            }
            else
                e.DisplayText = "";
        }

        private void store_place_SearchlookupEdit2_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdStorageplace.Get_By(id => id.id == e_id).FirstOrDefault().name;
            }
            else
                e.DisplayText = "";
        }

        private void exp_date_searchLookUpEdit121_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdOpInItem.Get_By(id => id.in_item_id == e_id).FirstOrDefault().in_item_expDate.ToString();
            }
            else
                e.DisplayText = "";
        }
        private void emp_SearchlookupEdit21_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdEmp.Get_By(id => id.Emp_id == e_id).FirstOrDefault().Emp_name;
            }
            else
                e.DisplayText = "";
        }

        private void donar_searchLookUpEdit12_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdDonars.Get_By(id => id.Donar_id == e_id).FirstOrDefault().Donar_name;
            }
            else
                e.DisplayText = "";
        }
       
        private void in_op_dateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " WHERE(month (T_OPeration_IN.in_op_date) = N'" + in_op_dateDateEdit.Value.Month + "' " +
         " and  year (T_OPeration_IN.in_op_date) = N'" + in_op_dateDateEdit.Value.Year + "' ) " + group + having;


            load_gc(s);

            Med_idSearchlookupEdit1.EditValue = null;
            donar_searchLookUpEdit12.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            store_place_SearchlookupEdit2.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            is_out_SearchlookupEdit1.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            donar_searchLookUpEdit12.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;
            store_place_SearchlookupEdit2.Text = string.Empty;
            in_op_SearchlookupEdit.Text = string.Empty;
            is_out_SearchlookupEdit1.Text = string.Empty;
            ////de_month.Text = DateTime.Today.ToShortDateString(); ;
            //////de_month.EditValue = null;
            ////dtp_from.Text = null;
            ////dtp_to.Text = null;
        }

    }
 } 

