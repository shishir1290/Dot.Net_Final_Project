using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SellerService
    {
        public static SellerDTO Create(SellerDTO seller)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Sellers>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Sellers>(seller);
            var data = DataAccessFactory.SellersData().Create(mapped);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Sellers, SellerDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<SellerDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static SellerDTO Get(int id)
        {
            var data = DataAccessFactory.SellersData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sellers, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerDTO>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static List<SellerDTO> Get()
        {
            var data = DataAccessFactory.SellersData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sellers, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SellerDTO>>(data);
            return mapped;
        }

        public static SellerDTO Update(SellerDTO seller, int id)
        {
            var existing = DataAccessFactory.SellersData().Read(id);
            if (existing == null)
            {
                throw new Exception("Seller not found");
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Sellers>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Sellers>(seller);
            var data = DataAccessFactory.SellersData().Update(mapped, id);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Sellers, SellerDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<SellerDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------*/

        public static SellerDTO Delete(int id)
        {
            var existing = DataAccessFactory.SellersData().Read(id);
            if (existing == null)
            {
                throw new Exception("Seller not found");
            }

            DataAccessFactory.SellersData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Sellers, SellerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerDTO>(existing);
            return mapped;
        }
    }
}
