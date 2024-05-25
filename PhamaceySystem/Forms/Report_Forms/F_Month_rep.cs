using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using System;
using System.Data;
using System.Linq;

namespace PhamaceySystem.Forms.Report_Forms
{
    public partial class F_Month_rep : F_Master_Inheretanz
    {
        public F_Month_rep()
        {
            InitializeComponent();
            view_inheretanz_butomes(false, false, false, false, false, true, false);

            load_gc(sqll + group + having);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "التقرير الشهري/ حركة المستودع ";

        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_Pers_Donars> cmdDonars = new ClsCommander<T_Pers_Donars>();
        ClsCommander<T_Store_Placees> cmdStorageplace = new ClsCommander<T_Store_Placees>();
        ClsCommander<T_OPeration_IN> cmdOpIn = new ClsCommander<T_OPeration_IN>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();

        ClsCommander<T_Pers_Recivers> cmdReciver = new ClsCommander<T_Pers_Recivers>();

        DataTable dt;

        string sqll = @" SELECT    
T_Store_Move.id, 
T_Store_Move.item_id,
T_OPeration_Type.OP_type_name,
T_Store_Move.op_id,
T_Store_Move.date,
T_Store_Move.time,
T_Store_Move.med_id, 
 T_Medician.med_code,
                      T_Medician.med_name, 
T_Med_Shape.med_shape_name,
T_Store_Move.qunt,
T_Pers_Recivers.name AS reciver_name,
T_Pers_Emploee.Emp_name, 
                      T_Pers_Donars.Donar_name,
T_Store_Placees.name AS place_name

FROM         T_Store_Move left JOIN
                      T_Store_Placees ON T_Store_Move.place_id = T_Store_Placees.id left JOIN
                      T_Pers_Recivers ON T_Store_Move.reciver_id = T_Pers_Recivers.id left JOIN
                      T_Pers_Emploee ON T_Store_Move.emp_id = T_Pers_Emploee.Emp_id left JOIN
                      T_Pers_Donars ON T_Store_Move.donar_id = T_Pers_Donars.Donar_id left JOIN
                      T_OPeration_Type ON T_Store_Move.op_type_id = T_OPeration_Type.OP_type_id left JOIN
                    T_Medician  ON T_Store_Move.med_id = T_Medician.med_id   left  JOIN
                      T_Med_Shape ON   T_Medician.med_shape_id =T_Med_Shape.med_shape_id
                      ";
        private void gv_column_names()
        {
            gv.Columns[0].Visible = false;
            gv.Columns[1].Visible = false;
            gv.Columns[2].Caption = "نوع العملية";
            gv.Columns[3].Visible = false;
            gv.Columns[4].Caption = "التاريخ";
            gv.Columns[5].Caption = "الوقت";
            gv.Columns[6].Visible = false;
            gv.Columns[7].Caption = "الكود";
            gv.Columns[8].Caption = "الاسم";
            gv.Columns[9].Caption = "الشكل";
            gv.Columns[10].Caption = "الكمية";
            gv.Columns[11].Caption = "المستلم";
            gv.Columns[12].Caption = "الموظف";
            gv.Columns[13].Caption = "المتبرع";
            gv.Columns[14].Caption = "التخزين";
            gv.BestFitColumns();
        }

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
        public void GetReciver_Data()
        {
            var Donar_list = (from Emp in cmdReciver.Get_All()
                              select new
                              {
                                  id = Emp.id,
                                  name = Emp.name
                              }).OrderBy(id => id.id);
            if (Donar_list != null && Donar_list.Count() > 0)
            {
                reciver_searchLookUpEdit12.slkp_iniatalize_data(Donar_list, "name", "id");
                reciver_searchLookUpEdit12.Properties.View.Columns[0].Caption = "الرقم";
                reciver_searchLookUpEdit12.Properties.View.Columns[1].Caption = "الاسم ";
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
    

        public override void Get_Data(string status_mess)
        {
            GetDonars_Data();
            GetEmp_Data();
            GetMed_Data();
            GetStoragePlace_Data();
            GetReciver_Data();
            Month_DateDateEdit.DateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString());

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
            donar_searchLookUpEdit12.EditValue = null;
            reciver_searchLookUpEdit12.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            store_place_SearchlookupEdit2.EditValue = null;
            op_type_SearchlookupEdit1.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            donar_searchLookUpEdit12.Text = string.Empty;
            reciver_searchLookUpEdit12.Text = string.Empty;
            Month_DateDateEdit.DateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString());

            emp_SearchlookupEdit21.Text = string.Empty;
            store_place_SearchlookupEdit2.Text = string.Empty;
            op_type_SearchlookupEdit1.Text = string.Empty;


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

            if (reciver_searchLookUpEdit12.Text != string.Empty)
                s = s + "  T_Store_Move.reciver_id  =" + Convert.ToInt32(reciver_searchLookUpEdit12.EditValue) + "    AND";

            if (Med_idSearchlookupEdit1.Text != string.Empty)
                s = s + "  T_Store_Move.med_id  =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + "    AND";

            if (store_place_SearchlookupEdit2.Text != string.Empty)
                s = s + "   T_Store_Move.place_id =" + Convert.ToInt32(store_place_SearchlookupEdit2.EditValue) + "   AND ";

            if (emp_SearchlookupEdit21.Text != string.Empty)
                s = s + "  T_Store_Move.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + "   AND";

            if (op_type_SearchlookupEdit1.Text != string.Empty)
            {
                if (op_type_SearchlookupEdit1.Text == "إدخال")
                    s = s + "  T_Store_Move.op_type_id = 1 " + "    AND";
                else if (op_type_SearchlookupEdit1.Text == "إخراج")
                    s = s + " T_Store_Move.op_type_id = 2 " + "    AND";
                else if (op_type_SearchlookupEdit1.Text == "إتلاف")
                    s = s + "  T_Store_Move.op_type_id =3 " + "    AND";
            }
            if (donar_searchLookUpEdit12.Text != string.Empty)
                s = s + "   T_Store_Move.donar_id =" + Convert.ToInt32(donar_searchLookUpEdit12.EditValue) + "    AND ";

      
            if (chb_from_to.Checked == true &&
                from_dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + "  ( T_Store_Move.date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + "   AND ";

            if ( Month_DateDateEdit.DateTime.Month != DateTime.Today.Month && Month_DateDateEdit.DateTime.Year != DateTime.Today.Year)
                s = s + " ( month (T_Store_Move.date) = " + Month_DateDateEdit.DateTime.Month + " " +
                 " and  year (T_Store_Move.date) = " + Month_DateDateEdit.DateTime.Year + " ) " + "    AND ";

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

        private void reciver_searchLookUpEdit12_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != string.Empty)
            {
                long e_id = Convert.ToInt64(e.Value);
                e.DisplayText = cmdReciver.Get_By(id => id.id == e_id).FirstOrDefault().name;
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


    }
}
