using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem
{
   public static class C_Master
    {
        public static string mas_del = "هل أنت متأكد أنك تريد الحذف";
        public static void Warning_Massege_Box(string M_Text)
        {
            MessageBox.Show(M_Text, "تنبيه !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Qustion_Massege_Box(string M_Text)
        {
            return MessageBox.Show(M_Text, "تأكيد !! ",
          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }
        //طباعة هيدر في التقرير
        public static void print_header(string header, DevExpress.XtraGrid.GridControl gc)
        {
            PrintingSystem print = new PrintingSystem();

            PrintableComponentLink link = new PrintableComponentLink(print);
            print.Links.Add(link);
            link.Component = gc;

            string _printheadear = header;
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[] { "", _printheadear, "" });
            phf.Header.Font = new System.Drawing.Font("song Ti", 14, System.Drawing.FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;

            string strfooter = DateTime.Now.ToShortDateString();
            phf.Footer.Content.Clear();
            phf.Footer.Content.AddRange(new string[] { "", strfooter, "" });
            phf.Footer.Font = new System.Drawing.Font("song Ti", 14, System.Drawing.FontStyle.Bold);
            phf.Footer.LineAlignment = BrickAlignment.Near;

            link.CreateDocument();
            print.Document.RightToLeftLayout = true;
            print.PreviewRibbonFormEx.StartPosition = FormStartPosition.CenterScreen;
            print.PreviewRibbonFormEx.Show();
        }

        #region validation
        public static bool is_text_valid(this TextEdit txt)
        {
            if (txt.Text.Trim() == string.Empty)
            {
                txt.ErrorText = " هذا الحقل مطلوب  ";
                return false;
            }
            return true;
        }
        public static bool is_editevalue_valid(this LookUpEditBase lkpb)
        {
            if (   // lkpb.EditValue is int ||
            //        lkpb.EditValue is byte ||
            //        Convert.ToInt32(lkpb.EditValue) < 0 ||
                    lkpb.Text == string.Empty ||
                    lkpb.Text == null ||
                    lkpb.Text == "")
            {
                lkpb.ErrorText = " هذا الحقل مطلوب  ";
                return false;
            }
            return true;
        }
        //public static bool is_editevalue_valid(this LookUpEditBase lkpb)
        //{
        //    if (lkpb.is_editevalue_oftype_int() == false || lkpb.is_editevalue_valid_and_not_zero()==false)
        //    {
        //        lkpb.ErrorText = " هذا الحقل مطلوب  ";
        //        return false;
        //    }
        //    return true;
        //}
        //public static bool is_editevalue_valid_and_not_zero(this LookUpEditBase lkpb)
        //{
        //    if (lkpb.is_editevalue_oftype_int() == false || Convert.ToInt32(lkpb.EditValue)==0)
        //    {
        //        lkpb.ErrorText = " هذا الحقل مطلوب  ";
        //        return false;
        //    }
        //    return true;
        //}
        //public static bool is_editevalue_oftype_int(this LookUpEditBase lkpb)
        //{
        //    return (lkpb.EditValue is int ||
        //        lkpb.EditValue is byte || 
        //        Convert.ToInt32(lkpb.EditValue) < 0 == false ||
        //        lkpb.Text ==string.Empty ||
        //        lkpb.Text==null);

        //}
        #endregion

        #region look_up_edite iniatalize_data
        //extenshes جعل التابع الذي ننشئه يظهر بعد الدوت في اسم العنصر
        //this هي من اجل الاكستنشنز
        public static void lkp_iniatalize_data(this LookUpEdit lkp, object data_source)
        {
            lkp.lkp_iniatalize_data(data_source, "name", "id");//استدعاء الميثود التي بعده
        }
        //overloade إذا بنا نغير الاسم و ال الآي دي 
        //هي الأساسية
        public static void lkp_iniatalize_data(this LookUpEdit lkp, object data_source,
            string DisplayMember, string ValueMember)
        {
            lkp.Properties.DataSource = data_source;
            lkp.Properties.DisplayMember = DisplayMember;
            lkp.Properties.ValueMember = ValueMember;
            lkp.Properties.PopulateColumns();
            // lkp.Properties.Columns[ValueMember].Visible = false;
        }

        #endregion

        #region check_box_list  iniatalize_data
        //extenshes جعل التابع الذي ننشئه يظهر بعد الدوت في اسم العنصر
        //this هي من اجل الاكستنشنز
        public static void chbl_iniatalize_data(this CheckedListBoxControl chbl, object data_source)
        {
            chbl.chbl_iniatalize_data(data_source, "name", "id");//استدعاء الميثود التي بعده
        }
        //overloade إذا بنا نغير الاسم و ال الآي دي 
        //هي الأساسية
        public static void chbl_iniatalize_data(this CheckedListBoxControl chbl, object data_source,
            string DisplayMember, string ValueMember)
        {
            chbl.DataSource = data_source;
            chbl.DisplayMember = DisplayMember;
            chbl.ValueMember = ValueMember;

        }

        #endregion

        #region check box combo box   iniatalize_data
        //extenshes جعل التابع الذي ننشئه يظهر بعد الدوت في اسم العنصر
        //this هي من اجل الاكستنشنز
        public static void chb_comb_iniatalize_data(this CheckedComboBoxEdit chb_comb, object data_source)
        {
            chb_comb.chb_comb_iniatalize_data(data_source, "name", "id");//استدعاء الميثود التي بعده
        }
        //overloade إذا بنا نغير الاسم و ال الآي دي 
        //هي الأساسية
        public static void chb_comb_iniatalize_data(this CheckedComboBoxEdit chb_comb, object data_source,
            string DisplayMember, string ValueMember)
        {
            chb_comb.Properties.DataSource = data_source;
            chb_comb.Properties.DisplayMember = DisplayMember;
            chb_comb.Properties.ValueMember = ValueMember;

        }

        #endregion

        #region list box control   iniatalize_data
        //extenshes جعل التابع الذي ننشئه يظهر بعد الدوت في اسم العنصر
        //this هي من اجل الاكستنشنز
        public static void lbc_iniatalize_data(this ListBoxControl lbc, object data_source)
        {
            lbc.lbc_iniatalize_data(data_source, "name", "id");//استدعاء الميثود التي بعده
        }
        //overloade إذا بنا نغير الاسم و ال الآي دي 
        //هي الأساسية
        public static void lbc_iniatalize_data(this ListBoxControl lbc, object data_source,
            string DisplayMember, string ValueMember)
        {
            lbc.DataSource = data_source;
            lbc.DisplayMember = DisplayMember;
            lbc.ValueMember = ValueMember;

        }

        #endregion

        #region search_look_up_edite iniatalize_data
        //extenshes جعل التابع الذي ننشئه يظهر بعد الدوت في اسم العنصر
        //this هي من اجل الاكستنشنز
        public static void slkp_iniatalize_data(this SearchLookUpEdit slkp, object data_source)
        {
            slkp.slkp_iniatalize_data(data_source, "name", "id");//استدعاء الميثود التي بعده
        }
        //overloade إذا بنا نغير الاسم و ال الآي دي 
        //هي الأساسية
        public static void slkp_iniatalize_data(this SearchLookUpEdit slkp, object data_source,
            string DisplayMember, string ValueMember)
        {
            slkp.Properties.DataSource = data_source;
            slkp.Properties.DisplayMember = DisplayMember;
            slkp.Properties.ValueMember = ValueMember;
            slkp.Properties.PopulateViewColumns();
            // lkp.Properties.Columns[ValueMember].Visible = false;
        }

        #endregion
    }

    /*
         public override void Get_Data(string status_mess)
       {
           base.Get_Data(status_mess);
       }
       public override void Insert_Data()
       {
           base.Insert_Data();
       }
      public override void Update_Data()
       {
           base.Update_Data();
       }
       public override void Delete_Data()
       {
          base.Delete_Data();
       }

       public override void clear_data(Control.ControlCollection s_controls)
       {
           base.clear_data(s_controls);
       }
       public override void Print_Data()
       {
           base.Print_Data();
       }

        public override bool Validate_Data()
        {
            return base.Validate_Data();
        }
           private void Set_Auto_Id()
        {

        }
       public void Fill_Controls()
       {

       }
       public void Fill_Entitey()
       {

       }
       private void Fill_Graid()
       {
       }

       */
}
