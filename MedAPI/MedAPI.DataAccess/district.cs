//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class district
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public district()
        {
            this.users = new HashSet<user>();
        }
    
        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public Nullable<long> ubigeo { get; set; }
        public long province_id { get; set; }
    
        public virtual province province { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
