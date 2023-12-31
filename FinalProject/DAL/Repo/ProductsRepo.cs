using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{

    internal class ProductsRepo : Repos, IRepo<Products, int, Products>
    {

        public Products Create(Products obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Products.Remove(ex);
            return db.SaveChanges() > 0;
        }

        /*-------------------------------------------------------------------------------------*/

        /*-------------------------------------------------------------------------------------*/


        public List<Products> Read()
        {
            return db.Products.ToList();
        }

        public Products Read(int id)
        {
            return db.Products.Find(id);
        }

        public Products ReadToken(string tokenString)
        {
            throw new NotImplementedException();
        }

        /*----------------------------------------------------------------------------------------------*/

        public List<Products> SearchByBrand(int brandId)
        {
            List<Products> result = db.Products.Where(p => p.BrandId == brandId).ToList();
            return result;
        }


        public List<Products> SearchByCategory(int categoryId)
        {
            List<Products> result = db.Products.Where(p => p.CategoryId == categoryId).ToList();
            return result;
        }

        public List<Products> SearchByName(string name)
        {
            List<Products> result = db.Products.Where(p => p.ProductName.Contains(name)).ToList();
            return result;
        }

        public Products Update(Products obj, int id)
        {
            var ex = Read(id);
            if(ex != null)
            {
                ex.ProductName = obj.ProductName;
                ex.Price = obj.Price;
                ex.Description = obj.Description;
                ex.CategoryId = obj.CategoryId;
                ex.BrandId = obj.BrandId;
                ex.Quantity = obj.Quantity;
                return ex;
            }
            if (db.SaveChanges() > 0)
                return ex;
            return null;

        }

        
    }
}
