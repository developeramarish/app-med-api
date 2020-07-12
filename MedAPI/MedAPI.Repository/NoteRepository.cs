﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class NoteRepository : INoteRepository


    {

        public List<Note> GetAllNoteByPatient(int id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from nt in context.notes
                        where nt.deleted != true && nt.patient_id == id
                        select new Note()
                        {
                            Id = nt.id,
                            Age = nt.age,
                            Completed = nt.completed,
                            Control = nt.control,
                            Diagnosis = nt.diagnosis,
                            Exam = nt.exam,
                            ModifiedBy = nt.modifiedBy,
                            PhysicalExam = nt.physicalExam,
                            SecondOpinion = nt.secondOpinion,
                            SicknessTime = nt.sicknessTime,
                            SicknessUnit = nt.sicknessUnit,
                            Specialty = nt.specialty,
                            Stage = nt.stage,
                            Story = nt.story,
                            Symptom = nt.symptom,
                            Treatment = nt.treatment,
                            ControlNoteId = nt.controlNote_id,
                            EstablishmentId = nt.establishment_id,
                            MedicId = nt.medic_id,
                            PatientId = nt.patient_id,
                            TicketId = nt.ticket_id,
                            TriageId = nt.triage_id
                        }).ToList();
            }
        }
        public bool DeleteNoteById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efNote = context.notes.Where(m => m.id == id).FirstOrDefault();
                if (efNote != null)
                {
                    efNote.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Note> GetAllNote()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from nt in context.notes
                        where nt.deleted != true
                        select new Note()
                        {
                            Id = nt.id,
                            Age = nt.age,
                            Completed = nt.completed,
                            Control = nt.control,
                            Diagnosis = nt.diagnosis,
                            Exam = nt.exam,
                            ModifiedBy = nt.modifiedBy,
                            PhysicalExam = nt.physicalExam,
                            SecondOpinion = nt.secondOpinion,
                            SicknessTime = nt.sicknessTime,
                            SicknessUnit = nt.sicknessUnit,
                            Specialty = nt.specialty,
                            Stage = nt.stage,
                            Story = nt.story,
                            Symptom = nt.symptom,
                            Treatment = nt.treatment,
                            ControlNoteId = nt.controlNote_id,
                            EstablishmentId = nt.establishment_id,
                            MedicId = nt.medic_id,
                            PatientId = nt.patient_id,
                            TicketId = nt.ticket_id,
                            TriageId = nt.triage_id
                        }).ToList();
            }
        }

        public Note GetNoteById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.notes.Where(x => x.id == id)
                   .Select(x => new Note()
                   {
                       Id = x.id,
                       Age = x.age,
                       Completed = x.completed,
                       Control = x.control,
                       Diagnosis = x.diagnosis,
                       Exam = x.exam,
                       ModifiedBy = x.modifiedBy,
                       PhysicalExam = x.physicalExam,
                       SecondOpinion = x.secondOpinion,
                       SicknessTime = x.sicknessTime,
                       SicknessUnit = x.sicknessUnit,
                       Specialty = x.specialty,
                       Stage = x.stage,
                       Story = x.story,
                       Symptom = x.symptom,
                       Treatment = x.treatment,
                       ControlNoteId = x.controlNote_id,
                       EstablishmentId = x.establishment_id,
                       MedicId = x.medic_id,
                       PatientId = x.patient_id,
                       TicketId = x.ticket_id,
                       TriageId = x.triage_id
                   }).FirstOrDefault();
            }
        }

        public Note SaveNote(Note mNote)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efNotes = context.notes.Where(m => m.id == mNote.Id).FirstOrDefault();
                if (efNotes == null)
                {
                    efNotes = new DataAccess.note();
                    efNotes.deleted = false;// BitConverter.GetBytes(false);
                    efNotes.createdDate = DateTime.UtcNow;
                    context.notes.Add(efNotes);
                }
                efNotes.age = mNote.Age;
                efNotes.completed = mNote.Completed;
                efNotes.control = mNote.Control;
                efNotes.controlNote_id = mNote.ControlNoteId;
                efNotes.createdBy = mNote.CreatedBy;
                efNotes.diagnosis = mNote.Diagnosis;
                efNotes.establishment_id = mNote.EstablishmentId;
                efNotes.exam = mNote.Exam;
                efNotes.medic_id = mNote.MedicId;
                efNotes.modifiedBy = mNote.ModifiedBy;
                efNotes.modifiedDate = mNote.ModifiedDate;
                efNotes.patient_id = mNote.PatientId;
                efNotes.physicalExam = mNote.PhysicalExam;
                efNotes.secondOpinion = mNote.SecondOpinion;
                efNotes.sicknessTime = mNote.SicknessTime;
                efNotes.sicknessUnit = mNote.SicknessUnit;
                efNotes.secondOpinion = mNote.SecondOpinion;
                efNotes.specialty = mNote.Specialty;
                efNotes.stage = mNote.Stage;
                efNotes.story = mNote.Story;
                efNotes.symptom = mNote.Symptom;
                efNotes.ticket_id = mNote.TicketId;
                efNotes.treatment = mNote.Treatment;
                efNotes.triage_id = mNote.TriageId;
                context.SaveChanges();
                mNote.Id = efNotes.id;
            }
            return mNote;
        }
    }
}
