using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Classes
{
   public class C_GC_Page_Nav
    {
        //يستدعى عند جلب الداتا إلى الغريد فيو
        public static void fill_combo_page_num(int list_count, ComboBox combo)
        {
            int row_to_show = Properties.Settings.Default.gc_row_count;
            combo.Items.Clear();
            double value = Convert.ToDouble(list_count) / Convert.ToDouble(row_to_show);
            var page_num = (int)Math.Round(value, MidpointRounding.AwayFromZero);
            for (int i = 0; i < page_num; i++)
            {
                combo.Items.Add(i);
            }
        }
        //يستدعى ضمن حدث تغير قيمة الكومبو بوكس
        public static int combo_gc_data(ComboBox combo )
        {
            int row_to_show = Properties.Settings.Default.gc_row_count;
            int index = combo.SelectedIndex;
            int index_of_row = index * row_to_show;
            return index_of_row;
        }
    }
}
