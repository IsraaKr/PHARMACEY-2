﻿using System;
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

            view_inheretanz_butomes(false, true, false, false, false, false , true);
            Title(tit);
            this.Text = tit;
        }
        public string tit = "System Settings \\ إعدادات البرنامج ";

        public override void Insert_Data()
        {

            Properties.Settings.Default.titel_master_colore = colorPickEdit_master.Color;
           // Properties.Settings.Default.gc_row_count = Convert.ToInt32(textEdit_gc_row_count.Text);
            Properties.Settings.Default.is_med_count_not_show = Convert.ToBoolean(ch_show_med_min_not.CheckState);
            Properties.Settings.Default.is_med_count_form_show = Convert.ToBoolean(ch_show_med_min_form.CheckState);
            Properties.Settings.Default.is_expdate_not_show = Convert.ToBoolean(ch_show_exp_date_not.CheckState);
            Properties.Settings.Default.is_expdate_form_show = Convert.ToBoolean(ch_show_exp_date_form.CheckState);

            // Save Settings
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات بنجاح");

        }
        public override void Get_Data(string status_mess)
        {
            load_setting_data();
            base.Get_Data(status_mess);
        }

        private void load_setting_data()
        {
            colorPickEdit_master.Color = Properties.Settings.Default.titel_master_colore;
            //textEdit_gc_row_count.Text = Properties.Settings.Default.gc_row_count.ToString();
            ch_show_med_min_not.Checked = Properties.Settings.Default.is_med_count_not_show;
            ch_show_med_min_form.Checked = Properties.Settings.Default.is_med_count_form_show;
            ch_show_exp_date_not.Checked = Properties.Settings.Default.is_expdate_not_show;
            ch_show_exp_date_form.Checked = Properties.Settings.Default.is_expdate_form_show;

        }
    }
}

