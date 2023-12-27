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
    public class BuyerController : ApiController
    {
        [HttpGet]
        [Route("api/buyer")]
        public HttpResponseMessage Buyers()
        {
            try
            {
                var data = BuyerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/buyer/signup")]
        public HttpResponseMessage Create(BuyerDTO buyer)
        {
            try
            {
                var data = BuyerService.Create(buyer);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/buyer/login")]
        public HttpResponseMessage Login(BuyerDTO buyer)
        {
            try
            {
                var data = BuyerService.Login(buyer);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/buyer/{id}")]
        public HttpResponseMessage Buyer(int id)
        {
            try
            {
                var data = BuyerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/buyer/update/{id}")]
        public HttpResponseMessage Update(BuyerDTO buyer, int id)
        {
            try
            {
                var data = BuyerService.Update(buyer, id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/buyer/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                BuyerService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Buyer deleted successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
