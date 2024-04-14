﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Reflection;
using DevExpress.XtraEditors;
using PhamaceySystem.Forms;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
using PhamaceySystem.Forms.Medicin_Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using PhamaceySystem.Forms.Collection_Forms;
using PhamaceySystem.Forms.Setting_Forms;
using PhamaceySystem.Forms.Report_Forms;
using PhamaceySystem.Forms.Store_Other_Forms;

namespace PhamaceySystem
{
    public partial class F_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
    //    private readonly C_Page_Maneger c_Page_Maneger;
        ClsCommander<T_OPeration_Type> cmdOptype = new ClsCommander<T_OPeration_Type>();
        ClsCommander<T_OPeration_IN_Item> cmdOpInItem = new ClsCommander<T_OPeration_IN_Item>();
        public static string static_med_min;
        public static string static_date_exp;
        public F_Main()
        {
            try
            {
                Boolean chec = cmdOptype.check_db_existing();
                if (chec == true)
                {
                    InitializeComponent();
                }
                else if (chec == false)
                {
                    var res = MessageBox.Show("خطاء في الاتصال بقاعدة البيانات !!! اختر نعم لضبط نص الاتصال أو لا للخروج من البرنامج", "تأكيد",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        F_Server_Setting f = new F_Server_Setting();

                        f.Show();

                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }       
        private void load_first_frame()
        {
            F_Quiek_Accses f = new F_Quiek_Accses();
            open_extra(f);
            xtc.Pages[0].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            xtc.Pages[0].Text = "الوصول السريع";
        }

        //فتح الفورم عن طريق اسمه باستعمال الاسمبلي
        public void open_form_byname(string name)
        {  //الاسمبلي الذي نحنا نعمل فيه .الانواع .الاأول
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);
            if (ins != null)
            {   //انشاء انستانس من التايب و ارجاعه على شكل فورم
                var frm = Activator.CreateInstance(ins) as Form;        
                open_extra(frm);
            }
        }
        private void ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = e.Item.Tag as string;
            if (tag != string.Empty && tag != null)
            {
                open_form_byname(tag);
            }
        }      
        public bool Is_Form_Activate(Form f)
        {
            bool Is_Opened = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (f.Name == item.Name)
                    {
                        xtc.Pages[item].MdiChild.Activate();
                        Is_Opened = true;
                    }
                }
            }
            return Is_Opened;
        }
        public void open_extra(Form f)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            if (Is_Form_Activate(f) == false)
            {
                f.MdiParent = this;
                f.Show();
                            
            }
        }  
        private void get_med_min_num()
        {          
                bool check_show_not = Properties.Settings.Default.is_med_count_not_show;
            bool check_show_form = Properties.Settings.Default.is_med_count_form_show;

            DataTable dt = c_db.select(@"SELECT  dbo.T_Medician.med_id,
                                                 dbo.T_Medician.med_code,
                                                dbo.T_Medician.med_name,
                                                dbo.T_Medician.med_minimum,
                                                dbo.T_Medician.med_total_now                 
                     FROM        dbo.T_Medician 
                    WHERE        (dbo.T_Medician.med_total_now <=   dbo.T_Medician.med_minimum)");
                int count = dt.Rows.Count;
           
            static_med_min = count.ToString();
            bar_med_min.Caption = static_med_min;
            if (check_show_not && count > 0)
            {
                Notification_Form n = new Notification_Form("الأدوية التي شارفت على الانتهاء", "" + count);
                n.Show();
            }
                if (check_show_form && count > 0 )
                {
                    F_Med_min f = new F_Med_min();                
                    f.ShowDialog();
                }
          

            }

        private void get_med_exp_date()
        {
            bool check_date_exp_not = Properties.Settings.Default.is_expdate_not_show;
            bool check_date_exp_form = Properties.Settings.Default.is_expdate_form_show;

            //DataTable dt = c_db.select(@"SELECT  dbo.T_Medician.med_id,
            //                                     dbo.T_Medician.med_code,
            //                                    dbo.T_Medician.med_name,
            //                                    dbo.T_Medician.med_minimum,
            //                                    dbo.T_Medician.med_total_now                 
            //         FROM        dbo.T_Medician 
            //        WHERE        (dbo.T_Medician.med_total_now <=   dbo.T_Medician.med_minimum)");

            var dt= (from med in cmdOpInItem.Get_All().Where(l => l.in_item_expDate.Value.Month < DateTime.Today.Month
                             && l.in_item_expDate.Value.Year <= DateTime.Today.Year
                             && l.is_out != true)
                     select new
                     {
                         id = med.in_item_id,
                         med_id = med.Med_id,
                         code = med.T_Medician.med_code,
                         name = med.T_Medician.med_name,
                         quntetey = med.in_item_quntity,
                         datee = med.in_item_expDate,

                     }).OrderBy(l_id => l_id.id).ToList();
            int count =  dt.Count;

            static_date_exp = count.ToString();
            bar_exp_date.Caption = static_date_exp;
            if (check_date_exp_not && count > 0)
            {
                F_exp_date_notification n = new F_exp_date_notification("الأدوية المنتهية الصلاحية", "" + count);
                n.Show();
            }
            if (check_date_exp_form && count > 0)
            {
                F_Store_Med_ExpDate f = new F_Store_Med_ExpDate();
                f.ShowDialog();
            }


        }
        private void F_Main_Load(object sender, EventArgs e)
        {
            load_first_frame();

             get_med_min_num();
            get_med_exp_date();
        }
        private void close_all()
        {
            var f =  MdiChildren;
            int i = 0;
            while (i<f.Length)
            {
                f[i].Close();
                i = i + 1;
            }
        }
        private void F_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

 
    }
}