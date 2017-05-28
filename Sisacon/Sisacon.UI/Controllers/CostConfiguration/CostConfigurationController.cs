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
    public class CostConfigurationController : BaseController
    {
        private readonly ICostConfigurationAppService _costConfigurationAppService;

        public CostConfigurationController(ICostConfigurationAppService costConfigurationAppService)
        {
            _costConfigurationAppService = costConfigurationAppService;
        }

        [HttpGet]
        [Route("costConfig")]
        public HttpResponseMessage GetConfigurationByUserId(int userId)
        {
            var response = new ResponseMessage<CostConfiguration>();

            response = _costConfigurationAppService.getCostConfigurationByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("costConfig")]
        public HttpResponseMessage Save(CostConfigurationViewModel costConfigViewModel)
        {
            var response = new ResponseMessage<CostConfiguration>();

            if (ModelState.IsValid)
            {
                var costConfiguration = Mapper.Map<CostConfigurationViewModel, CostConfiguration>(costConfigViewModel);

                response = _costConfigurationAppService.updateConfig(costConfiguration);
            }
            else
            {
                response = response.createInvalidResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
