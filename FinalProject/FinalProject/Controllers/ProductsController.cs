using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpPost]
        [Route("api/products/create")]
        public HttpResponseMessage Create(ProductsDTO product)
        {
            try
            {
                var data = ProductsService.Create(product);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

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
    }
}

