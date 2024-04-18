using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamaceySystem.Classes
{
    class C_Regestery
    {
        public void make_reg_key()
        {
            RegistryKey skin_name = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
            skin_name.SetValue("skin_name", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString());
            skin_name.Close();

            Properties.Settings.Default.theme = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString();
        }
        public void get_reg_key_value()
        {
            RegistryKey skin_name = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WINREGISTRY");
            if (skin_name != null)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skin_name.GetValue("skin_name").ToString();
            }
            if (Properties.Settings.Default.theme !="...")
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default.theme;
            }
        }
    }
}