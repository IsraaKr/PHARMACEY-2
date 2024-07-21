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
    public partial class F_damege_rep : F_Master_Inheretanz
    {
        public F_damege_rep()
        {
            InitializeComponent();
            view_inheretanz_butomes(false, false, false, false, false,  true, false);

            load_gc(sqll + group + having);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "تقرير الإتلاف";

        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_OPeration_Damage> cmdOpDam = new ClsCommander<T_OPeration_Damage>();
        ClsCommander<T_Operation_Damage_Item> cmdOpDamItem = new ClsCommander<T_Operation_Damage_Item>();
        ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();


        DataTable dt;

        string sqll = @" SELECT     T_OPeration_Damage.dam_OP_id, T_OPeration_Damage.dam_op_date, T_OPeration_Damage.dam_op_time, T_OPeration_Damage.dam_op_text, 
                      T_Operation_Damage_Item.Med_id, T_Medician.med_code, T_Medician.med_name, T_Med_Shape.med_shape_name, T_Operation_Damage_Item.dmg_item_quntity, 
                      T_Pers_Emploee.Emp_name, T_OPeration_IN_Item.in_item_expDate, T_Store_Placees.name
FROM         T_OPeration_Damage INNER JOIN
                      T_Operation_Damage_Item ON T_OPeration_Damage.dam_OP_id = T_Operation_Damage_Item.dmg_op_id INNER JOIN
                      T_Pers_Emploee ON T_OPeration_Damage.emp_id = T_Pers_Emploee.Emp_id INNER JOIN
                      T_Medician ON T_Operation_Damage_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_OPeration_IN_Item ON T_Operation_Damage_Item.in_item_id = T_OPeration_IN_Item.in_item_id AND 
                      T_Medician.med_id = T_OPeration_IN_Item.Med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id LEFT OUTER JOIN
                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id ";
        private void gv_column_names()
        {
            gv.Columns[0].Caption = "الرقم";
            gv.Columns[1].Caption = "التاريخ";
            gv.Columns[2].Caption = "الوقت";
            gv.Columns[3].Caption = "السبب";
            gv.Columns[4].Visible = false;
            gv.Columns[5].Caption = "الكود";
            gv.Columns[6].Caption = "الاسم";
            gv.Columns[7].Caption = "الشكل";
            gv.Columns[8].Caption = "الكمية";
            gv.Columns[9].Caption = "الموظف";
            gv.Columns[10].Caption = "انتهاء الصلاحية";
            gv.Columns[11].Caption = "مكان التخزين";
            gv.BestFitColumns();

            gv.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[8].DisplayFormat.FormatString = "N0";

            gv.Columns[10].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gv.Columns[10].DisplayFormat.FormatString = "MM/yyyy";
            if (gv.Columns[8].Summary.Count == 0)
            {
                gv.OptionsView.ShowFooter = true;
                gv.Columns[8].Summary.Add(DevExpress.Data.SummaryItemType.Sum, gv.Columns[8].FieldName.ToString(), "المجموع = {0}");
                gv.Columns[6].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[6].FieldName.ToString(), "عدد المواد = {0}");
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
        public override void Print_Data()
        {
            base.Print_Data();
            C_Master.print_header(tit, gc);
        }

        public void GetMed_Data()
        {

            var med_list = (from Emp in cmdMedician.Get_All()
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
                Med_idSearchlookupEdit1.slkp_iniatalize_data(med_list, "name", "id");
                Med_idSearchlookupEdit1.Properties.View.Columns[0].Caption = "الرقم";
                Med_idSearchlookupEdit1.Properties.View.Columns[1].Caption = "الاسم ";
                Med_idSearchlookupEdit1.Properties.View.Columns[2].Caption = "الشكل ";


            }

        }
        public void GetIn_op_Data()
        {
            var med_list = (from Emp in cmdOpDam.Get_All()
                            select new
                            {
                                id = Emp.dam_OP_id,
                                date = Emp.dam_op_date,
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
        public override void Get_Data(string status_mess)
        {
            GetEmp_Data();
            GetMed_Data();
            GetIn_op_Data();
            GetStoragePlace_Data();

            base.Get_Data("");
        }
        private void load_gc(string query)
        {
            gc.DataSource = null;
            gv.Columns.Clear();
            dt = c_db.select(query);
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
            emp_SearchlookupEdit21.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;
            store_place_SearchlookupEdit2.EditValue = null;
            store_place_SearchlookupEdit2.Text = string.Empty;

            exp_date.Text = string.Empty;

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
                s = s + " T_OPeration_Damage.dam_OP_id  =" + Convert.ToInt32(in_op_SearchlookupEdit.EditValue) + "    AND";

            if (Med_idSearchlookupEdit1.Text != string.Empty)
                s = s + "   T_Operation_Damage_Item.Med_id  =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + "    AND";

            if (emp_SearchlookupEdit21.Text != string.Empty)
                s = s + " T_OPeration_Damage.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + "   AND";

            if (store_place_SearchlookupEdit2.Text != string.Empty)
                s = s + "   T_OPeration_IN_Item.store_place_id =" + Convert.ToInt32(store_place_SearchlookupEdit2.EditValue) + "   AND ";

            if (exp_date.Text != string.Empty)
                s = s + " ( month (T_OPeration_IN_Item.in_item_expDate) = " + exp_date.DateTime.Month + " " +
                   " and  year (T_OPeration_IN_Item.in_item_expDate) = " + exp_date.DateTime.Year + "  ) " + "    AND ";

            if (chb_from_to.Checked == true &&
                from_dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + "  (  T_OPeration_Damage.dam_op_date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + "   AND ";

            if (in_op_dateDateEdit.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + " ( month (  T_OPeration_Damage.dam_op_date) = " + in_op_dateDateEdit.Value.Month + " " +
                " and  year (  T_OPeration_Damage.dam_op_date) = " + in_op_dateDateEdit.Value.Year + " " +
                 " and DAY(  T_OPeration_Damage.dam_op_date)=  " + in_op_dateDateEdit.Value.Day + " ) " + "    AND ";

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
                e.DisplayText = cmdOpDam.Get_By(id => id.dam_OP_id == e_id).FirstOrDefault().dam_OP_id.ToString();
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



        private void in_op_dateDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " WHERE(month (  T_OPeration_Damage.dam_op_date) = N'" + in_op_dateDateEdit.Value.Month + "' " +
         " and  year (  T_OPeration_Damage.dam_op_date) = N'" + in_op_dateDateEdit.Value.Year + "' ) " + group + having;


            load_gc(s);

            Med_idSearchlookupEdit1.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;
            in_op_SearchlookupEdit.Text = string.Empty;

        }

        private void exp_date_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdOpInItem.Get_By(id => id.in_item_id == e_id).FirstOrDefault().in_item_expDate.ToString();
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
    }
}