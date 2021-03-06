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
    
    public partial class note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public note()
        {
            this.cardiovascularnotes = new HashSet<cardiovascularnote>();
            this.notediagnosis = new HashSet<notediagnosi>();
            this.noteexams = new HashSet<noteexam>();
            this.notemedicines = new HashSet<notemedicine>();
            this.notereferrals = new HashSet<notereferral>();
        }
    
        public long id { get; set; }
        public string age { get; set; }
        public bool completed { get; set; }
        public bool control { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public bool deleted { get; set; }
        public string diagnosis { get; set; }
        public string exam { get; set; }
        public string modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
        public string physicalExam { get; set; }
        public string secondOpinion { get; set; }
        public Nullable<long> sicknessTime { get; set; }
        public string sicknessUnit { get; set; }
        public string specialty { get; set; }
        public Nullable<long> stage { get; set; }
        public string story { get; set; }
        public string symptom { get; set; }
        public string treatment { get; set; }
        public Nullable<long> user_id { get; set; }
        public Nullable<long> establishment_id { get; set; }
        public Nullable<long> medic_id { get; set; }
        public long patient_id { get; set; }
        public Nullable<long> ticket_id { get; set; }
        public Nullable<long> triage_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cardiovascularnote> cardiovascularnotes { get; set; }
        public virtual establishment establishment { get; set; }
        public virtual medic medic { get; set; }
        public virtual patient patient { get; set; }
        public virtual ticket ticket { get; set; }
        public virtual triage triage { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notediagnosi> notediagnosis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<noteexam> noteexams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notemedicine> notemedicines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notereferral> notereferrals { get; set; }
    }
}
