using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.SystemConfiguration
{
    [RoutePrefix("api")]
    public class ConfigurationController : ApiController
    {
        private readonly IConfigurationAppService _configAppService;

        public ConfigurationController(IConfigurationAppService configService)
        {
            _configAppService = configService;
        }

        [HttpGet]
        [Route("config")]
        public HttpResponseMessage GetConfigurationByUserId(int idUser)
        {
            var response = _configAppService.getByUserId(idUser);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPost]
        [Route("config")]
        public HttpResponseMessage update(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            if (ModelState.IsValid)
            {
                response = _configAppService.updateConfig(config);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
