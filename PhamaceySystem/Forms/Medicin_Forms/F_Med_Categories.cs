﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using PhamaceySystem.Classes;

namespace PhamaceySystem.Forms.Medicin_Forms
{
    public partial class F_Med_Categories : F_Master_List
    {
        public F_Med_Categories()
        {
            InitializeComponent();
           
       
            txt.Text = "اسم التصنيف ";
            Title(tit);
            this.Text = tit;
        }
        public string tit = "Categoreys , تصنيفات الدواء ";
        ClsCommander<T_Med_Category> cmdMedCat = new ClsCommander<T_Med_Category>();
        T_Med_Category TF_Med_Cat;
        Boolean Is_Double_Click = false;

        public override void Title(string s_title)
        {
            base.Title(s_title);
        }
        public override void Get_Data(string status_mess)
        {
            //if (TF_Med_Cat != null)
            //{
                try
                {
                    clear_data(this.Controls);
                    Is_Double_Click = false;
                cmdMedCat = new ClsCommander<T_Med_Category>();
                TF_Med_Cat = cmdMedCat.Get_All().FirstOrDefault();
                if (TF_Med_Cat != null)
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
                    TF_Med_Cat = new T_Med_Category();
                    Fill_Entitey();
                    cmdMedCat.Insert_Data(TF_Med_Cat);

                    C_Add_System_record.Add(tit, "إضافة", $" تم إضافة {tit}  باسم {TF_Med_Cat.med_cat_name} ");

                    base.Insert_Data();
                    Get_Data("i");
                }
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
              
                cmdMedCat.Detached_Data(TF_Med_Cat);
            }

        }
        public override void Update_Data()
        {
            try
            {
                if (Is_Double_Click)
                {
                    if (Validate_Data() && gv.RowCount > 0 && TF_Med_Cat != null)
                    {
                   
                        Fill_Entitey();
                        cmdMedCat.Update_Data(TF_Med_Cat);
                        C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  باسم {TF_Med_Cat.med_cat_name} ");

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
     
                cmdMedCat.Detached_Data(TF_Med_Cat);
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
                                cmdMedCat.Delete_Data(TF_Med_Cat);
                                C_Add_System_record.Add(tit, "حذف", $" تم حذف {tit}  باسم {TF_Med_Cat.med_cat_name} ");

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
                if (ex.InnerException.InnerException.ToString().Contains(C_Exception.FK_Exception))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else         
                  Get_Data(ex.InnerException.InnerException.ToString());
                Get_Data("");
                cmdMedCat.Detached_Data(TF_Med_Cat);
            }

        }

        public override bool Validate_Data()
        {
            int number_of_errores = 0;
       
            number_of_errores += txt_name.is_text_valid() ? 0 : 1;
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
            txt_id.Text = TF_Med_Cat.med_cat_id.ToString();
            txt_name.Text = TF_Med_Cat.med_cat_name;

        }
        public void Fill_Entitey()
        {
          //  TF_Med_Cat.med_cat_id = Convert.ToInt32(txt_id.Text);

            TF_Med_Cat.med_cat_name = txt_name.Text.Trim();
        

        }
        private void Fill_Graid()
        {
            gc.DataSource = (from Emp_s in cmdMedCat.Get_All()
                             select new
                             {
                                 id = Emp_s.med_cat_id,
                                 name = Emp_s.med_cat_name,               
                             }).OrderBy(c_id => c_id.id).ToList();

            gv.Columns["id"].Visible = false;
            gv.Columns["name"].Caption = "اسم التصنيف";

            gv.OptionsView.ShowFooter = true;
            if (gv.Columns[1].Summary.Count == 0)
     
                gv.Columns[1].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[1].FieldName.ToString(), "العدد = {0}");

            gv.BestFitColumns();
        }
        private void Set_Auto_Id()
        {
            var Max_Id = cmdMedCat.Get_All().Where(c_id => c_id.med_cat_id == cmdMedCat.Get_All().Max(max => max.med_cat_id)).FirstOrDefault();
            txt_id.Text = Max_Id == null ? "1" : (Max_Id.med_cat_id + 1).ToString();


        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Med_Cat = cmdMedCat.Get_By(c_id => c_id.med_cat_id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Med_Cat = cmdMedCat.Get_By(c_id => c_id.med_cat_id == id).FirstOrDefault();
            }
        }
        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_Med_Cat != null)
                Fill_Controls();
        }
        public override void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }

        public override void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }
    }
}
