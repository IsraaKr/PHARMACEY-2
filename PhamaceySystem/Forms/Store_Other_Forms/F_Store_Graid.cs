using DevExpress.Data;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Forms.Medicin_Forms;
using PhamaceySystem.Forms.Store_Forms;
using PhamaceySystem.Forms.Store_OP_Forms;
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

namespace PhamaceySystem.Forms.Store_Other_Forms
{
    public partial class F_Store_Graid : F_Master_Graid
    {
        public F_Store_Graid()
        {
            InitializeComponent();
            Title(tit);
            this.Text = tit;
            view_inheretanz_butomes(false, false, false, false, false, true, true);

        }
        public string tit = "الأدوية في المستودع";

        ClsCommander<T_Medician> cmdMed = new ClsCommander<T_Medician>();
        ClsCommander<T_Med_Shape> cmdShape = new ClsCommander<T_Med_Shape>();

        T_Medician TF_Med;
        Boolean Is_Double_Click = false;
        int id;
     //   int row_to_show;
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdMed = new ClsCommander<T_Medician>();
                TF_Med = cmdMed.Get_All().FirstOrDefault();
                if (TF_Med != null)
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
                                cmdMed.Delete_Data(TF_Med);

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
            C_Master.print_header(tit, gc);
        }

        public override bool Validate_Data()
        {
            int number_of_errores = 0;


            return (number_of_errores == 0);
        }


        private void Fill_Graid()
        {
            var data = (from med in cmdMed.Get_All()
                        join shape in cmdShape.Get_All()
                          on med.med_shape_id equals shape.med_shape_id into slist

                        from sss in slist.DefaultIfEmpty()
                        select new
                        {
                            id = med.med_id,
                            code = med.med_code,
                            name = med.med_name,
                            shape = sss.med_shape_name,
                            min = med.med_minimum,
                            in_count = med.med_in_count,
                            out_count = med.med_out_count,
                            dam_count = med.med_dam_count,
                            total = med.med_total_now

                        }).OrderBy(l_id => l_id.id).ToList();
        
            //جلب جزء من البيانات
            if (data != null && data.Count > 0)
            {

                gc.DataSource = data;

                gv_column_names();

            }
        }

        private void gv_column_names()
        {
            gv.Columns[0].Visible = false;
            gv.Columns[1].Caption = "الكود";
            gv.Columns[2].Caption = "الاسم";
            gv.Columns[3].Caption = "الشكل";

            gv.Columns[4].Caption = "الحد الأدنى";
            gv.Columns[5].Caption = "الإدخال";
            gv.Columns[6].Caption = "الإخراج";
            gv.Columns[7].Caption = "الإتلاف";
            gv.Columns[8].Caption = "الكمية المتوفرة";

            gv.BestFitColumns();

            gv.Columns[4].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[4].DisplayFormat.FormatString = "N0";

            gv.Columns[5].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[5].DisplayFormat.FormatString = "N0";

            gv.Columns[6].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[6].DisplayFormat.FormatString = "N0";

            gv.Columns[7].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[7].DisplayFormat.FormatString = "N0";

            gv.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gv.Columns[8].DisplayFormat.FormatString = "N0";

        }

        private void Get_Row_ID(int Row_Id)
        {

            if (Row_Id != 0)
            {
                id = Convert.ToInt32(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Med = cmdMed.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Med = cmdMed.Get_By(c_id => c_id.med_id == id).FirstOrDefault();
            }
        }

        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);

            Get_Row_ID(0);
            //  if (TF_OPeration_IN != null)
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

        private void barBut_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            F_In_Op f = new F_In_Op();
            f.ShowDialog();
        }

        private void barBut_out_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            F_Out_Op f = new F_Out_Op();
            f.ShowDialog();
        }

        private void barBut_dam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            F_Dameg_Op f = new F_Dameg_Op();
                f.Show();
        }

        private void F_Store_Graid_Load(object sender, EventArgs e)
        {
            view_inheretanz_butomes(true, false, false, true, true, true ,true);

        }
    }
}