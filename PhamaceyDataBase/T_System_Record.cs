//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhamaceyDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_System_Record
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Device_name { get; set; }
        public string Mac_Id { get; set; }
        public string Tiltle { get; set; }
        public string desicriptio { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public int User_id { get; set; }
    
        public virtual T_Users T_Users { get; set; }
    }
}