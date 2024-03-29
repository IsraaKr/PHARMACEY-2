using PhamaceyDataBase;
using PhamaceyDataBase.Commander;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamaceySystem.Forms.Person_Forms
{
    public partial class F_Reciver : F_Master_List
    {
        public F_Reciver()
        {
            InitializeComponent();
    
            txt.Text = "اسم المستلم ";
            Title(tit);
            this.Text = tit;
        }
        public string tit = "Recivers , المستملين ";


        ClsCommander<T_Pers_Recivers> cmdReciver = new ClsCommander<T_Pers_Recivers>();
        T_Pers_Recivers TF_Pers_reciver;
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
                cmdReciver = new ClsCommander<T_Pers_Recivers>();
                TF_Pers_reciver = cmdReciver.Get_All().FirstOrDefault();
                if (TF_Pers_reciver != null)
                    Fill_Graid();

                base.Get_Data(status_mess);
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }

        }
        public override void Insert_Data()
        {
            try
            {
                if (Validate_Data())
                {
                    TF_Pers_reciver = new T_Pers_Recivers();
                    Fill_Entitey();
                    cmdReciver.Insert_Data(TF_Pers_reciver);
                    base.Insert_Data();
                    Get_Data("i");
                }
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
                    if (Validate_Data() && gv.RowCount > 0 && TF_Pers_reciver != null)
                    {

                        Fill_Entitey();
                        cmdReciver.Update_Data(TF_Pers_reciver);
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
                                cmdReciver.Delete_Data(TF_Pers_reciver);
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
                if (ex.InnerException.InnerException.ToString().Contains(Classes.C_Exeption.FK_Exeption))
                    C_Master.Warning_Massege_Box("العنصر مرتبط مع جداول أخرى...... لا يمكن حذفه");
                else
                    Get_Data(ex.InnerException.InnerException.ToString());
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
            txt_id.Text = TF_Pers_reciver.id.ToString();
            txt_name.Text = TF_Pers_reciver.name;

        }
        public void Fill_Entitey()
        {
            //  TF_Pers_reciver.med_cat_id = Convert.ToInt32(txt_id.Text);

            TF_Pers_reciver.name = txt_name.Text.Trim();


        }
        private void Fill_Graid()
        {
            Object x = new object();
            x = (from Emp_s in cmdReciver.Get_All()
                 select new
                 {
                     id = Emp_s.id,
                     name = Emp_s.name,
                 }).OrderBy(c_id => c_id.name);
            gc.DataSource = x;
            gv.Columns["id"].Visible = false;
            gv.Columns["name"].Caption = "اسم المستلم";
            gv.BestFitColumns();
        }
        private void Set_Auto_Id()
        {
            var Max_Id = cmdReciver.Get_All().Where(c_id => c_id.id
                                 == cmdReciver.Get_All().Max(max => max.id)).FirstOrDefault();
            txt_id.Text = Max_Id == null ? "1" : (Max_Id.id + 1).ToString();


        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Pers_reciver = cmdReciver.Get_By(c_id => c_id.id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Pers_reciver = cmdReciver.Get_By(c_id => c_id.id == id).FirstOrDefault();
            }
        }
        public override void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_Pers_reciver != null)
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
