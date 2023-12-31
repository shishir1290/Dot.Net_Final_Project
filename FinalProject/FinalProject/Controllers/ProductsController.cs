using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        [Route("api/products/create")]
        public async Task<HttpResponseMessage> Create()
        {
            try
            {
                // Check if the request contains multipart/form-data
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                // Create a stream provider for setting up output streams
                var streamProvider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/Uploads/"));

                // Read the MIME multipart content using the stream provider
                await Request.Content.ReadAsMultipartAsync(streamProvider);

                // Get other form data from the request
                var formData = streamProvider.FormData;
                var productDTO = new ProductsDTO
                {
                    ProductName = formData["ProductName"],
                    Price = int.Parse(formData["Price"]),
                    Quantity = int.Parse(formData["Quantity"]),
                    Description = formData["Description"],
                    CategoryId = int.Parse(formData["CategoryId"]),
                    BrandId = int.Parse(formData["BrandId"]),
                    SellerId = int.Parse(formData["SellerId"])
                };

                // Get the file data from the stream provider
                var fileData = streamProvider.FileData.FirstOrDefault();
                if (fileData != null)
                {
                    // Instead of FileInfo, use HttpPostedFileBase
                    productDTO.ImageFile = new HttpPostedFileWrapper(HttpContext.Current.Request.Files[0]);
                }

                // Call the service method
                var data = ProductsService.Create(productDTO);

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        /*---------------------------------------------------------------------------------------------------------------*/


        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Product(int id)
        {
            try
            {
                var data = ProductsService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage Product()
        {
            try
            {
                var data = ProductsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        [Route("api/products/update/{id}")]
        public HttpResponseMessage Update(ProductsDTO product, int id)
        {
            try
            {
                var data = ProductsService.Update(product, id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/products/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProductsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Products deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/products/search/{name}")]
        public HttpResponseMessage Search(string name)
        {
            try
            {
                var data = ProductsService.Search(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/products/searchbycategory/{categoryId}")]
        public HttpResponseMessage SearchByCategory(int categoryId)
        {
            try
            {
                var data = ProductsService.SearchByCategory(categoryId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [HttpGet]
        [Route("api/products/searchbybrand/{brandId}")]
        public HttpResponseMessage SearchByBrand(int brandId)
        {
            try
            {
                var data = ProductsService.SearchByBrand(brandId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

    }
}

