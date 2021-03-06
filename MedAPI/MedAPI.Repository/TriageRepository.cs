﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Linq;
namespace MedAPI.Repository
{
    public class TriageRepository : ITriageRepository
    {
        public Triage GetLatest(long id)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from tr in context.triages
                        where tr.deleted != false && tr.patient_id == id
                        select new Triage
                        {
                            abdominalPerimeter = tr.abdominalPerimeter,
                            bmi = tr.bmi,
                            breathingRate = tr.breathingRate,
                            createdBy = tr.createdBy,
                            createdDate = tr.createdDate,
                            deleted = tr.deleted,
                            deposition = tr.deposition,
                            diastolicBloodPressure = tr.diastolicBloodPressure,
                            glycemia = tr.glycemia,
                            hdlCholesterol = tr.hdlCholesterol,
                            heartRate = tr.heartRate,
                            heartRisk = tr.heartRisk,
                            hunger = tr.hunger,
                            hypertensionRisk = tr.hypertensionRisk,
                            id = tr.id,
                            ldlCholesterol = tr.ldlCholesterol,
                            modifiedBy = tr.modifiedBy,
                            modifiedDate = tr.modifiedDate,
                            patientId = tr.patient_id,
                            size = tr.size,
                            sleep = tr.sleep,
                            systolicBloodPressure = tr.systolicBloodPressure,
                            temperature = tr.temperature,
                            thirst = tr.thirst,
                            ticketId = tr.ticket_id,
                            totalCholesterol = tr.totalCholesterol,
                            urine = tr.urine,
                            weight = tr.weight,
                            weightEvolution = tr.weightEvolution
                        }).FirstOrDefault();
            }
        }

        public Triage SaveTriage(Triage triage)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efTriages = context.triages.Where(m => m.id == triage.id).FirstOrDefault();
                if (efTriages == null)
                {
                    efTriages = new DataAccess.triage();
                    efTriages.createdDate = DateTime.UtcNow;
                    efTriages.deleted = false;// BitConverter.GetBytes(false);
                    context.triages.Add(efTriages);
                }
                efTriages.abdominalPerimeter = triage.abdominalPerimeter;
                efTriages.bmi = triage.bmi;
                efTriages.breathingRate = triage.breathingRate;
                efTriages.createdBy = triage.createdBy;
                efTriages.deposition = triage.deposition;
                efTriages.diastolicBloodPressure = triage.diastolicBloodPressure;

                efTriages.glycemia = triage.glycemia;

                efTriages.hdlCholesterol = triage.hdlCholesterol;
                efTriages.heartRate = triage.heartRate;
                efTriages.heartRisk = triage.heartRisk;
                efTriages.hunger = triage.hunger;
                efTriages.hypertensionRisk = triage.hypertensionRisk;
                efTriages.ldlCholesterol = triage.ldlCholesterol;
                efTriages.modifiedBy = triage.modifiedBy;
                efTriages.modifiedDate = triage.modifiedDate;
                efTriages.patient_id = triage.patientId;
                efTriages.size = triage.size;
                efTriages.sleep = triage.sleep;
                efTriages.systolicBloodPressure = triage.systolicBloodPressure;
                efTriages.temperature = triage.temperature;
                efTriages.thirst = triage.thirst;
                efTriages.ticket_id = triage.ticketId;
                efTriages.totalCholesterol = triage.totalCholesterol;
                efTriages.urine = triage.urine;
                efTriages.weight = triage.weight;
                efTriages.weightEvolution = triage.weightEvolution;
                context.SaveChanges();
                triage.id = efTriages.id;
            }
            return triage;
        }
    }
}


