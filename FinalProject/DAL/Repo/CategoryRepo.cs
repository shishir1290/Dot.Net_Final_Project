using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryRepo : Repos, IRepo<Category, int, Category>
    {
        public Category Create(Category obj)
        {
            db.Categories.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var Category = db.Categories.Find(id);
            db.Categories.Remove(Category);
            return db.SaveChanges() > 0;
        }

        public List<Category> Read()
        {
            return db.Categories.ToList();
        }

        public Category Read(int id)
        {
            var Category = db.Categories.Find(id);
            return Category;
        }

        public Category Update(Category obj, int id)
        {
            var Category = Read(id);
            if (Category != null)
            {
                Category.CategoryName = obj.CategoryName;
                Category.CategoryDescription = obj.CategoryDescription;
                db.SaveChanges();
                return Category;
            }
            return null;
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<Category> SearchByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Category> SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Category ReadToken(string tokenString)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
