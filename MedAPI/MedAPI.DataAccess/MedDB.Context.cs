﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class registroclinicoEntities : DbContext
    {
        public registroclinicoEntities()
            : base("name=registroclinicoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cardiovascularnote> cardiovascularnotes { get; set; }
        public virtual DbSet<cardiovascularnote_cardiovascularsymptoms> cardiovascularnote_cardiovascularsymptoms { get; set; }
        public virtual DbSet<chapter> chapters { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<diagnosi> diagnosis { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<establishment> establishments { get; set; }
        public virtual DbSet<exam> exams { get; set; }
        public virtual DbSet<medic> medics { get; set; }
        public virtual DbSet<medic_specialties> medic_specialties { get; set; }
        public virtual DbSet<medicine> medicines { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<note_notediagnosis> note_notediagnosis { get; set; }
        public virtual DbSet<note_noteexam> note_noteexam { get; set; }
        public virtual DbSet<note_notemedicine> note_notemedicine { get; set; }
        public virtual DbSet<note_notereferral> note_notereferral { get; set; }
        public virtual DbSet<notediagnosi> notediagnosis { get; set; }
        public virtual DbSet<noteexam> noteexams { get; set; }
        public virtual DbSet<noteexam_upload> noteexam_upload { get; set; }
        public virtual DbSet<notemedicine> notemedicines { get; set; }
        public virtual DbSet<notereferral> notereferrals { get; set; }
        public virtual DbSet<nurse> nurses { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<patient_allergies> patient_allergies { get; set; }
        public virtual DbSet<patient_fatherbackgrounds> patient_fatherbackgrounds { get; set; }
        public virtual DbSet<patient_medicines> patient_medicines { get; set; }
        public virtual DbSet<patient_motherbackgrounds> patient_motherbackgrounds { get; set; }
        public virtual DbSet<patient_personalbackgrounds> patient_personalbackgrounds { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<triage> triages { get; set; }
        public virtual DbSet<upload> uploads { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<nurse_specialties> nurse_specialties { get; set; }
        public virtual DbSet<role_permissions> role_permissions { get; set; }
    }
}
