using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Repo
{
    internal class TokenRepo : Repos, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(string email)
        {
            return db.Tokens.FirstOrDefault(t => t.BuyerId.Equals(email));

        }


        public Token Update(Token obj, string email)
        {
            var token = Read(email);
            if(token != null)
            {
                db.Entry(token).CurrentValues.SetValues(obj);
                if(db.SaveChanges() > 0)
                    return token;
            }
            
            return null;
        }
    }
}
