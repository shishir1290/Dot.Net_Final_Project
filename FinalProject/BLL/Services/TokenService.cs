using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService
    {
        public static TokenDTO Get(string tokenString)
        {
            var data = DataAccessFactory.TokenData().ReadToken(tokenString);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Token, TokenDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TokenDTO>(data);
            return mapped;
        }
    }
}
