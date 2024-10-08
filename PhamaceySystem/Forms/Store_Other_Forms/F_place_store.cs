﻿using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;
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
    public partial class F_place_store : F_Master_Inheretanz
    {
        public F_place_store()
        {
            InitializeComponent();
            Title("Store Places ,  مواقع التخزين ");
            txt_name.Text = "اسم الموقع ";
            view_inheretanz_butomes(false, true, false, true, true, false, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = "Store Places ,  مواقع التخزين ";
        ClsCommander<T_Store_Placees> cmdStorePalces = new ClsCommander<T_Store_Placees>();
        T_Store_Placees TF_Store_Places;
        Boolean Is_Double_Click = false;

        public override void Title(string s_title)
        {
            base.Title(s_title);
        }
        public override void Get_Data(string status_mess)
        {
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdStorePalces = new ClsCommander<T_Store_Placees>();
                TF_Store_Places = cmdStorePalces.Get_All().FirstOrDefault();
                if (TF_Store_Places != null)
                    Fill_Graid();

                base.Get_Data(status_mess);
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
            // }
        }
        public override void Insert_Data()
        {
            try
            {
                if (Validate_Data())
                {
                    TF_Store_Places = new T_Store_Placees();
                    Fill_Entitey();
                    cmdStorePalces.Insert_Data(TF_Store_Places);
                    C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  باسم {TF_Store_Places.name} ");

                    base.Insert_Data();
                    Get_Data("i");
                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            
                cmdStorePalces.Detached_Data(TF_Store_Places);
            }

        }
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (Validate_Data() && gv.RowCount > 0 && TF_Store_Places != null)
                    {

                        Fill_Entitey();
                        cmdStorePalces.Update_Data(TF_Store_Places);
                        C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  باسم {TF_Store_Places.name} ");

                        base.Update_Data();
                        Get_Data("u");
                    }
                }
                else
                    C_Master.Warning_Massege_Box("يجب اختيار عنصر من الجدول لتعديله");
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
              
                cmdStorePalces.Detached_Data(TF_Store_Places);
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
                            foreach (int row_id in gv.GetSelectedRows())
                            {
                                Get_Row_ID(row_id);
                                cmdStorePalces.Delete_Data(TF_Store_Places);
                                C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  باسم {TF_Store_Places.name} ");

                            }
                        base.Delete_Data();
                        Get_Data("d");

                    }
                }
                else
                    C_Master.Warning_Massege_Box("  بالضغط مرتين يجب اختيار عنصر من الجدول لحذفه");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exception.FK_Exception))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
                Get_Data("");
                cmdStorePalces.Detached_Data(TF_Store_Places);
            }

        }

        public override bool Validate_Data()
        {
            int number_of_errores = 0;

            number_of_errores += txt_name.is_text_valid() ? 0 : 1;
            number_of_errores += txt_id.is_text_valid() ? 0 : 1;
            return (number_of_errores == 0);

        }



        public override void clear_data(Control.ControlCollection s_controls)
        {
            base.clear_data(s_controls);
            Set_Auto_Id();
        }
        public override void Print_Data()
        {
            base.Print_Data();
        }
        public void Fill_Controls()
        {
            txt_id.Text = TF_Store_Places.id.ToString();
            txt_name.Text = TF_Store_Places.name;
            txt_group.Text = TF_Store_Places.groupe;
            txt_shuffel.Text = TF_Store_Places.shufel;
        }
        public void Fill_Entitey()
        {

            TF_Store_Places.name = txt_name.Text.Trim();
            TF_Store_Places.groupe = txt_group.Text.Trim();
            TF_Store_Places.shufel = txt_shuffel.Text.Trim();
        }
        private void Fill_Graid()
        {
            Object x = new object();
            x = (from Emp_s in cmdStorePalces.Get_All()
                 select new
                 {
                     id = Emp_s.id,
                     name = Emp_s.name,
                     grou = Emp_s.groupe,
                     shuf = Emp_s.shufel
                 }).OrderBy(c_id => c_id.name);
            gc.DataSource = x;
            gv.Columns["id"].Visible = false;
            gv.Columns["name"].Caption = "الاسم";
            gv.Columns[2].Caption = "المجموعة";
            gv.Columns[3].Caption = "الرف";

            if (gv.Columns[1].Summary.Count == 0)
                gv.Columns[1].Summary.Add(DevExpress.Data.SummaryItemType.Count, "name", "عدد المواد = {0}");

        }
        private void Set_Auto_Id()
        {
            var Max_Id = cmdStorePalces.Get_All().Where(c_id => c_id.id
                                 == cmdStorePalces.Get_All().Max(max => max.id)).FirstOrDefault();
            txt_id.Text = Max_Id == null ? "1" : (Max_Id.id + 1).ToString();


        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Store_Places = cmdStorePalces.Get_By(c_id => c_id.id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Store_Places = cmdStorePalces.Get_By(c_id => c_id.id == id).FirstOrDefault();
            }
        }
        public  void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_Store_Places != null)
                Fill_Controls();
        }
        public  void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }

        public void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }

        private void txt_group_EditValueChanged(object sender, EventArgs e)
        {
            txt_name.Text = txt_group.Text.Trim() + "-" + txt_shuffel.Text.Trim();
        }

        private void txt_shuffel_EditValueChanged(object sender, EventArgs e)
        {
            txt_name.Text = txt_group.Text.Trim() + "-" + txt_shuffel.Text.Trim();
        }

        private void txt_name_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Insert_Data();
            //if (e.KeyCode == Keys.F2)
            //    new();
            if (e.KeyCode == Keys.Delete)
                Delete_Data();
            if (e.KeyCode == Keys.Escape)
                clear_data(this.Controls);
        }

        private void F_place_store_Load(object sender, EventArgs e)
        {
            Get_Data("");
        }
    }
}
