using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Setting_Forms
{
    public partial class F_System_Setting : F_Master_Inheretanz
    {
    
        public F_System_Setting()
        {
            InitializeComponent();
            Title("System Settings \\ إعدادات البرنامج ");
            view_inheretanz_butomes(false, true, false, false, false, true, false);
        }

        public override void Insert_Data()
        {
            //Properties.Settings.Default.titel_graid_colore = colorPickEdit_graid.Color;
            //Properties.Settings.Default.titel_list_colore = colorPickEdit_list.Color;
            //Properties.Settings.Default.titel_master_color = colorPickEdit_master.Color;
            //Properties.Settings.Default.gc_row_count = Convert.ToInt32(textEdit_gc_row_count.Text);


            // Save Settings
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات بنجاح");

        }
    }
}

