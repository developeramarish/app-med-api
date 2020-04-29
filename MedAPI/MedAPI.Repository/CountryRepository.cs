﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public Country GetByName(string name)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.countries.Where(x => x.name == name)
                   .Select(x => new Country()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       Departments = x.departments.Select(c => new Department()
                       {
                           country_id = c.country_id,
                           id = c.id,
                           name = c.name,
                           deleted = c.deleted
                       }).ToList()
                   }).FirstOrDefault();
            }
        }
        public List<Country> GetAllCountry()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from c in context.countries
                        where c.deleted != bytes
                        select new Country()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            Departments = c.departments.Select(x=>new Department()
                            {
                                country_id=x.country_id,
                                id=x.id,
                                name=x.name,
                                deleted=x.deleted
                            }).ToList()
                            
                        }).OrderBy(x => x.name).ToList();
            }
        }
        public Country GetCountryById(long id)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.countries.Where(x => x.id == id && x.deleted != bytes)
                   .Select(x => new Country()
                   {
                       id = x.id,
                       name = x.name,
                       Departments = x.departments.Select(c => new Department()
                       {
                           country_id = c.country_id,
                           id = c.id,
                           name = c.name,
                           deleted = c.deleted
                       }).ToList(),
                       deleted = x.deleted,

                   }).FirstOrDefault();
            }
        }
        public bool DeleteCountryById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efCountries = context.countries.Where(m => m.id == id).FirstOrDefault();
                if (efCountries != null)
                {
                    efCountries.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
        public Country SaveCountry(Country mCountry)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efCountries = context.countries.Where(m => m.id == mCountry.id).FirstOrDefault();
                if (efCountries == null)
                {
                    efCountries = new DataAccess.country();
                    efCountries.deleted= BitConverter.GetBytes(false);
                    context.countries.Add(efCountries);
                }
                efCountries.name = mCountry.name;
                context.SaveChanges();
                mCountry.id = efCountries.id;
            }
            return mCountry;
        }
    }
}
