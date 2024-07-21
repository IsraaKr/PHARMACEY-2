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

namespace PhamaceySystem.Forms.User_Forms
{
    public partial class F_User_Add : F_Master_Inheretanz
    {
        public F_User_Add()
        {
            InitializeComponent();
            view_inheretanz_butomes(true, true, false, true, true, true, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = "Users , المستخدمين ";


        ClsCommander<T_Users> cmdUsers = new ClsCommander<T_Users>();
        ClsCommander<T_Roles> cmdRoles = new ClsCommander<T_Roles>();
        T_Users TF_Users;
        Boolean Is_Double_Click = false;

        public override void Title(string s_title)
        {
            base.Title(s_title);
        }
        public override void Get_Data(string status_mess)
        {
            //if (TF_Users != null)
            //{
            try
            {
                clear_data(this.Controls);
                Is_Double_Click = false;
                cmdUsers = new ClsCommander<T_Users>();
                cmdRoles = new ClsCommander<T_Roles>();
                TF_Users = cmdUsers.Get_All().FirstOrDefault();
                if (TF_Users != null)
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
                    TF_Users = new T_Users();
                    Fill_Entitey();
                    cmdUsers.Insert_Data(TF_Users);
                    base.Insert_Data();
                    Get_Data("i");

                    //done and add user  roles
                    foreach (var item in per_Group.Items)
                    {
                        CheckBox checkBox = item as CheckBox;
                        //set role
                        T_Roles roles = new T_Roles
                        {
                            keyy = checkBox.Name,
                            value = checkBox.Checked,
                            User_Id = TF_Users.Id
                        };
                        //send role
                        cmdRoles.Insert_Data(roles);
                    }
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
                    if (Validate_Data() && gv.RowCount > 0 && TF_Users != null)
                    {

                        Fill_Entitey();
                        cmdUsers.Update_Data(TF_Users);
                        base.Update_Data();
                        Get_Data("u");
                      //var oldRoles = cmdRoles.Get_All().Where(l => l.User_Id.ToString() == IdTextEdit.Text).ToList();

                      //  foreach (var item in oldRoles)
                      //  {
                      //      cmdRoles.Delete_Data(item);
                      //  }
                       
                      //           //done and add user  roles
                      //  foreach (var item in per_Group.Items)
                      //  {
                      //      CheckBox checkBox = item as CheckBox;
                      //      //set role
                      //      T_Roles roles = new T_Roles
                      //      {
                      //          keyy = checkBox.Name,
                      //          value = checkBox.Checked,
                      //          User_Id = TF_Users.Id
                      //      };
                      //      //send role
                      //      cmdRoles.Insert_Data(roles);
                      //  }
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
                                cmdUsers.Delete_Data(TF_Users);
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

            number_of_errores += Full_NameTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += user_nameTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += pass_wordTextEdit.is_text_valid() ? 0 : 1;
            number_of_errores += RoleTextEdit.is_text_valid() ? 0 : 1;

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
            IdTextEdit.Text = TF_Users.Id.ToString();
            Full_NameTextEdit.Text = TF_Users.Full_Name;
            user_nameTextEdit.Text = TF_Users.user_name;
            pass_wordTextEdit.Text = TF_Users.pass_word;
            RoleTextEdit.Text = TF_Users.Role;
          
        }
        public void Fill_Entitey()
        {

            TF_Users.Full_Name = Full_NameTextEdit.Text.Trim();
            TF_Users.user_name = user_nameTextEdit.Text.Trim();
            TF_Users.pass_word = pass_wordTextEdit.Text.Trim();
            TF_Users.Role = RoleTextEdit.Text.Trim();
            TF_Users.is_secondery =true;
            TF_Users.cerated_date = DateTime.Now;
            TF_Users.updated_date = DateTime.Now;


        }
        private void Fill_Graid()
        {
            Object x = new object();
            x = (from Emp_s in cmdUsers.Get_All()
                 select new
                 {
                     id = Emp_s.Id,
                     name = Emp_s.Full_Name,
                     username = Emp_s.user_name,
                     pass = Emp_s.pass_word,
                     rol = Emp_s.Role,
                     create = Emp_s.cerated_date,
                     update = Emp_s.updated_date,

                 }).OrderBy(c_id => c_id.name);
            gc.DataSource = x;
            gv.Columns["id"].Visible = false;
            gv.Columns[1].Caption = "الاسم الكامل";
            gv.Columns[2].Caption = "اسم المستخدم";
            gv.Columns[3].Caption = "كلمة المرور";
            gv.Columns[4].Caption = "الصلاحية";
            gv.Columns[5].Caption = "تاريخ الإنشاء ";
            gv.Columns[6].Caption = "تاريخ التعديل ";


            gv.BestFitColumns();
            gv.OptionsView.ShowFooter = true;

            if (gv.Columns[1].Summary.Count == 0)

                gv.Columns[1].Summary.Add(DevExpress.Data.SummaryItemType.Count, gv.Columns[1].FieldName.ToString(), "العدد = {0}");

        }
        private void Set_Auto_Id()
        {
            var Max_Id = cmdUsers.Get_All().Where(c_id => c_id.Id
                                 == cmdUsers.Get_All().Max(max => max.Id)).FirstOrDefault();
            IdTextEdit.Text = Max_Id == null ? "1" : (Max_Id.Id + 1).ToString();


        }
        private void Get_Row_ID(int Row_Id)
        {
            long id;
            if (Row_Id != 0)
            {
                id = Convert.ToInt64(gv.GetRowCellValue(Row_Id, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Users = cmdUsers.Get_By(c_id => c_id.Id == id).FirstOrDefault();
            }
            else
            {
                id = Convert.ToInt64(gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns[0]).ToString().Replace(",", string.Empty));
                TF_Users = cmdUsers.Get_By(c_id => c_id.Id == id).FirstOrDefault();
            }
        }
        public  void gv_DoubleClick(object sender, EventArgs e)
        {
            Is_Double_Click = true;
            gv.SelectRow(gv.FocusedRowHandle);
            Get_Row_ID(0);
            if (TF_Users != null)
                Fill_Controls();
        }
        public  void gv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && gv.RowCount > 0)
                Delete_Data();
        }

        public  void gv_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Is_Double_Click = true;
        }

        private void RoleTextEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoleTextEdit.SelectedIndex == 0)
            {
                per_in.Checked = true;
                per_out.Checked = true;
                per_dam.Checked = true;
                per_med.Checked = true;
                per_thwabet.Checked = true;
                per_rep.Checked = true;
                per_sysRecord.Checked = true;
                per_seting.Checked = true;
                per_Users.Checked = true;
                per_Db.Checked = true;
                per_save.Checked = true;
                per_edite.Checked = true;
                per_delete.Checked = true;
                per_print.Checked = true;

            }
            if (RoleTextEdit.Text == "مستخدم قراءة")
            {
                per_in.Checked = false;
                per_out.Checked = false;
                per_dam.Checked = false;
                per_med.Checked = false;
                per_thwabet.Checked = false;
                per_rep.Checked = true;
                per_sysRecord.Checked = false;
                per_seting.Checked = false;
                per_Users.Checked = false;
                per_Db.Checked = false;
                per_save.Checked = false;
                per_edite.Checked = false;
                per_delete.Checked = false;
                per_print.Checked = true;

            }
            if (RoleTextEdit.Text == "مستخدم قراءة و كتابة")
            {
                per_in.Checked = true;
                per_out.Checked = true;
                per_dam.Checked = true;
                per_med.Checked = true;
                per_thwabet.Checked = true;
                per_rep.Checked = true;
                per_sysRecord.Checked = false;
                per_seting.Checked = false;
                per_Users.Checked = false;
                per_Db.Checked = false;
                per_save.Checked = true;
                per_edite.Checked = false;
                per_delete.Checked = false;
                per_print.Checked = true;

            }
            if (RoleTextEdit.Text == "مخصص")
            {
                per_in.Checked = false;
                per_out.Checked = false;
                per_dam.Checked = false;
                per_med.Checked = false;
                per_thwabet.Checked = false;
                per_rep.Checked = false;
                per_sysRecord.Checked = false;
                per_seting.Checked = false;
                per_Users.Checked = false;
                per_Db.Checked = false;
                per_save.Checked = false;
                per_edite.Checked = false;
                per_delete.Checked = false;
                per_print.Checked = false;

            }
        }
    }
}

