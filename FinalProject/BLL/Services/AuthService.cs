using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Web;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string password)
        {
            var res = DataAccessFactory.AuthData().Authenticate(email, password);
            if (res != null)
            {
                var token = new Token();
                token.BuyerId = email;
                token.SellerId = email;
                token.CreateDate = DateTime.Now;
                token.TokenString = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => c.CreateMap<Token, TokenDTO>());
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }
                
            }

            return null;
        }
    }
}
