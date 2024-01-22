using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//فيرتشول من اجل اعمله اوفر رايدينغ عند الوراثة و 

namespace PhamaceySystem
{
    public partial class F_Master_Inheretanz : Form
    {
        public F_Master_Inheretanz()
        {
            InitializeComponent();
            // view_inheretanz_butomes(true,false, true, true, true, true);
        }
       //عرض و إخفاء الأزرار
        public virtual void view_inheretanz_butomes(bool neew ,bool add , bool add_save , bool edite , bool delete , bool clear , bool print)
        {
            if (neew)
            {
                bar_neew.Visibility =0 ;
                sp_new.Visibility = 0;
            }
            if (add)
            {
                bar_add.Visibility = 0;
                sp_add.Visibility = 0;
            }
            if (add_save)
            {
                bar_add_save.Visibility = 0;
                sp_add_save.Visibility = 0;
            }
            if (edite)
            {
                bar_edit.Visibility = 0;
                sp_edite.Visibility = 0;
            }
            if (delete)
            {
                bar_delete.Visibility = 0;
                sp_delete.Visibility = 0;
            }
            if (clear)
            {
                bar_clear.Visibility = 0;
                sp_clear.Visibility = 0;
            }
            if (print)
            {
                bar_print.Visibility = 0;
                sp_print.Visibility = 0;
            }
            
        }
        private void F_Master_Inheretanz_Load(object sender, EventArgs e)
        {
            Get_Data("");
           
            timer_date.Enabled = true;
        }
        //تغير رسالة الستاتس
        public void change_states_message(string status_mess)
        {
            bar_states.Caption = "...";
            bar_states.ItemAppearance.Normal.BackColor = F_Master_Inheretanz.DefaultBackColor;
            if (status_mess == "")
            {
                return;
            }
            else if (status_mess == "i")
            {
                bar_states.Caption = "             تم الإدخال بنجاح              ";
                bar_states.ItemAppearance.Normal.BackColor = Color.DarkSeaGreen;
                clear_data(this.Controls);
            }
            else if (status_mess == "u")
            {
                bar_states.Caption = "             تم التعديل بنجاح              ";
                bar_states.ItemAppearance.Normal.BackColor = Color.Khaki;
                clear_data(this.Controls);
            }
            else if (status_mess == "d")
            {
                bar_states.Caption = "             تم الحذف بنجاح              ";
                bar_states.ItemAppearance.Normal.BackColor = Color.IndianRed;
                clear_data(this.Controls);
            }
            else
            {
                MessageBox.Show(status_mess);
                bar_states.Caption = "            فشل الإجراء             ";
                bar_states.ItemAppearance.Normal.BackColor = Color.Maroon;
                bar_states.ItemAppearance.Normal.ForeColor = Color.White;
            }

        }
        //************************************
        //توابع الوراثة

        //تغير العنوان و اللون 
        public virtual void Title(string s_title , Color back_colore)
        {
            lbl_tiltle.Text = s_title;
            lbl_tiltle.BackColor = back_colore;
        }
       //تغير العنوان
        public virtual void Title(string s_title)
        {
            lbl_tiltle.Text = s_title;            
        }
  
       //تحميل 
        public virtual void Get_Data(string status_mess)
        {
            change_states_message(status_mess);
        }
        //جديد 
        public virtual void neew ()
        {
            clear_data(this.Controls);
            Get_Data("");
        }
        //التأكد من الصحة
        public virtual bool Validate_Data()
        {
            return true;
        }
        //الادخال
        public virtual void Insert_Data()
        {
            timer_states_bar.Enabled = true;

        }
        //حفظ و إدخال
        public virtual void Insert_save_Data()
        {
            timer_states_bar.Enabled = true;

        }
        //التعديل
        public virtual void Update_Data()
        {
            timer_states_bar.Enabled = true;

        }
        //الطباعة
        public virtual void Print_Data()
        {


        }
        //الحذف
        public virtual void Delete_Data()
        {
            timer_states_bar.Enabled = true;

        }
        //لتفريغ الحقول    
        public virtual void clear_data(Control.ControlCollection s_controls)
        {    //كود لتفريغ كل محتوى الكونترولات
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control c in controls)
                    if (c is TextBox)
                        (c as TextBox).Text = string.Empty;
                    else if (c is DateEdit)
                        (c as DateEdit).DateTime = DateTime.Now;
                    else if (c is TimeSpanEdit)
                        (c as TimeSpanEdit).EditValue = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
                    else if (c is SearchLookUpEdit)
                    {
                        (c as SearchLookUpEdit).Text = "";
                        (c as SearchLookUpEdit).EditValue = null;
                    }
                    else if (c is LookUpEdit)
                    {
                        c.Text = null;
                        (c as LookUpEdit).EditValue = null;
                    }
                    else if (c is PictureEdit)
                        (c as PictureEdit).Image = null;
                    else if (c is DateTimePicker)
                        (c as DateTimePicker).Value = DateTime.Now;
                    else if (c is System.Windows.Forms.ComboBox)
                        (c as System.Windows.Forms.ComboBox).SelectedIndex = -1;
                    else if (c is TimeEdit)
                        (c as TimeEdit).Time = DateTime.Now;
                    else
                        func(c.Controls);
            };
            func(s_controls);
        }

  //*****************************************
  //الأحداث

        //ضغط أي زر في الفورم
        private void F_Master_Inheretanz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                 Insert_Data();
           //     MessageBox.Show("");
            //if (e.KeyCode == Keys.F2)
            //    new();
            if (e.KeyCode == Keys.Delete)
                Delete_Data();
            if (e.KeyCode == Keys.Escape)
                clear_data(this.Controls);
        }
   
        //ضغط إضافة
        private void bar_add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Insert_Data();
         //   timer_states_bar.Enabled = true;
        }
        //ضغط تعديل
        private void bar_edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Update_Data();
            timer_states_bar.Enabled = true;
        }
        //ضغط الحذف
        private void bar_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete_Data();
            timer_states_bar.Enabled = true;
        }
        //ضغط مسح
        private void bar_clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clear_data(this.Controls);
            Get_Data("");
            timer_states_bar.Enabled = true;
        }
        //ضغط طباعة
        private void bar_print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print_Data();
        }
        //ضغط إغلاق
        private void bar_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        //تايمر الستاتس
        private void timer_states_bar_Tick(object sender, EventArgs e)
        {
            change_states_message("");
            timer_states_bar.Enabled = false;
        }
        //تايمر التاريخ
        private void timer_date_Tick(object sender, EventArgs e)
        {
            bar_date.Caption = DateTime.Now.ToShortDateString();
            bar_time.Caption = DateTime.Now.ToShortTimeString();
        }

        private void bar_add_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Insert_save_Data();
        }

        private void lbl_tiltle_Click(object sender, EventArgs e)
        {

        }

        private void bar_neew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            neew();
            //    timer_states_bar.Enabled = true;
        }
    }
}
