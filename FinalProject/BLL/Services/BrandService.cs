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
    public class BrandService
    {
        public static BrandDTO Create(BrandDTO brand)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BrandDTO, Brand>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Brand>(brand);
            var data = DataAccessFactory.BrandData().Create(mapped);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<BrandDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static List<BrandDTO> Get()
        {
            var data = DataAccessFactory.BrandData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BrandDTO>>(data);
            return mapped;
        }

        public static BrandDTO Get(int id)
        {
            var data = DataAccessFactory.BrandData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BrandDTO>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static BrandDTO Update(BrandDTO brand, int id)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BrandDTO, Brand>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Brand>(brand);
            var data = DataAccessFactory.BrandData().Update(mapped, id);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Brand, BrandDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<BrandDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static bool Delete(int id)
        {
            return DataAccessFactory.BrandData().Delete(id);
        }
    }
}
