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
    
    public partial class T_Store_Move
    {
        public int id { get; set; }
        public Nullable<int> qunt { get; set; }
        public Nullable<int> med_id { get; set; }
        public Nullable<int> item_id { get; set; }
        public Nullable<int> op_id { get; set; }
        public Nullable<int> op_type_id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string time { get; set; }
        public Nullable<int> place_id { get; set; }
        public Nullable<int> reciver_id { get; set; }
        public Nullable<int> donar_id { get; set; }
        public Nullable<int> emp_id { get; set; }
    
        public virtual T_Medician T_Medician { get; set; }
        public virtual T_OPeration_Type T_OPeration_Type { get; set; }
    }
}
