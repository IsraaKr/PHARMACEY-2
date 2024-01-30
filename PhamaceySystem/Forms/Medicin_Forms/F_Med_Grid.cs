using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem;
using PhamaceySystem.Inheratenz_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Medicin_Forms
{
    public partial class F_Med_Grid : F_Master_Graid
    {
        public F_Med_Grid()
        {
            InitializeComponent();
            Title("الأدوية");
       
        }
        ClsCommander<T_Medician> cmdMedician = new ClsCommander<T_Medician>();


        T_Medician TF_Medician;
        Boolean Is_Double_Click = false;
        int id;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdMedician = new ClsCommander<T_Medician>();
                TF_Medician = cmdMedician.Get_All().FirstOrDefault();
                if (TF_Medician != null)
                    Fill_Graid();
                base.Get_Data(status_mess);

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString() + "/" + ex.Message);
            }

        }
        public override void neew()
        {
            try
            {
                F_Med f = new F_Med();
                f.ShowDialog();
                Get_Data("");
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    F_Med f = new F_Med(id);
                    f.ShowDialog();
                    Get_Data("");
                }
                else
                    C_Master.Warning_Massege_Box("الرجاء اختيار عنصر لتعديله");

            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }


        }
        public override void Delete_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (C_Master.Qustion_Massege_Box(C_Master.mas_del) == DialogResult.Yes)
                    {
                        if (gv.RowCount > 0)
                        {
                            foreach (int row_id in gv.GetSelectedRows())
                            {
                                Get_Row_ID(row_id);
                                cmdMedician.Delet_Data(TF_Medician);
                            }
                            base.Delete_Data();
                            Get_Data("d");
                        }
                    }
                    else
                        C_Master.Warning_Massege_Box("الرجاء اختيار عنصر من الجدول لحذفه");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exeption.FK_Exeption))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
        public override void clear_data(Control.ControlCollection s_controls)
        {
            base.clear_data(s_controls);
         
        }
        public override void Print_Data()
        {
            base.Print_Data();
            C_Master.print_header("الأدوية" , gc);
        }

        public override bool Validate_Data()
        {
            int number_of_errores = 0;
        

            return (number_of_errores == 0);
        }

        private void Fill_Graid()
        {
            gc.DataSource = (from med in cmdMedician.Get_All()
                             select new
                             {
                                 id = med.med_id,
                                 code = med.med_code,
                                 name = med.med_name,
                                 min = med.med_minimum,
                                 cat_id = med.T_Med_Category.med_cat_id,
                                 categorey = med.T_Med_Category.med_cat_name,
                                 shape_id = med.T_Med_Shape.med_shape_id,
                                 shape = med.T_Med_Shape.med_shape_name,
                             }).OrderBy(l_id => l_id.id);

            gv.Columns["id"].Visible = false;
            gv.Columns["code"].Caption = "الكود";
            gv.Columns["name"].Caption = "الاسم";
            gv.Columns["min"].Caption = "الحد الأدنى ";
            gv.Columns[4].Visible = false;
            gv.Columns[5].Caption = "التصنيف ";
            gv.Columns[6].Visible = false;
            gv.Columns[7].Caption = "الشكل ";

            gv.BestFitColumns();
        }
    
        private void Get_Row_ID(int Row_Id)
        {
           
            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]));
                TF_Medician = cmdMedician.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]));
                TF_Medician = cmdMedician.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
          //  if (TF_Medician != null)
               // Fill_Controls();
        }

        public override void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }
        public override void gv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }
    }
}
