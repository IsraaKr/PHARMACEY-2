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
    
    public partial class T_OPeration_Out_Item
    {
        public int out_item_id { get; set; }
        public Nullable<int> out_item_quntity { get; set; }
        public string out_B_It_note { get; set; }
        public Nullable<int> Med_id { get; set; }
        public int out_op_id { get; set; }
        public Nullable<int> in_item_id { get; set; }
    
        public virtual T_Medician T_Medician { get; set; }
        public virtual T_OPeration_IN_Item T_OPeration_IN_Item { get; set; }
        public virtual T_OPeration_Out T_OPeration_Out { get; set; }
    }
}
