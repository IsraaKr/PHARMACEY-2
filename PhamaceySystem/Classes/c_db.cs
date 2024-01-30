using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace PhamaceySystem
{
    class c_db
    {
        //public static SqlConnection con;
        public static SqlCommand comnd;
        public static SqlDataReader dr;
        //  public static SqlDataAdapter da;
        public static DataTable dt;
        public static int done;

        public static SqlConnection _Con;
        public static SqlConnection con  //عند كل استخدام ل كون نستخدم التابع و ليس الخاصية
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
        //جلب اسم السيرفر
        public static string get_server_name()
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
        public static void server_connection(string ser_name)
        {
            con = new SqlConnection(@"Data Source=" + ser_name + "; Integrated Security=true;");
        }
        //إنشاء قاعدة البيانات
        public static void create_DB(string db_name)
        {
            comnd = new SqlCommand("create database " + db_name, con);
            comnd.ExecuteNonQuery();

        }
        //الاتصال بقاعدة البيانات
        public static void db_conection(string server_name, string db_name)
        {
            con = new SqlConnection(@"Data Source=" + server_name + "; Initial Catalog=" + db_name + "; Integrated Security=true;");
        }
        //select
        public static DataTable select(string sql)
        {
            db_conection(@".", "PHANACEY_DB");
            comnd = new SqlCommand(sql, con);
            dr = comnd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            return dt;
        }
        //insert_upadte_delete
        public static int insert_upadte_delete(string sql)
        {
            done = 0;
            comnd = new SqlCommand(sql, con);
            done = comnd.ExecuteNonQuery();
            return done;
        }
        //max id
        public static string max(string sql)
        {
            dr.Close();
            int x = 0;
            comnd = new SqlCommand(sql, con);
            dr = comnd.ExecuteReader();
            while (dr.Read())
            {
                if (x < Int32.Parse(dr[0].ToString()))
                    x = Int32.Parse(dr[0].ToString());
            }

            dr.Close();
            return x.ToString();
        }



        public static bool runSqlScriptFile(string pathStoreProceduresFile)
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
                        using (var command = new SqlCommand(commandString, con))
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

        //private bool runSqlScriptFile(string pathStoreProceduresFile, string connectionString)
        //{
        //    try
        //    {
        //        string script = File.ReadAllText(pathStoreProceduresFile);

        //        // split script on GO command
        //        System.Collections.Generic.IEnumerable<string> commandStrings = System.Text.RegularExpressions.Regex.Split(script, @"^\s*GO\s*$",
        //                                 RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            foreach (string commandString in commandStrings)
        //            {
        //                if (commandString.Trim() != "")
        //                {
        //                    using (var command = new SqlCommand(commandString, connection))
        //                    {
        //                        try
        //                        {
        //                            command.ExecuteNonQuery();
        //                        }
        //                        catch (SqlException ex)
        //                        {
        //                            string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
        //                            MessageBox.Show(string.Format("Please check the SqlServer script.\nFile: {0} \nLine: {1} \nError: {2} \nSQL Command: \n{3}", pathStoreProceduresFile, ex.LineNumber, ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                            return false;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //}
    }
}
