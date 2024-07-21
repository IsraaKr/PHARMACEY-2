using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamaceySystem.Classes
{
    public class C_Local_User
    {
        public static int Id { get; set; }
        public static string UserId { get; set; }

        public static string FullName { get; set; }
        public static string UserName { get; set; }
        public static string PassWord { get; set; }
        public static string Role { get; set; }//الصلاحية العامة
        public static bool IsSecondaryUser { get; set; }
    
        public static DateTime CreatedDate { get; set; }
        public static DateTime EditedDate { get; set; }

        //Navication

  
    }
}
