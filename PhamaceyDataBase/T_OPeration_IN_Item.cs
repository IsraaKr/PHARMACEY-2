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
    
    public partial class T_OPeration_IN_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_OPeration_IN_Item()
        {
            this.T_OPeration_Out_Item = new HashSet<T_OPeration_Out_Item>();
        }
    
        public int in_item_id { get; set; }
        public Nullable<int> in_item_quntity { get; set; }
        public Nullable<System.DateTime> in_item_expDate { get; set; }
        public string in_B_It_note { get; set; }
        public Nullable<int> Med_id { get; set; }
        public int In_op_id { get; set; }
        public Nullable<int> store_place_id { get; set; }
        public Nullable<bool> is_out { get; set; }
        public Nullable<int> out_item_quntitey { get; set; }
    
        public virtual T_Medician T_Medician { get; set; }
        public virtual T_OPeration_IN T_OPeration_IN { get; set; }
        public virtual T_Store_Placees T_Store_Placees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_OPeration_Out_Item> T_OPeration_Out_Item { get; set; }
    }
}
