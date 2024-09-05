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
//private void SetRoles()
//{

//    if (!C_RoleManeger.GetRole("per_in"))
//    {
//        btn_in_op.Enabled = false;

//    }
//    if (!C_RoleManeger.GetRole("per_out"))
//    {
//        btn_out_op.Enabled = false;


//    }
//    if (!C_RoleManeger.GetRole("per_dam"))
//    {
//        btn_dam_op.Enabled = false;

//    }
//    if (!C_RoleManeger.GetRole("per_med"))
//    {
//        btn_add_med.Enabled = false;

//    }
//    if (!C_RoleManeger.GetRole("per_thwabet"))
//    {
//    }
//    if (!C_RoleManeger.GetRole("per_rep"))
//    {

//    }
//    if (!C_RoleManeger.GetRole("per_sysRecord"))
//    {

//    }
//    if (!C_RoleManeger.GetRole("per_seting"))
//    {

//    }
//    if (!C_RoleManeger.GetRole("per_Users"))
//    {

//    }
//    if (!C_RoleManeger.GetRole("per_Db"))
//    {

//    }
//    if (!C_RoleManeger.GetRole("per_Db"))
//    {

//    }

//    if (!C_RoleManeger.GetRole("per_save"))
//    {

//    }

//    if (!C_RoleManeger.GetRole("per_delete"))
//    {

//    }

//    if (!C_RoleManeger.GetRole("per_edite"))
//    {

//    }

//    if (!C_RoleManeger.GetRole("per_print"))
//    {

//    }
//}
