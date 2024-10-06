using PhamaceyDataBase;
using PhamaceySystem.Forms;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Report_Forms;
using PhamaceySystem.Forms.Setting_Forms;
using PhamaceySystem.Forms.Starts_Forms;
using PhamaceySystem.Forms.Store_Forms;
using PhamaceySystem.Forms.Store_OP_Forms;
using PhamaceySystem.Forms.Store_Other_Forms;
using PhamaceySystem.Forms.User_Forms;
using PhamaceySystem.Inheratenz_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            C_SqlCon.Server_Name = Properties.Settings.Default.Server_Name.ToString();
            C_SqlCon.DB_Name = Properties.Settings.Default.database.ToString();

            //  C_SqlCon.Server_Name = "ISRAA-PC\\SQLEXPRESS";

            Application.Run(new F_Login());
        }
    }
}
