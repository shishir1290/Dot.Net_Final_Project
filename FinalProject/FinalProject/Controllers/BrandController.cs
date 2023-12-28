using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class BrandController : ApiController
    {
        [HttpPost]
        [Route("api/brand/create")]
        public HttpResponseMessage Create(BrandDTO brand)
        {
            try
            {
                var data = BrandService.Create(brand);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/brand/{id}")]
        public HttpResponseMessage Brand(int id)
        {
            try
            {
                var data = BrandService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/brand")]
        public HttpResponseMessage Brand()
        {
            try
            {
                var data = BrandService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        [Route("api/brand/update/{id}")]
        public HttpResponseMessage Update(BrandDTO brand, int id)
        {
            try
            {
                var data = BrandService.Update(brand, id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/brand/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                BrandService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Brand deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
