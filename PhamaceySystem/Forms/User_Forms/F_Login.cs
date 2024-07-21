using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.User_Forms
{
    public partial class F_Login : Form
    {
        public F_Login()
        {
            InitializeComponent();
            Colores();
        }
        public void Colores()
        {
            panel2.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_login.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_cancel.BackColor = Properties.Settings.Default.titel_master_colore;
            btn_new_user.BackColor = Properties.Settings.Default.titel_master_colore;

        }


    }
}
