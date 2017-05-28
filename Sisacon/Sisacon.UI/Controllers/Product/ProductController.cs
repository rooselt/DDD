using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : BaseController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [Route("product")]
        public HttpResponseMessage Save(ProductViewModel productViewModel)
        {
            var response = new ResponseMessage<Product>();

            try
            {
                if (ModelState.IsValid)
                {
                    var product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                    response = _productAppService.SaveOrUpdate(product);
                }
                else
                {
                    response = response.createInvalidResponse();
                }
            }
            catch
            {
                response = response.createErrorResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("product")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new ResponseMessage<Product>();

            response = _productAppService.DeleteProduct(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("product")]
        public HttpResponseMessage GetProductById(int id)
        {
            var response = new ResponseMessage<Product>();

            response = _productAppService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("product")]
        public HttpResponseMessage GetProductByUserId(int userId)
        {
            var response = new ResponseMessage<Product>();

            response = _productAppService.GetProductByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
