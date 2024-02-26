using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Setting_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Starts_Forms
{
    public partial class F_Start : Form
    {
        public F_Start()
        {
            InitializeComponent();
            
        }
        ClsCommander<T_OPeration_Type> cmdopType = new ClsCommander<T_OPeration_Type>();

        private void check_conn()
        {
            try
            {
               Boolean chec = cmdopType.check_db_existing();                  
                if (chec == true)
                {
                    lbl_state.Text = "جاري الاتصال بقاعدة البيانات";
                   
                        F_Main f = new F_Main();
                    this.Hide();
                    f.Show();
                   
                }
                else if (chec == false)
                {
                    var res = MessageBox.Show("خطاء في الاتصال بقاعدة البيانات !!! اختر نعم لضبط نص الاتصال أو لا للخروج من البرنامج", "تأكيد",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        F_Server_Setting f = new F_Server_Setting();
                     
                        f.Show();
                        this.Close();
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

        private void F_Start_Load(object sender, EventArgs e)
        {
            check_conn();
        }
    }
}
