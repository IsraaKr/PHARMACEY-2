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
    public partial class F_out_rep :F_Master_Inheretanz
    {
        public F_out_rep()
        {
            InitializeComponent();
            view_inheretanz_butomes(false, false, false, false, false, true, false);
            load_gc(sqll + group + having);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "تقرير الإخراج";

        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();
        ClsCommander<T_Pers_Emploee> cmdEmp = new ClsCommander<T_Pers_Emploee>();
        ClsCommander<T_OPeration_Out> cmdOpOut = new ClsCommander<T_OPeration_Out>();
        ClsCommander<T_OPeration_Out_Item> cmdOpOutItem = new ClsCommander<T_OPeration_Out_Item>();
        ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();

        ClsCommander<T_Pers_Recivers> cmdReciver = new ClsCommander<T_Pers_Recivers>();

        DataTable dt;

        string sqll = @"  SELECT     T_OPeration_Out.out_op_id,
T_OPeration_Out.out_op_date,
T_OPeration_Out.out_op_time, 
T_OPeration_Out.out_op_text,
  T_OPeration_Out_Item.Med_id,
T_Medician.med_code, 
T_Medician.med_name, 
     T_Med_Shape.med_shape_name,

T_OPeration_Out_Item.out_item_quntity,
T_Pers_Emploee.Emp_name,
T_Pers_Recivers.name
FROM         T_OPeration_Out INNER JOIN
                      T_OPeration_Out_Item ON T_OPeration_Out.out_op_id = T_OPeration_Out_Item.out_op_id INNER JOIN
                      T_Pers_Emploee ON T_OPeration_Out.emp_id = T_Pers_Emploee.Emp_id INNER JOIN
                      T_Pers_Recivers ON T_OPeration_Out.reciver_id = T_Pers_Recivers.id INNER JOIN
                      T_Medician ON T_OPeration_Out_Item.Med_id = T_Medician.med_id left JOIN
                      T_Med_Shape ON T_Medician.med_shape_id = T_Med_Shape.med_shape_id  ";
        private void gv_column_names()
        {
            gv.Columns[0].Caption = "الرقم";
            gv.Columns[1].Caption = "التاريخ";
            gv.Columns[2].Caption = "الوقت";
            gv.Columns[3].Visible = false;
            gv.Columns[4].Visible = false;
            gv.Columns[5].Caption = "الكود";
            gv.Columns[6].Caption = "الاسم";
            gv.Columns[7].Caption = "الشكل";
            gv.Columns[8].Caption = "الكمية";
            gv.Columns[10].Caption = "المستلم";
            gv.Columns[9].Caption = "الموظف";
 
            gv.BestFitColumns();
        }

        string group = @"  ";

        string having = @" ";

        string where = "  ";
      
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
                                shape =sss.med_shape_name
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
            var med_list = (from Emp in cmdOpOut.Get_All()
                            select new
                            {
                                id = Emp.out_op_id,
                                date = Emp.out_op_date,
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

        public override void Get_Data(string status_mess)
        {
            GetReciver_Data();
            GetEmp_Data();
            GetMed_Data();
            GetIn_op_Data();


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
            reciver_searchLookUpEdit12.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            reciver_searchLookUpEdit12.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;


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
                s = s + "  T_OPeration_Out.out_op_id  =" + Convert.ToInt32(in_op_SearchlookupEdit.EditValue) + "    AND";

            if (Med_idSearchlookupEdit1.Text != string.Empty)
                s = s + "   T_OPeration_Out_Item.Med_id  =" + Convert.ToInt32(Med_idSearchlookupEdit1.EditValue) + "    AND";

            if (emp_SearchlookupEdit21.Text != string.Empty)
                s = s + " T_OPeration_Out.emp_id =" + Convert.ToInt32(emp_SearchlookupEdit21.EditValue) + "   AND";

          
            if (reciver_searchLookUpEdit12.Text != string.Empty)
                s = s + " T_OPeration_Out.reciver_id  =" + Convert.ToInt32(reciver_searchLookUpEdit12.EditValue) + "    AND ";


            if (chb_from_to.Checked == true &&
                from_dateTimePicker1.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + "  ( T_OPeration_Out.out_op_date between N'" + from_dateTimePicker1.Text + "' and N'" + to_dateTimePicker2.Text + "')" + "   AND ";

            if (in_op_dateDateEdit.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                s = s + " ( month ( T_OPeration_Out.out_op_date) = " + in_op_dateDateEdit.Value.Month + " " +
                " and  year ( T_OPeration_Out.out_op_date) = " + in_op_dateDateEdit.Value.Year + " " +
                 " and DAY( T_OPeration_Out.out_op_date)=  " + in_op_dateDateEdit.Value.Day + " ) " + "    AND ";

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
                e.DisplayText = cmdOpOut.Get_By(id => id.out_op_id == e_id).FirstOrDefault().out_op_id.ToString();
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
            string s = sqll + " WHERE(month ( T_OPeration_Out.out_op_date) = N'" + in_op_dateDateEdit.Value.Month + "' " +
         " and  year ( T_OPeration_Out.out_op_date) = N'" + in_op_dateDateEdit.Value.Year + "' ) " + group + having;


            load_gc(s);

            Med_idSearchlookupEdit1.EditValue = null;
            reciver_searchLookUpEdit12.EditValue = null;
            emp_SearchlookupEdit21.EditValue = null;
            in_op_SearchlookupEdit.EditValue = null;
            Med_idSearchlookupEdit1.Text = string.Empty;
            reciver_searchLookUpEdit12.Text = string.Empty;
            emp_SearchlookupEdit21.Text = string.Empty;
            in_op_SearchlookupEdit.Text = string.Empty;
          
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
    }
}

