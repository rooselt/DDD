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
    public class CostController : ApiController
    {
        private readonly ICostAppService _costAppService;

        public CostController(ICostAppService costAppService)
        {
            _costAppService = costAppService;
        }

        [HttpPost]
        [Route("cost")]
        public HttpResponseMessage Save(CostViewModel categoryViewModel)
        {
            var response = new ResponseMessage<Cost>();

            if (ModelState.IsValid)
            {
                try
                {
                    var Cost = Mapper.Map<CostViewModel, Cost>(categoryViewModel);

                    response = _costAppService.SaveOrUpdate(Cost);
                }
                catch
                {
                    response = response.createErrorResponse();
                }
            }
            else
            {
                response = response.createInvalidResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("cost")]
        public HttpResponseMessage GetCostsByUserId(int userId)
        {
            var response = new ResponseMessage<Cost>();

            response = _costAppService.GetCostsByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("cost")]
        public HttpResponseMessage GetCostById(int id)
        {
            var response = new ResponseMessage<Cost>();

            response = _costAppService.getById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("cost")]
        public HttpResponseMessage Delete(int costId)
        {
            var response = new ResponseMessage<Cost>();

            response = _costAppService.DeleteCost(costId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("cost/validateNewCost")]
        public HttpResponseMessage ValidateNewCost(int userId)
        {
            var response = new ResponseMessage<Cost>();

            response = _costAppService.ValidateNewCost(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("cost/getCurrentCost")]
        public HttpResponseMessage GetCurrentCost(int userId)
        {
            var response = new ResponseMessage<Cost>();

            response = _costAppService.GetCurrentCost(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
