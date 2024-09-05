using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.ServiceProcess;

namespace PhamaceySystem
{
    class C_DB
    {
        //public static SqlConnection con;
        public static SqlCommand Command;
        public static SqlDataReader dr;
        //  public static SqlDataAdapter da;
        public static DataTable dt;
        public static int done;

        public static SqlConnection _Con;
        public static SqlConnection Con  //عند كل استخدام ل كون نستخدم التابع و ليس الخاصية
        {
            get
            {
                if (_Con.State != ConnectionState.Open)
                    _Con.Open();
                return _Con;
            }
            set
            {
                _Con = value;
            }
        }

        //التأكد من تشغيل الخدمات 
        //تفقد خدمات السضم
        public static bool Check_Services()
        {
            ServiceController[] services = ServiceController.GetServices();
           List<string> services_to_check = new List<string>() ; 
            foreach (var item in services)
            {
                if (item.ServiceName.Contains("SQLEXPRESS") && !item.ServiceName.Contains("Agent"))
                {
                    services_to_check.Add(item.ServiceName);
                }
            }
             
            foreach (var item in services_to_check)
            {
                ServiceController sc = new ServiceController(item);
                try
                {
          
                    if (sc.Status != ServiceControllerStatus.Running)
                    {
                        MessageBox.Show($" الخدمة  لا تعمل !! يرجى تـشغيلها و المحاولة مرة أخرى  {item} "
                                                   , "خدمة ويندوز متوففة",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Warning);
                        Application.Exit();
                        return false;

                    }

                }


                catch (Exception ex)
                {

                    MessageBox.Show("حدث خطأ أثنار التحقق من الخدمة  " + item + " " + ex.Message);
                    return false;
                }

            }
            return true;
        }

        //backup 
        
        public static bool DB_Backup(string server, string db_name , string path, string back_name)
        {
            try
            {               
                DB_Connection(server,db_name);
                done = 0;
              //  string back_File_path = path + @"\" + back_name ;
                string back_File_path2 =Path.Combine(path , back_name);
           //     string Backup_command = $" BACKUP DATABASE [{db_name}] TO DISK = N' {back_File_path2} ' " ;
                string Backup_command2 = $"BACKUP DATABASE [{db_name}] TO  DISK = N'{back_File_path2}' WITH NOFORMAT, NOINIT,  NAME = N'PHANACEY_DB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10 ";


                Command = new SqlCommand(Backup_command2, Con);

              done=  Command.ExecuteNonQuery();
                return true;
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex+"");
                return false;
            }

          
        }

        //جلب اسم السيرفر
        public static string Get_server_name()
        {
            string server_name = "";
            var registaryviewarray = new[] { RegistryView.Registry32, RegistryView.Registry64 };
            foreach (var registryview in registaryviewarray)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryview))
                using (var key = hklm.OpenSubKey(@"software\microsoft\microsoft sql server"))
                {
                    var instances = (string[])key?.GetValue("InstalledInstances");
                    if (instances != null)

                        foreach (var element in instances)
                        {
                            if (element == "MSSQLSERVER")
                            {
                                server_name = System.Environment.MachineName;
                                Properties.Settings.Default.Server_Name = server_name;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                server_name = System.Environment.MachineName + @"\" + element;
                                Properties.Settings.Default.Server_Name = server_name;
                                Properties.Settings.Default.Save();

                            }
                            //  Properties.Settings.Default.Save();
                        }

                }
            }
            return server_name;
        }
        //الاتصال بالقاعدة
        public static void Server_connection(string ser_name)
        {
            Con = new SqlConnection(@"Data Source=" + ser_name + "; Integrated Security=true;");
        }
        //إنشاء قاعدة البيانات
        public static void Create_DB(string db_name)
        {
            Command = new SqlCommand("create database " + db_name, Con);
            Command.ExecuteNonQuery();

        }
        //الاتصال بقاعدة البيانات
        public static void DB_Connection(string server_name, string db_name)
        {
            Con = new SqlConnection(@"Data Source=" + server_name + "; Initial Catalog=" + db_name + "; Integrated Security=true;");
        }
        //select
        public static DataTable Select(string sql)
        {
            string serv = Properties.Settings.Default.Server_Name;
            DB_Connection(serv, "PHANACEY_DB");
            Command = new SqlCommand(sql, Con);
            dr = Command.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            return dt;
        }
        //insert_upadte_delete
        public static int Insert_Update_Delete(string sql)
        {
            done = 0;
            Command = new SqlCommand(sql, Con);
            done = Command.ExecuteNonQuery();
            return done;
        }
        //max id
        public static string Max(string sql)
        {
            dr.Close();
            int x = 0;
            Command = new SqlCommand(sql, Con);
            dr = Command.ExecuteReader();
            while (dr.Read())
            {
                if (x < Int32.Parse(dr[0].ToString()))
                    x = Int32.Parse(dr[0].ToString());
            }

            dr.Close();
            return x.ToString();
        }


        //تنفيذ سكريبت قاعدة البيانات 
        public static bool RunSqlScriptFile(string pathStoreProceduresFile)
        {
            try
            {
                string script = File.ReadAllText(pathStoreProceduresFile);

                // split script on GO command
                System.Collections.Generic.IEnumerable<string> commandStrings = System.Text.RegularExpressions.Regex.Split(script, @"^\s*GO\s*$",
                                         RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        using (var command = new SqlCommand(commandString, Con))
                        {
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                MessageBox.Show(string.Format("Please check the SqlServer script.\nFile: {0} \nLine: {1} \nError: {2} \nSQL Command: \n{3}", pathStoreProceduresFile, ex.LineNumber, ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

   }
}
