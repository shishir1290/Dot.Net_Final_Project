using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string password)
        {
            var authenticationResult = DataAccessFactory.AuthData().Authenticate(email, password);

            if (authenticationResult != null)
            {
                Token token = DataAccessFactory.TokenData().Read(email);

                if (token != null)
                {
                    UpdateToken(token, email);
                }
                else
                {
                    token = CreateToken(email);
                }

                if (token != null)
                {
                    var mapper = CreateMapper();
                    return mapper.Map<TokenDTO>(token);
                }
            }

            return null;
        }

        private static void UpdateToken(Token token, string email)
        {
            token.CreateDate = DateTime.Now;
            token.ExpireDate = DateTime.Now.AddMinutes(1);
            token.TokenString = Guid.NewGuid().ToString();
            var updatedToken = DataAccessFactory.TokenData().Update(token, email);
            // You may want to add additional error handling logic here if needed
        }

        private static Token CreateToken(string email)
        {
            var token = new Token
            {
                BuyerId = email,
                SellerId = email,
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMinutes(1),
                TokenString = Guid.NewGuid().ToString()
            };

            var createdToken = DataAccessFactory.TokenData().Create(token);
            // You may want to add additional error handling logic here if needed
            return createdToken;
        }

        private static IMapper CreateMapper()
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<Token, TokenDTO>());
            return new Mapper(cfg);
        }
    }
}
