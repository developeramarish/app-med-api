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
    
    public partial class note_notemedicine
    {
        public long id { get; set; }
        public long note_id { get; set; }
        public long medicineList_id { get; set; }
    
        public virtual note note { get; set; }
        public virtual notemedicine notemedicine { get; set; }
    }
}
