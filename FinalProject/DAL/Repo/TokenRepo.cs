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
    internal class TokenRepo : Repos, IRepo<Token, int, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(int id)
        {
            return db.Tokens.FirstOrDefault(t => t.BuyerId.Equals(id));

        }

        public Token ReadToken(string Token)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenString.Equals(Token));
        }


        public Token Update(Token obj, int id)
        {
            var token = Read(id);
            if(token != null)
            {
                db.Entry(token).CurrentValues.SetValues(obj);
                if(db.SaveChanges() > 0)
                    return token;
            }
            
            return null;
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

        public List<Token> SearchByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Token> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Token> SearchByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
