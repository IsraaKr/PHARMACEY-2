using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
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

namespace PhamaceySystem.Forms.Setting_Forms
{
    public partial class F_Server_Setting : F_Master_Inheretanz
    {
        public F_Server_Setting(bool FirstStart)
        {
            InitializeComponent();
            Is_sqript_in = 0;
            Is_backup_in = 0;
            firstStart = FirstStart;
            Set_Prop_Settings();
            txt_server.Text = C_DB.Get_server_name();
            txt_database.Text = "PHARMACEY_DB";
            txt_back_name.Text = txt_database.Text + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
       Properties.Settings.Default.Server_Name = txt_server.Text;
            Properties.Settings.Default.database = txt_database.Text;
            Properties.Settings.Default.Save();


            view_inheretanz_butomes(false, true, false, false, false, false,true);
            Title(tit);
            this.Text = tit;
            if (txt_back_path.Text != string.Empty || txt_back_path.Text != " ")
            {
                Is_backup_in = 1;
            }
            if (txt_sqript_bath.Text != string.Empty || txt_sqript_bath.Text != " ")
            {
                Is_sqript_in = 1;
            }
        }
        public string tit = "Server Settings \\ إعدادات السيرفر ";
        public F_Server_Setting()
        {
            InitializeComponent();

            Set_Prop_Settings();
            Is_sqript_in = 0;
            Is_backup_in = 0;
            txt_server.Text = C_DB.Get_server_name();
            txt_database.Text = "PHARMACEY_DB";
            txt_back_name.Text = txt_database.Text + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second ;


            Properties.Settings.Default.Server_Name = txt_server.Text;
            Properties.Settings.Default.database = txt_database.Text;
            Properties.Settings.Default.Save();


            view_inheretanz_butomes(false, true, false, false, false, false, true);
            Title(tit);
            this.Text = tit;
            if (txt_back_path.Text!=string.Empty ||  txt_back_path.Text != " " )
            {
                Is_backup_in = 1;
            }

            if (txt_sqript_bath.Text != string.Empty || txt_sqript_bath.Text != " ")
            {
                Is_sqript_in = 1;
            }


        }
        private readonly bool firstStart;
        string backup_path;
        bool run = false;
        int Is_sqript_in = 0;
        int Is_backup_in = 0;


        //انشاء قاعدة البيانات
        private void create_db()
        {  // أول استدعاء من اجل انشاء قاعدة البيانات و الجداول
            try//جلب اسم السيرفر و  الاتصال بالسيرفر
            {
                txt_server.Text = C_DB.Get_server_name();
                MessageBox.Show("تم جلب اسم السيرفر : " + txt_server.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ServerName part" +ex);
            }
            C_DB.Server_connection(txt_server.Text);

            MessageBox.Show("تم الاتصال بالسيرف " + txt_server.Text);

            // ******************************************
            //string sql = "select name from sys.databases"; //تجلب اسماء قواعد البيانات التي عندي
            //DataTable dt = C_DB.select(sql);

            try//إنشاء قاعدة  البيانات و الاتصال بها
            {
                C_DB.Create_DB(txt_database.Text);
                MessageBox.Show("تم إنشاء قاعدة البيانات : " + txt_database.Text);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains(Classes.C_Exception.Service_exception))
                {
                    C_Master.Warning_Massege_Box("الرجاء التأكد من الخدمات SQL services");
                    Application.Exit();
                }
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
            }
            C_DB.DB_Connection(txt_server.Text, txt_database.Text);
            MessageBox.Show("تم الاتصال بقاعدة البيانات " + txt_database.Text);
            Properties.Settings.Default.Server_Name = txt_server.Text;
            Properties.Settings.Default.database = txt_database.Text;
            Properties.Settings.Default.Save();
            //************************************************
            try//إنشاء الجداول
            {
                run = C_DB.RunSqlScriptFile(Properties.Settings.Default.sqript_path);
                MessageBox.Show("تم إنشاء كل الجداول  " + run);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in tables part"+ex);
            }

            try
            {
                ClsCommander<T_OPeration_Type> cmdopType = new ClsCommander<T_OPeration_Type>();

                T_OPeration_Type TF_op_type = new T_OPeration_Type();
                var check = cmdopType.Get_All().Count();
                if (check == 0)
                {
                    TF_op_type.OP_type_name = "عملية ادخال";
                    TF_op_type.OP_type_state = true;
                    cmdopType.Insert_Data(TF_op_type);

                    TF_op_type.OP_type_name = "عملية اخراج";
                    TF_op_type.OP_type_state = true;
                    cmdopType.Insert_Data(TF_op_type);

                    TF_op_type.OP_type_name = "عملية إتلاف";
                    TF_op_type.OP_type_state = true;
                    cmdopType.Insert_Data(TF_op_type);
                }

                MessageBox.Show(" تم الادخال على جدول أنواع الفواتير ");
            }
            catch (Exception)
            {
                MessageBox.Show("Error in operation type  tables part");
            }
            try
            {
                ClsCommander<T_Users> cmdUsers = new ClsCommander<T_Users>();
                ClsCommander<T_Roles> cmdRoles = new ClsCommander<T_Roles>();

                T_Users TF_Users = new T_Users();
                var check = cmdUsers.Get_All().Count();
                if (check == 0)
                {
                    TF_Users.Full_Name = "مدير النظام";
                    TF_Users.user_name = "admin";
                    TF_Users.pass_word = C_Master. SHA512( "admin") ;
                    TF_Users.Role = "مدير";
                    TF_Users.is_secondery = true;
                    TF_Users.updated_date = DateTime.Now;
                    TF_Users.cerated_date = DateTime.Now;
                    cmdUsers.Insert_Data(TF_Users);
                    TF_Users = cmdUsers.Get_All().FirstOrDefault();
                    List<string> rolesName = new List<string> 
                    {
                    "per_in",
                    "per_dam",
                    "per_med",
                    "per_thwabet",
                    "per_rep",
                    "per_out",
                    "per_sysRecord",
                    "per_seting",
                    "per_Users",
                    "per_Db",
                    "per_save",
                    "per_edite",
                    "per_delete",
                    "per_print",
                };
                    //done and add user  roles
                    for (int i = 0; i < rolesName.Count; i++)            
                    {
                       
                        //set role
                        T_Roles roles = new T_Roles();

                        roles.keyy = rolesName[i];
                        roles.value = true;
                        roles.User_Id = TF_Users.Id ;

                        //send role
                        cmdRoles.Insert_Data(roles);
                    }
                }

                MessageBox.Show(" تم إنشاء مدير النظام ");
            }
            catch (Exception)
            {
                MessageBox.Show("Error in Users  tables part");
            }


        }
    
     
        private void rb_local_CheckedChanged(object sender, EventArgs e)
        {
            txt_user_name.Enabled = false;
            txt_pass.Enabled = false;
            txt_time.Enabled = false;
        }

        private void rb_network_CheckedChanged(object sender, EventArgs e)
        {
            txt_user_name.Enabled = true;
            txt_pass.Enabled = true;
            txt_time.Enabled = true;
        }

        private void Save_Prop_Settings()
        {
            Properties.Settings.Default.Server_Name = txt_server.Text;
            Properties.Settings.Default.database = txt_database.Text;
            Properties.Settings.Default.username = txt_user_name.Text;
            Properties.Settings.Default.password = txt_pass.Text;
            Properties.Settings.Default.time_server = txt_time.Text;
            Properties.Settings.Default.sqript_path = txt_sqript_bath.Text;
            Properties.Settings.Default.is_first_time =!run;
            Properties.Settings.Default.save_backup_path = txt_back_path.Text;

            // Save Settings
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات بنجاح");

        }
        private void Set_Prop_Settings()
        {
            txt_server.Text = Properties.Settings.Default.Server_Name;
            txt_database.Text = Properties.Settings.Default.database;
            txt_user_name.Text = Properties.Settings.Default.username;
            txt_pass.Text = Properties.Settings.Default.password;
            txt_time.Text = Properties.Settings.Default.time_server;
            txt_sqript_bath.Text = Properties.Settings.Default.sqript_path;
            txt_back_path.Text= Properties.Settings.Default.save_backup_path;

        }
        public override void Insert_Data()
        {

 
            Save_Prop_Settings();
            MessageBox.Show("تم حفظ نص الاتصال بنجاح , اعد تشغيل البرنامج لطفا");
            Application.Exit();
            base.Insert_Data();
        }

        private void SetNetWorkCon(string server, string dataBase, string userName, string password, String timout)
        {
            var ConString = @"Server=" + server + ";Database=" + dataBase + ";User Id=" + userName + ";Password=" + password + ";Timeout=" + timout + "";
            Properties.Settings.Default.Server_Name = server;
            Properties.Settings.Default.database = dataBase;
            Properties.Settings.Default.username = userName;
            Properties.Settings.Default.password = password;

            //   Properties.Settings.Default.SqlServerConString = ConString;
            // Save Settings
            Properties.Settings.Default.Save();
        }

        private void SetLocalCon(string server, string dataBase)
        {
            var ConString = @"Server=" + server + ";Database=" + dataBase + ";Trusted_Connection=True;";
            Properties.Settings.Default.Server_Name = server;
            Properties.Settings.Default.database = dataBase;

            //  Properties.Settings.Default.SqlServerConString = ConString;
            // Save Settings
            Properties.Settings.Default.Save();
        }

        private void F_Server_Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstStart == true)
            {
                Application.Exit();
            }
        }

        private void btn_sqript_file_Click(object sender, EventArgs e)
        {
            Is_sqript_in = 1;
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "اختر ملف سكريبت قاعدة البيانات";
            openFileDialog.RestoreDirectory = true;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_sqript_bath.Text = openFileDialog.FileName;

                // Save Settings
                Properties.Settings.Default.sqript_path = txt_sqript_bath.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show(" تم حفظ المسار بنجاح \n يرجى أنشاء قاعدة البيانات");

            }
        }

        private void btn_create_db_Click(object sender, EventArgs e)
        {
            if (Is_sqript_in==1)
            {
                create_db();
                MessageBox.Show("تم حفظ الإعدادات  بنجاح , سيتم إغلاق البرنامج \n أعد التشغيل لطفا ");
                Application.Exit();

            }
        }

        private void btn_backup_database_Click(object sender, EventArgs e)
        {
            bool back = false;
            if (Is_backup_in==1)     
              back =  C_DB.DB_Backup(txt_server.Text, txt_database.Text, txt_back_path.Text, txt_back_name.Text + ".bak");
            if (back == true)
                MessageBox.Show(" تم حفظ النسخة الاحتياطية بنجاح");

        }

        private void btn_folder_backup_Click(object sender, EventArgs e)
        {

            Is_backup_in = 1;
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            //openFileDialog. = "اختر ملف سكريبت قاعدة البيانات";
            //openFileDialog.RestoreDirectory = true;
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_back_path.Text = openFileDialog.SelectedPath;
                txt_back_name.Text = txt_database.Text + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                // Save Settings
                Properties.Settings.Default.save_backup_path = txt_back_path.Text;
                Properties.Settings.Default.Save();
               

            }
        }
    }
}