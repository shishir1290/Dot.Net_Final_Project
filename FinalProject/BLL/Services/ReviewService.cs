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
    public class ReviewService
    {
        public static ReviewDTO Create(ReviewDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Review>(obj);
            var data = DataAccessFactory.ReviewData().Create(mapped);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<ReviewDTO>(data);
            return mapped2;
        }

        public static ReviewDTO Get(int id)
        {
            var data = DataAccessFactory.ReviewData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ReviewDTO>(data);
            return mapped;
        }

        public static List<ReviewDTO> Get()
        {
            var data = DataAccessFactory.ReviewData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ReviewDTO>>(data);
            return mapped;
        }

        public static ReviewDTO Update(Review obj, int id)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReviewDTO, Review>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Review>(obj);
            var data = DataAccessFactory.ReviewData().Update(mapped, id);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<ReviewDTO>(data);
            return mapped2;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ReviewData().Delete(id);
        }
    }
}
