using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace BLL.Services
{
    public class ProductsService
    {
        public static ProductsDTO Create(ProductsDTO product)
        {
            // Map DTO to Entity
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductsDTO, Products>();
            });
            var mapper = new Mapper(cfg);
            var entity = mapper.Map<Products>(product);

            // Handle image upload
            if (product.ImageFile != null && product.ImageFile.ContentLength > 0)
            {
                // Generate a unique filename or use other strategies as needed
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(product.ImageFile.FileName);
                var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/"), fileName);

                // Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.ImageFile.InputStream.CopyTo(fileStream);
                }

                // Set the image path in the entity
                entity.ImagePath = "/Uploads/" + fileName;
            }

            // Call repository to save the entity
            var data = DataAccessFactory.ProductsData().Create(entity);

            // Map Entity back to DTO
            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<ProductsDTO>(data);

            return mapped2;
        }




        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static ProductsDTO Get(int id)
        {
            var data = DataAccessFactory.ProductsData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductsDTO>(data);
            return mapped;
        }

        /*------------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static List<ProductsDTO> Get()
        {
            var data = DataAccessFactory.ProductsData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductsDTO>>(data);
            return mapped;
        }

        public static ProductsDTO Update(ProductsDTO product, int id)
        {
            var existing = DataAccessFactory.ProductsData().Read(id);
            if (existing == null)
            {
                throw new Exception("Products not found");
            }

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductsDTO, Products>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Products>(product);
            var data = DataAccessFactory.ProductsData().Update(mapped, id);

            var cfg2 = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper2 = new Mapper(cfg2);
            var mapped2 = mapper2.Map<ProductsDTO>(data);
            return mapped2;
        }

        /*------------------------------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------*/

        public static ProductsDTO Delete(int id)
        {
            var existing = DataAccessFactory.ProductsData().Read(id);
            if (existing == null)
            {
                throw new Exception("Products not found");
            }

            DataAccessFactory.ProductsData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductsDTO>(existing);
            return mapped;
        }

        /*----------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------*/
        public static ProductsDTO Search(string name)
        {
            var data = DataAccessFactory.ProductsData().SearchByName(name);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductsDTO>(data);
            return mapped;
        }

        /*----------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------*/

        public static ProductsDTO SearchByCategory(int categoryId)
        {
            var data = DataAccessFactory.ProductsData().SearchByCategory(categoryId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductsDTO>(data);
            return mapped;
        }



        /*----------------------------------------------------------------------------------------------*/
        /*----------------------------------------------------------------------------------------------*/

        public static ProductsDTO SearchByBrand(int brandId)
        {
            var data = DataAccessFactory.ProductsData().SearchByBrand(brandId);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Products, ProductsDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductsDTO>(data);
            return mapped;
        }
    }
}
