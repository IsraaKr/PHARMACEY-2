using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PhamaceySystem.Classes
{
    public class C_Add_System_record
    {
        public static void Add(string table , string op , string desecription)
        {
            ClsCommander<T_System_Record> cmdSystemRecord = new ClsCommander<T_System_Record>();

            T_System_Record TF_System_Record = new T_System_Record
            {
                created_date = DateTime.Now,
                desicriptio = desecription,
                tableName = table, 
                op_name = op,
                Tiltle  = op + " " +  table ,
                Device_name = Environment.UserName,
                Full_name = C_Local_User.FullName,
                User_id = C_Local_User.Id,
                Mac_Id = getMachinId()

            };
            cmdSystemRecord.Insert_Data(TF_System_Record);
        }
        private static string getMachinId()
        {
            var networkingInterface = NetworkInterface.GetAllNetworkInterfaces();
            string machin_id = string.Empty;
            foreach (var item in networkingInterface)
            {
                if (item.OperationalStatus == OperationalStatus.Up
                    && item.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                   && item.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    machin_id = item.GetPhysicalAddress().ToString();
                }
                if (machin_id == string.Empty)
                {
                    machin_id = "null";
                }
            }
            return machin_id;
        }
    }
}
