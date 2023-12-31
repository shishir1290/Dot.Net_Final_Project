using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalProject.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Create(CategoryDTO category)
        {
            try
            {
                var data = CategoryService.Create(category);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Category(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/category")]
        public HttpResponseMessage Category()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPatch]
        [Route("api/category/update/{id}")]
        public HttpResponseMessage Update(CategoryDTO category, int id)
        {
            try
            {
                var data = CategoryService.Update(category, id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CategoryService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Category deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
