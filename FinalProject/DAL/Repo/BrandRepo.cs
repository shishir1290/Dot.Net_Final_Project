﻿using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BrandRepo : Repos, IRepo<Brand, int, Brand>
    {
        public Brand Create(Brand obj)
        {
            db.Brands.Add(obj);
            if(db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            return db.SaveChanges() > 0;
        }

        public List<Brand> Read()
        {
            return db.Brands.ToList();
        }

        public Brand Read(int id)
        {
            var brand = db.Brands.Find(id);
            return brand;
        }

        

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<Brand> SearchByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Brand> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Brand> SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/
       
        
        public Brand Update(Brand obj, int id)
        {
            var brand = Read(id);
            if(brand != null)
            {
                brand.BrandName = obj.BrandName;
                brand.BrandDescription = obj.BrandDescription;
                db.SaveChanges();
                return brand;
            }
            return null;
        }

        public Brand ReadToken(string tokenString)
        {
            throw new NotImplementedException();
        }
    }
}
