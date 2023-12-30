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
    public class SendMailController : ApiController
    {
        [HttpPost]
        [Route("api/sendmail")]
        public HttpResponseMessage Verify(string code, string email)
        {
            try
            {
                var data = SendMailService.Verify(email, code);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
