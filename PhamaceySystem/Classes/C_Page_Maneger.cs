using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Classes
{
   public class C_Page_Maneger 
    {
        private readonly F_Main _Main;
        public C_Page_Maneger(F_Main f_Main )
        {
            this._Main = f_Main;
        }
        public void load_page(Form f)
        {
            //load old page
            //var old_page = _Main.pan_nav.Controls.OfType<Form>().FirstOrDefault();
            //if (old_page != null)//اذا مو اول مرة منفتح صفحة
            //{
            //    _Main.pan_nav.Controls.Remove(old_page);
            //    old_page.Dispose();
            //}

            //load new page
            //nav(f, _Main.pan_nav);
            //page_f.Dock = DockStyle.Fill;
            //_Main.pan_nav.Controls.Add(f);
        }
        public void nav(Form f, PanelControl p)
        {
            //  c_Page_Maneger.load_page(f);

            f.TopLevel = false;
            f.Size = p.Size;
            f.Dock = DockStyle.Fill;
            p.Controls.Clear();
            p.Controls.Add(f);
            f.Show();
        }
        //**************** Xtra tap MDI Maneger ****************
        // و تحديد الاب فتح الابن 
        public void view_Child_Forem (Form _F)
        {
            if (Is_Form_Activate(_F))
            {
                _F.MdiParent = _Main;
                _F.Show();
            }
        }
        //هل الفورم مفتوح
        public bool Is_Form_Activate(Form f)
        {
            bool Is_Opened = false;
            if (_Main.MdiChildren.Count()>0)
            {
                foreach (var item in _Main.MdiChildren)
                {
                    if (f.Name ==item.Name)
                    {
                      //  _Main.xtmdi.Pages[item].MdiChild.Activate();
                        Is_Opened = true;
                    }
                }
            }
            else
            {
                f = new Form();
                f.MdiParent = _Main;
                f.Show();
            }
            return Is_Opened;

        }

        // فتح ابن من ابن 
        public void open_form_from_other (Form f)
        {
            if (Is_Form_Activate(f))
            {
             //  f.MdiParent =this .MdiParent;
               f.Show();
            }
        }

       // ************* xtra tab control *******************

    }
}
