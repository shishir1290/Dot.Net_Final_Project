using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BuyerRepo : Repos, IRepo<Buyer, int, Buyer> , IAuth<Buyer>
    {
        public Buyer Authenticate(string email, string password)
        {
            var data = db.Buyers.Where(b => b.EmailAddress == email && b.Password == password).FirstOrDefault();
            if (data != null)
                return data;
            return null;
        }

        public Buyer Create(Buyer obj)
        {
            db.Buyers.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Buyers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Buyer Login(Buyer obj)
        {
            var ex = db.Buyers.Where(b => b.EmailAddress == obj.EmailAddress && b.Password == obj.Password).FirstOrDefault();
            if(ex != null)
                return ex;
            return null;

        }

        public List<Buyer> Read()
        {
            return db.Buyers.ToList();
        }

        public Buyer Read(int id)
        {
            return db.Buyers.Find(id);
        }

        public Buyer Update(Buyer obj, int id)
        {
            var ex = Read(id);

            if (ex != null)
            {
                // Update properties excluding the primary key
                ex.Name = obj.Name;
                ex.EmailAddress = obj.EmailAddress;
                ex.PhoneNumber = obj.PhoneNumber;
                ex.Address = obj.Address;
                ex.Gender = obj.Gender;
                // ... (update other properties)

                if (db.SaveChanges() > 0)
                    return ex;
            }

            return null;
        }

    }
}
