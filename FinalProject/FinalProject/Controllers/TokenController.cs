using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalProject.Controllers
{
    public class TokenController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpGet]
        [Route("api/token/{TokenString}")]
        public HttpResponseMessage Get(string TokenString)
        {
            try
            {
                var data = TokenService.Get(TokenString);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
