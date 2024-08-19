using PhamaceyDataBase;
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

namespace PhamaceySystem.Forms.User_Forms
{
    public partial class F_Change_Pass : F_Master_Inheretanz
    {
        public F_Change_Pass()
        {
            InitializeComponent();
            view_inheretanz_butomes(false, false, false, true, false, false, true);

            Title(tit);
            this.Text = tit;
        }
        public string tit = " تغير كلمة سر المستخدم ";


        ClsCommander<T_Users> cmdUsers = new ClsCommander<T_Users>();
        T_Users TF_Users;
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
                cmdUsers = new ClsCommander<T_Users>();
                TF_Users = cmdUsers.Get_All().Where(l=>l.Id ==C_Local_User.Id).FirstOrDefault();
              
                base.Get_Data(status_mess);
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
            
                    if (Validate_Data() )
                    {
                    if (textEdit_New_Pass.Text.Trim() == textEdi_New_pass_2.Text.Trim())
                    {

                        Fill_Entitey();
                        cmdUsers.Update_Data(TF_Users);
                        C_Add_System_record.Add(tit, "تعديل", $" تم تعديل {tit}  باسم {TF_Users.Full_Name} ");


                        base.Update_Data();
                        Get_Data("u");
                    }
                    }
                
            }
            catch (Exception ex)
            {
                Get_Data(ex.InnerException.InnerException.ToString());
            }
        }
     
        public override bool Validate_Data()
        {
            int number_of_errores = 0;

            number_of_errores += textEdit_Old_pass.is_text_valid() ? 0 : 1;
            number_of_errores += textEdit_New_Pass.is_text_valid() ? 0 : 1;
            number_of_errores += textEdi_New_pass_2.is_text_valid() ? 0 : 1;

            return (number_of_errores == 0);

        }
     
     
        public void Fill_Entitey()
        {

            //TF_Users.Full_Name = Full_NameTextEdit.Text.Trim();
            //TF_Users.user_name = user_nameTextEdit.Text.Trim();
            TF_Users.pass_word =C_Master. SHA512(textEdit_New_Pass.Text.Trim());
            //TF_Users.Role = RoleTextEdit.Text.Trim();
            //TF_Users.is_secondery = true;
            TF_Users.updated_date = DateTime.Now;

        }

        private void textEdi_New_pass_2_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit_New_Pass.Text.Trim() != textEdi_New_pass_2.Text.Trim())
            {              
               textEdi_New_pass_2.ErrorText = "عدم تطابق بين الكلمات";
            }
        }
    }
}
