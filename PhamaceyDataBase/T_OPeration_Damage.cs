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
    
    public partial class T_OPeration_Damage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_OPeration_Damage()
        {
            this.T_Operation_Damage_Item = new HashSet<T_Operation_Damage_Item>();
        }
    
        public int dam_OP_id { get; set; }
        public Nullable<System.DateTime> dam_op_date { get; set; }
        public Nullable<System.TimeSpan> dam_op_time { get; set; }
        public string dam_op_text { get; set; }
        public Nullable<bool> dam_op_state { get; set; }
        public Nullable<int> med_count { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<int> op_type_id { get; set; }
        public Nullable<int> In_op_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Operation_Damage_Item> T_Operation_Damage_Item { get; set; }
        public virtual T_OPeration_IN T_OPeration_IN { get; set; }
        public virtual T_OPeration_Type T_OPeration_Type { get; set; }
        public virtual T_Pers_Emploee T_Pers_Emploee { get; set; }
    }
}
