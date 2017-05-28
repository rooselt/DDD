using Sisacon.Application.Interfaces;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class NotificationController : ApiController
    {
        private readonly INotificationAppService _notificationAppService;

        public NotificationController(INotificationAppService notificationAppService)
        {
            _notificationAppService = notificationAppService;
        }

        [HttpGet]
        [Route("notify")]
        public HttpResponseMessage GetNotificationsByUserId(int id)
        {
            var response = _notificationAppService.getByUserId(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpPut]
        [Route("notify")]
        public HttpResponseMessage Update(int id)
        {
            var response = _notificationAppService.updateStatusVisualized(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
