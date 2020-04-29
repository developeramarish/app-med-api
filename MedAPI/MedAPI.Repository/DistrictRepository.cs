﻿using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Repository
{
   public class DistrictRepository: IDistrictRepository
    {
        public List<District> GetAllDistrict()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from c in context.districts
                        where c.deleted != bytes
                        select new District()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            ProvinceId=c.province_id,
                            Ubigeo=c.ubigeo,
                        }).OrderBy(x => x.Name).ToList();
            }
        }
        public District SaveDistrict(District mDistrict)
        {
           var bytes= BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efDisrict = context.districts.Where(m => m.id == mDistrict.Id && m.deleted!= bytes).FirstOrDefault();
                if (efDisrict == null)
                {
                    efDisrict = new DataAccess.district();
                    efDisrict.deleted = BitConverter.GetBytes(false);
                    context.districts.Add(efDisrict);
                }
                efDisrict.name = mDistrict.Name;
                efDisrict.province_id = mDistrict.ProvinceId;
                efDisrict.ubigeo = mDistrict.Ubigeo;
                context.SaveChanges();
                mDistrict.Id= efDisrict.id;
            }
            return mDistrict;
        }
        public District GetDistrictById(long id)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.districts.Where(x => x.id == id && x.deleted != bytes)
                   .Select(x => new District()
                   {
                       Id = x.id,
                       Name = x.name,
                       Deleted = x.deleted,
                       ProvinceId=x.province_id,
                       Ubigeo=x.ubigeo
                   }).FirstOrDefault();
            }
        }
        public bool DeleteDistrictById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efDistricts = context.districts.Where(m => m.id == id).FirstOrDefault();
                if (efDistricts != null)
                {
                    efDistricts.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
    }
}