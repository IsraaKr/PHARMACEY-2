using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
using PhamaceySystem.Forms.Setting_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.User_Forms
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            try
            {
              //  DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.theme;
                bool servecices = C_DB.Check_Services();
                if (servecices)
                {
                    Boolean chec = cmdOptype.check_db_existing();
                    if (chec == true)
                    {
                        InitializeComponent();
                        Get_Data("");
                        Colores();
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
                            Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        ClsCommander<T_OPeration_Type> cmdOptype = new ClsCommander<T_OPeration_Type>();
        ClsCommander<T_Users> cmdUsers = new ClsCommander<T_Users>();
        ClsCommander<T_Roles> cmdRoles = new ClsCommander<T_Roles>();


        T_Users TF_Users;


        public  void Get_Data(string status_mess)
        {
            try
            {
                checkBox_RemempperMe.Checked = Properties.Settings.Default.Rememper_me;
                if (checkBox_RemempperMe.Checked)
                {
                    txt_username.Text = Properties.Settings.Default.login_user_name;
                    txt_password.Text = Properties.Settings.Default.login_pass_Word;
                }
                cmdUsers = new ClsCommander<T_Users>();
                TF_Users = cmdUsers.Get_All().FirstOrDefault();
                  
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }

        }
        private void btn_login_Click(object sender, EventArgs e)
    {
        if (txt_username.Text == string.Empty)
        {
            txt_username.ErrorText = "الرجاء اختيار اسم المستخدم";
            txt_username.Focus();
            return;
        }
        if (txt_password.Text == string.Empty)
        {
            txt_password.ErrorText = "الرجاء إدخال كلمة المرور";
            txt_password.Focus();
            return;
        }

            string psw = C_Master.SHA512(txt_password.Text);
           TF_Users = cmdUsers.Get_All().Where(l =>
            l.user_name == txt_username.Text &&
            l.pass_word ==psw ).FirstOrDefault()?? new T_Users() ;
      
        if (TF_Users.Id > 0)
        {

                //set user info
                SetLocalUser();
                SaveUserRoles();
             
                C_Add_System_record.Add("تسجيل الدخول", "تسجيل الدخول", $"  تم تسجيل الدخول لمستخدم باسم {TF_Users.Full_Name} ");
                if (checkBox_RemempperMe.Checked)
                {
                    Properties.Settings.Default.login_user_name = txt_username.Text;
                    Properties.Settings.Default.login_pass_Word = txt_password.Text;
                    Properties.Settings.Default.Save();
                }
              
                C_Master.user_login = txt_username.Text.Trim();
            F_Main f = new F_Main();
            f.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show(" يرجى التأكد من اسم المستخدم أو كلمة المرور", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_username.Focus();
            return;
        }
    }
        private void F_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
       private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            btn_login.PerformClick();
        }
    }
        private void btn_new_user_Click(object sender, EventArgs e)
    {
        if (txt_username.Text == "admin" && txt_password.Text == "admin")
        {
           
            F_User_Add f = new F_User_Add();
            f.Show();

        }
        else
            MessageBox.Show(" الرجاء تسجيل الدخول كمدير", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        private void checkBox_RemempperMe_CheckedChanged(object sender, EventArgs e)
        {
          
            if (Convert.ToBoolean(checkBox_RemempperMe.CheckState) && Properties.Settings.Default.Rememper_me==false)
            {
                Properties.Settings.Default.Rememper_me = Convert.ToBoolean(checkBox_RemempperMe.CheckState);
              
            }
            else if(Convert.ToBoolean(checkBox_RemempperMe.CheckState)==false && Properties.Settings.Default.Rememper_me == true)
            {
                Properties.Settings.Default.Rememper_me = Convert.ToBoolean(checkBox_RemempperMe.CheckState);

            }

            // Save Settings
            Properties.Settings.Default.Save();
        }
        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowPassword.Checked)     
            txt_password.Properties.PasswordChar = (txt_password.Properties.PasswordChar == '*') ? '\0' : '*';
            else
                txt_password.Properties.PasswordChar = '*';


        }
        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_password.Focus();
            }
        }
       
        
       
        public void Colores()
        {
            panel2.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_login.Appearance.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_cancel.Appearance.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_new_user.Appearance.BackColor = Properties.Settings.Default.titel_master_colore;

        }      
        private void SetLocalUser()
        {
            C_Local_User.Id = TF_Users.Id;
            C_Local_User.UserName = TF_Users.user_name;
            C_Local_User.PassWord = TF_Users.pass_word;
            C_Local_User.UserId = TF_Users.Id.ToString();
            C_Local_User.FullName = TF_Users.Full_Name;
            C_Local_User.Role = TF_Users.Role;
         

        }
        private void SaveUserRoles()
        {
            C_Local_User.LocalRoles = cmdRoles.Get_All().Where(l => l.User_Id == TF_Users.Id).ToList();

            C_RoleManeger.ClearRole();
            foreach (var item in C_Local_User.LocalRoles)
            {
                C_RoleManeger.Register_role(item.keyy, Convert.ToBoolean(item.value));
            }
        }
      
    }

    
}
