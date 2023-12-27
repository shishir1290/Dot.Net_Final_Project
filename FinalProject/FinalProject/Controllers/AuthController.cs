using BLL.Services;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public HttpResponseMessage Login(LoginMode login)
        {
            try
            {
                var res = AuthService.Authenticate(login.EmailAddress, login.Password);
                if(res != null)
                {
                    
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
