using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class FixedCostController : ApiController
    {
        private readonly IFixedCostAppService _fixedCostAppService;

        public FixedCostController(IFixedCostAppService fixedCostAppService)
        {
            _fixedCostAppService = fixedCostAppService;
        }

        [HttpPost]
        [Route("fixedCost")]
        public HttpResponseMessage save(FixedCostViewModel fixedCostViewModel)
        {
            var response = new ResponseMessage<FixedCost>();

            try
            {
                if(ModelState.IsValid)
                {
                    var fixedCost = Mapper.Map<FixedCostViewModel, FixedCost>(fixedCostViewModel);

                    response = _fixedCostAppService.saveOrUpdate(fixedCost);
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

        [HttpGet]
        [Route("fixedCost")]
        public HttpResponseMessage getFixedCostById(int id)
        {
            var response = new ResponseMessage<FixedCost>();

            response = _fixedCostAppService.getById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("fixedCost")]
        public HttpResponseMessage delete(int id)
        {
            var response = new ResponseMessage<FixedCost>();

            response = _fixedCostAppService.deleteFixedCost(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
