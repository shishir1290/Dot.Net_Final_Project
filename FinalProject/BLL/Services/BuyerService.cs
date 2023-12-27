using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Services
{
    public class BuyerService
    {
        public static List<BuyerDTO> Get()
        {
            var data = DataAccessFactory.BuyerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BuyerDTO>>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static BuyerDTO Get(int id)
        {
            var data = DataAccessFactory.BuyerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BuyerDTO>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static BuyerDTO Create(BuyerDTO buyer)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Buyer>(buyer);
            var data = DataAccessFactory.BuyerData().Create(mapped);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<BuyerDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
                                            /*Login part*/
        /*------------------------------------------------------------------------------------------------*/

        public static BuyerDTO Login(BuyerDTO buyer)
        {
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyerDTO, Buyer>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Buyer>(buyer);
            var data = DataAccessFactory.BuyerData().Create(mapped);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Buyer, BuyerDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<BuyerDTO>(data);
            return mapped2;
        }


        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/


        public static void Delete(int id)
        {
            DataAccessFactory.BuyerData().Delete(id);
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static BuyerDTO Update(BuyerDTO buyer, int id)
        {
            Console.WriteLine("BuyerService.Update");

            var existingBuyer = Get(id);
            if (existingBuyer == null)
            {
                throw new Exception("Buyer not found");
            }

            var buyerToBuyerMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BuyerDTO, Buyer>();
            });

            var buyerToBuyerMapper = new Mapper(buyerToBuyerMapperConfig);

            var updatedBuyer = buyerToBuyerMapper.Map<Buyer>(buyer);

            // Update the existing buyer data by passing the Buyer object and the ID
            var updatedData = DataAccessFactory.BuyerData().Update(updatedBuyer, id);

            var buyerToBuyerDTOMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Buyer, BuyerDTO>();
            });

            var buyerToBuyerDTOMapper = new Mapper(buyerToBuyerDTOMapperConfig);

            var updatedBuyerDTO = buyerToBuyerDTOMapper.Map<BuyerDTO>(updatedData);

            return updatedBuyerDTO;
            /*return existingBuyer;*/
        }
        /*---------------------------------------------------------------------------------*/
        /*---------------------------------------------------------------------------------*/

        public static Buyer GetLoggedInUser()
        {
            return HttpContext.Current.Session["LoggedInUser"] as Buyer;
        }

    }
}
