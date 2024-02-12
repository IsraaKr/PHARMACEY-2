using System;
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

namespace PhamaceySystem
{
    public partial class F_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly C_Page_Maneger c_Page_Maneger;
        ClsCommander<T_OPeration_Type> cmdOptype = new ClsCommander<T_OPeration_Type>();
   
        public F_Main()
        {
            InitializeComponent();
            c_Page_Maneger = new C_Page_Maneger(this);

        }
        private bool IsFirstTime()
        {
            return Properties.Settings.Default.is_first_time;
        }
        private void load_first_frame()
        {
            F_Quiek_Accses f = new F_Quiek_Accses();
            open_extra(f, xtraTabControl1);
            xtraTabControl1.TabPages[0].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            xtraTabControl1.TabPages[0].Text = "الوصول السريع";
        }

        //نستدعيه عند كل فتحة فورم جديد 
        public void nav(Form f, PanelControl p)
        {
            //  c_Page_Maneger.load_page( f );
            // c_Page_Maneger.view_Child_Forem(f);
            //f.TopLevel = false;
            //f.Size = p.Size;
            //f.Dock = DockStyle.Fill;
            //p.Controls.Clear();
            //p.Controls.Add(f);
            //f.Show();
        }
        //فتح الفورم عن طريق اسمه باستعمال الاسمبلي
        public void open_form_byname(string name)
        {  //الاسمبلي الذي نحنا نعمل فيه .الانواع .الاأول
            var ins = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == name);
            if (ins != null)
            {   //انشاء انستانس من التايب و ارجاعه على شكل فورم
                var frm = Activator.CreateInstance(ins) as Form;
                frm.MdiParent = this;

                //if (Application.OpenForms[frm.Name] != null)//التأكد إذا الفورم كان مفتوح
                //{
                //frm = Application.OpenForms[frm.Name];
                //  nav(frm, pan_nav);
                open_extra(frm, xtraTabControl1);

                //   }
                //    else
                //    {
                //        // frm.Show();
                //      //  nav(frm, pan_nav);
                //    }
                //   frm.BringToFront();
            }
        }
        private void ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            // نضع التاغ من الديزايننر نوع سترينغ و القيمة اسم الفورم الذي اريد فتحه
            var tag = e.Item.Tag as string;
            if (tag != string.Empty && tag != null)
            {
                open_form_byname(tag);
            }
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            //عدم غلق الفورم الأول
            if (xtraTabControl1.SelectedTabPage != xtraTabControl1.TabPages[0])
            {
                //  xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                XtraTabPage xtraTabPage = arg.Page as XtraTabPage;
                xtraTabPage.Dispose();
            }
        }
        public bool Is_Form_Activate(Form f)
        {
            bool Is_Opened = false;
            if (xtraTabControl1.TabPages.Count() > 0)
            {
                foreach (XtraTabPage item in xtraTabControl1.TabPages)
                {
                    if (f.Name == item.Name)
                    {
                        xtraTabControl1.SelectedTabPage = item;
                        Is_Opened = true;
                    }
                }
            }
            return Is_Opened;
        }
        public void open_extra(Form f, XtraTabControl xtbc)
        {
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            if (Is_Form_Activate(f) == false)
            {
                xtbc.TabPages.Add();
                var curent_page = xtbc.TabPages.Last();
                curent_page.Text = f.Text;
                curent_page.Name = f.Name;
                curent_page.Controls.Add(f);
                xtbc.SelectedTabPage = curent_page;
                f.Show();
            }
        }
  
        private void get_med_min_num()
        {
            // int test = cmdOptype.Get_All().Count();
            //DataTable dt = c_db.select(@"select * from T_OPeration_Type");
            if (Properties.Settings.Default.is_first_time == false)
            {
                bool check_show_form = Properties.Settings.Default.is_med_count_show;
             DataTable   dt = c_db.select(@"SELECT  dbo.T_Medician.med_id,
                                                 dbo.T_Medician.med_code,
                                                dbo.T_Medician.med_name,
                                                dbo.T_Medician.med_minimum,
                                                dbo.T_Medician.med_total_now                 
                     FROM        dbo.T_Medician 
                    WHERE        (dbo.T_Medician.med_total_now <=   dbo.T_Medician.med_minimum)");
                int count = dt.Rows.Count;
                bar_med_min.Caption = count.ToString();
                if (count > 0 && check_show_form)
                {
                    F_Med_Minimem f = new F_Med_Minimem();
                    f.ShowDialog();
                }
            }
        }

        private void bar_med_min_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bar_med_min_ItemPress(object sender, ItemClickEventArgs e)
        {
            F_Med_Minimem f = new F_Med_Minimem();
            f.ShowDialog();
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            load_first_frame();

             get_med_min_num();
        }
    }
}