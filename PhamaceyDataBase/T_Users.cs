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
    
    public partial class T_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Users()
        {
            this.T_Roles = new HashSet<T_Roles>();
        }
    
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string user_name { get; set; }
        public string pass_word { get; set; }
        public string Role { get; set; }
        public Nullable<bool> is_secondery { get; set; }
        public Nullable<System.DateTime> cerated_date { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Roles> T_Roles { get; set; }
    }
}
