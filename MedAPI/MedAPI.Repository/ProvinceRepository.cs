﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class ProvinceRepository : IProvinceRepository
    {

        public List<Province> GetAllProvinceByName(string name)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from c in context.provinces
                        where c.name.ToLower().Contains(name.ToLower())
                        select new Province()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            DepartmentId = c.department_id,
                        }).ToList();
            }
        }
        public List<Province> GetAllProvinceByDeparmentId(long departmentId)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from c in context.provinces
                        where c.department_id == departmentId && c.deleted != true
                        select new Province()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            DepartmentId = c.department_id,
                        }).OrderBy(x => x.Name).ToList();
            }
        }

        public List<Province> GetAllProvince()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from c in context.provinces
                        where c.deleted != true
                        select new Province()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            DepartmentId = c.department_id,
                        }).OrderBy(x => x.Name).ToList();
            }
        }

        public Province SaveProvince(Province mProvince)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efProvince = context.provinces.Where(m => m.id == mProvince.Id && m.deleted != true).FirstOrDefault();
                if (efProvince == null)
                {
                    efProvince = new DataAccess.province();
                    efProvince.deleted = false;// BitConverter.GetBytes(false);
                    context.provinces.Add(efProvince);
                }
                efProvince.name = mProvince.Name;
                efProvince.department_id = mProvince.DepartmentId;
                context.SaveChanges();
                mProvince.Id = efProvince.id;
            }
            return mProvince;
        }

        public Province GetProvinceById(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.provinces.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Province()
                   {
                       Id = x.id,
                       Name = x.name,
                       Deleted = x.deleted,
                       DepartmentId = x.department_id
                   }).FirstOrDefault();
            }
        }
        public bool DeleteProvinceById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efprovinces = context.provinces.Where(m => m.id == id).FirstOrDefault();
                if (efprovinces != null)
                {
                    efprovinces.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
    }
}
