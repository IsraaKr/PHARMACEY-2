using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Report_Forms
{
    public partial class F_All_Rep : F_Master_Inheretanz
    {
        public F_All_Rep()
        {
            InitializeComponent();
        }

        /*SELECT     T_Medician.med_name, T_Store_Move.date , T_Store_Move.id
FROM         T_Store_Move INNER JOIN
                      T_Medician ON T_Store_Move.med_id = T_Medician.med_id
WHERE    ( (T_Store_Move.date =12/3/2024 ) AND (T_Store_Move.op_type_id = 1)) or ((T_Store_Move.date = '16/3/2024') AND (T_Store_Move.op_type_id = 2) )
                      or( (T_Store_Move.date =' 15/7/2024') AND (T_Store_Move.op_type_id = 3))*/
    }
}
