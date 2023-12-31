using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class SendMailRepo : Repos, IRepo<VerificationCode, string, VerificationCode>
    {
        public VerificationCode Create(VerificationCode obj)
        {
            db.VerificationCodes.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.VerificationCodes.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<VerificationCode> Read()
        {
            return db.VerificationCodes.ToList();
        }

        public VerificationCode Read(string id)
        {
            return db.VerificationCodes.FirstOrDefault(t => t.BuyerId.Equals(id));
        }

        public VerificationCode Update(VerificationCode obj, string id)
        {
            var code = Read(id);
            if (code != null)
            {
                db.Entry(code).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0)
                    return code;
            }
            return null;
        }


        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<VerificationCode> SearchByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<VerificationCode> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<VerificationCode> SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public VerificationCode ReadToken(string tokenString)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
