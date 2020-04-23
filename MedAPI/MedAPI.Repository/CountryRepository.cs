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
                       departments = x.departments,
                       users = x.users
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
                            departments = c.departments
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
                       departments = x.departments,
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

