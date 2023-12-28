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
    public class CategoryService
    {
        public static CategoryDTO Create(CategoryDTO category)
        {
            category.CreatedAt = DateTime.Now;
            var cfg = new MapperConfiguration(c => c.CreateMap<CategoryDTO, Category>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Category>(category);
            var data = DataAccessFactory.CategoryData().Create(mapped);

            var cfg2 = new MapperConfiguration(c => c.CreateMap<Category, CategoryDTO>());
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<CategoryDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Read();
            var cfg = new MapperConfiguration(c => c.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CategoryDTO>>(data);
            return mapped;
        }

        public static CategoryDTO Get(int id)
        {
            var data = DataAccessFactory.CategoryData().Read(id);
            var cfg = new MapperConfiguration(c => c.CreateMap<Category, CategoryDTO>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CategoryDTO>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/

        public static CategoryDTO Update(CategoryDTO category, int id)
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<CategoryDTO, Category>());
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Category>(category);
            var data = DataAccessFactory.CategoryData().Update(mapped, id);

            var cfg2 = new MapperConfiguration(c => c.CreateMap<Category, CategoryDTO>());
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<CategoryDTO>(data);
            return mapped2;
        }

        /*-----------------------------------------------------------------------------------------------------*/
       /*-----------------------------------------------------------------------------------------------------*/
       public static bool Delete(int id)
       {
           return DataAccessFactory.CategoryData().Delete(id);
       }
    }
}
