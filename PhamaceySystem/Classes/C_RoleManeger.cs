using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamaceySystem.Classes
{
    public static class C_RoleManeger
    {
        private static Dictionary<string, Boolean> RoleList = new Dictionary<string, Boolean>();

        public static void Register_role(String Key , Boolean Val)
        {
            RoleList.Add(Key, Val);
        }
        public static bool GetRole(String Key)
        {
            if (Key==null || Key ==string.Empty || RoleList.Count<=0)
            {
                return true;
            }
            else 
           return RoleList[Key];
        }
        public static void ClearRole()
        {
            RoleList.Clear();
        }
    }
}
