using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class SellerController : ApiController
    {
        [HttpPost]
        [Route("api/seller/create")]
        public HttpResponseMessage Create(SellerDTO seller)
        {
            try
            {
                var data = SellerService.Create(seller);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/seller/{id}")]
        public HttpResponseMessage Seller(int id)
        {
            try
            {
                var data = SellerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/seller")]
        public HttpResponseMessage Seller()
        {
            try
            {
                var data = SellerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        [Route("api/seller/update/{id}")]
        public HttpResponseMessage Update(SellerDTO seller, int id)
        {
            try
            {
                var data = SellerService.Update(seller, id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/seller/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SellerService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Seller deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
