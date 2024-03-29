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
            load_gc(sqll + group + having);
        }
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_IN> cmdOpIn = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();


        DataTable dt;

        string sqll = @"  SELECT     T_OPeration_IN.in_op_id, T_OPeration_IN.in_op_date, T_OPeration_IN.in_op_time, T_OPeration_IN.in_op_text, T_OPeration_IN.med_count, 
                      T_OPeration_IN_Item.in_item_id, T_OPeration_IN_Item.in_item_quntity, T_OPeration_IN_Item.in_item_expDate, T_OPeration_IN_Item.is_out, 
                      T_OPeration_IN_Item.out_item_quntitey, T_Medician.med_code, T_Medician.med_name, T_Pers_Donars.Donar_name, T_Pers_Emploee.Emp_name, 
                      T_Store_Placees.name AS place_name
FROM         T_OPeration_IN INNER JOIN
                      T_Pers_Emploee ON T_OPeration_IN.emp_id = T_Pers_Emploee.Emp_id INNER JOIN
                      T_Pers_Donars ON T_OPeration_IN.donar_id = T_Pers_Donars.Donar_id INNER JOIN
                      T_OPeration_IN_Item ON T_OPeration_IN.in_op_id = T_OPeration_IN_Item.In_op_id INNER JOIN
                      T_Medician ON T_OPeration_IN_Item.Med_id = T_Medician.med_id INNER JOIN
                      T_Store_Placees ON T_OPeration_IN_Item.store_place_id = T_Store_Placees.id  ";

        string group = @"  ";

        string having = @" ";

        string where = "  ";
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
        public void GetIn_item_Data()
        {
            var med_list = (from Emp in cmdOpInItem.Get_All()
                            select new
                            {
                                id = Emp.in_item_id,
                                med_id = Emp.Med_id,
                                med_name = Emp.T_Medician.med_name,
                                qunt = Emp.in_item_quntity,
                                is_out = Emp.is_out,
                                qun_out =Emp.out_item_quntitey

                            }).OrderBy(id => id.id);
            if (med_list != null && med_list.Count() > 0)
            {
                in_op_SearchlookupEdit.slkp_iniatalize_data(med_list, "id", "id");
                in_op_SearchlookupEdit.Properties.View.Columns[0].Caption = "الرقم";
                in_op_SearchlookupEdit.Properties.View.Columns[1].Caption = "التاريخ ";
                in_op_SearchlookupEdit.Properties.View.Columns[3].Caption = "عدد المواد ";
            }

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
            dt = c_db.select(query);
            gc.DataSource = dt;
            //gv.Columns[0].Visible = false;
            //gv.Columns[3].Visible = false;
            //gv.Columns[1].Group();
            //gv.Columns[1].Caption = " ";
            gv.ExpandAllGroups();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
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
            in_op_SearchlookupEdit.Text = string.Empty;
            is_out_SearchlookupEdit1.Text = string.Empty;
            load_gc(sqll + group + having);
            //de_month.Text = null;
            //de_month.EditValue = null;
            //dtp_from.Text = null;
            //dtp_to.Text = null;
        }

        private void chb_from_to_CheckedChanged(object sender, EventArgs e)
        {
            clear_data(this.Controls);
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


                      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string s = sqll + " WHERE(T_OPeration_IN.in_op_date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + group + having;
            load_gc(s);
        }

        private void btn_view_serch_Click(object sender, EventArgs e)
        {
            string s = sqll + " where ";

            if (Med_idSearchlookupEdit1.Text != string.Empty)
                s = s + "  T_OPeration_IN_Item.Med_id  =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + " AND ";

            if (store_place_SearchlookupEdit2.Text != string.Empty)
                s = s + "   T_OPeration_IN_Item.store_place_id =" + Convert.ToInt32(store_place_SearchlookupEdit2.EditValue) + " AND ";

            if (emp_SearchlookupEdit21.Text != string.Empty)
                s = s + " T_OPeration_IN.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + " AND ";

            if (donar_searchLookUpEdit12.Text != string.Empty)
                s = s + "T_OPeration_IN.donar_id =" + Convert.ToInt32(donar_searchLookUpEdit12.EditValue) + "  AND ";

            if (in_op_SearchlookupEdit.Text != string.Empty)
                s = s + " T_OPeration_IN.in_op_id  =" + Convert.ToInt32(in_op_SearchlookupEdit.EditValue) + "  AND ";
        
            if (is_out_SearchlookupEdit1.Text != string.Empty)
                if (is_out_SearchlookupEdit1.Text == "out")
                {
                    s = s + "  T_OPeration_IN_Item.is_out = 'true' " + "  AND ";


                }
                else if (is_out_SearchlookupEdit1.Text == "in")
                {
                    s = s+ "  where  T_OPeration_IN_Item.is_out = 'false' " + "  AND ";

                }
            s = s.Substring(0, s.Length - 4);
            s = s + group + having;
            load_gc(s);
        }

        private void in_op_SearchlookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + "  where  T_OPeration_IN.in_op_id = " + Convert.ToInt32(in_op_SearchlookupEdit.EditValue) + " " + group + having ;

            load_gc(s);
        }

        private void Med_idSearchlookupEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " where  T_OPeration_IN_Item.Med_id =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + " " + group + having;
            load_gc(s);
        }

        private void store_place_SearchlookupEdit2_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " where   T_OPeration_IN_Item.store_place_id  =" + Convert.ToInt32(store_place_SearchlookupEdit2.EditValue) + " " + group + having;

            load_gc(s);
        }

        private void emp_SearchlookupEdit21_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " where  T_OPeration_IN.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + " " + group + having;

            load_gc(s);
        }

        private void donar_searchLookUpEdit12_EditValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " where T_OPeration_IN.donar_id  =" + Convert.ToInt32(donar_searchLookUpEdit12.EditValue) + " " + group + having;

            load_gc(s);
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
            string s = sqll + " WHERE(month (T_OPeration_IN.in_op_date) = N'" + in_op_dateDateEdit.DateTime.Month + "' " +
         " and  year (T_OPeration_IN.in_op_date) = N'" + in_op_dateDateEdit.DateTime.Year + "' ) " + group + having;


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
            //de_month.Text = null;
            //de_month.EditValue = null;
            //dtp_from.Text = null;
            //dtp_to.Text = null;
        }

        private void from_dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " and (T_OPeration_IN.in_op_date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + group + having;

            load_gc(s);
        }

        private void to_dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string s = sqll + " and (T_OPeration_IN.in_op_date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + group + having;

            load_gc(s);
        }

        private void is_out_SearchlookupEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (is_out_SearchlookupEdit1.Text=="out")
            {
                string s = sqll + "  where  T_OPeration_IN_Item.is_out = 'true' " + group + having;

                load_gc(s);
            }
            else if (is_out_SearchlookupEdit1.Text == "in")
            {
                string s = sqll + "  where  T_OPeration_IN_Item.is_out = 'false' " + group + having;
                load_gc(s);
            }
          
        }

    }
 } 

