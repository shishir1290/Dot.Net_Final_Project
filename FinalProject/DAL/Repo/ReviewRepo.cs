using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ReviewRepo : Repos, IRepo<Review, string, Review>
    {
        public Review Create(Review obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Review> Read()
        {
            return db.Reviews.ToList();
        }

        public Review Read(string id)
        {
            return db.Reviews.Find(id);
        }

        public Review Update(Review obj, string id)
        {
            var ex = Read(id);
            if(ex != null)
            {
                ex.Comment = obj.Comment;
                ex.Rating = obj.Rating;
                ex.Date = obj.Date;

                return ex;
            }
            return null;
        }
    }
}
