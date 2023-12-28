using DAL.EF.Model;
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
    }
}
