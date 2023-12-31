using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class SellerRepo : Repos, IRepo<Sellers, int, Sellers>, IAuth<Sellers>
    {
        public Sellers Authenticate(string email, string password)
        {
            var data = db.Sellers.Where(b => b.Email == email && b.Password == password).FirstOrDefault();
            if (data != null)
                return data;
            return null;
        }

        public Sellers Create(Sellers obj)
        {
            db.Sellers.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Sellers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Sellers> Read()
        {
            var data = db.Sellers.ToList();
            return data;
        }

        public Sellers Read(int id)
        {
            var data = db.Sellers.Find(id);
            return data;
        }

        public Sellers Update(Sellers obj, int id)
        {
            var ex = Read(id);
            if(ex != null)
            {
                ex.Name = obj.Name;
                ex.StoreName = obj.StoreName;
                ex.Address = obj.Address;
                ex.Password = obj.Password;

                return ex;
            }
            return null;
        }


        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public object SearchByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public object SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public object SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
