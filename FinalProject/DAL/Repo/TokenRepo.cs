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
            throw new NotImplementedException();
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenString.Equals(id));

        }

        public Token Update(Token obj, string id)
        {
            var token = Read(obj.TokenString);
            db.Entry(token).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0)
                return token;
            return null;
        }
    }
}
