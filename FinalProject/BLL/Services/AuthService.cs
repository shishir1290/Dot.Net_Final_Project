using DAL;
using DAL.EF.Model;
using System;
using System.Web;

namespace BLL.Services
{
    public class AuthService
    {
        public static Buyer Authenticate(string email, string password)
        {
            var data = DataAccessFactory.AuthData().Authenticate(email, password);

            return data;
        }
    }
}
