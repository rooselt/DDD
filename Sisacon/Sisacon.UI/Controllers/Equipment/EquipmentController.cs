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
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentAppService _equipmentAppService;

        public EquipmentController(IEquipmentAppService equipmentAppService)
        {
            _equipmentAppService = equipmentAppService;
        }


        [HttpPost]
        [Route("equip")]
        public HttpResponseMessage Save(EquipmentViewModel equipmentViewModel)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                if (ModelState.IsValid)
                {
                    var equipment = Mapper.Map<EquipmentViewModel, Equipment>(equipmentViewModel);

                    response = _equipmentAppService.saveOrUpdate(equipment);
                }
            }
            catch
            {
                response = response.createErrorResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("equip")]
        public HttpResponseMessage Delete(int id)
        {
            var response = _equipmentAppService.deleteEquipment(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("equip")]
        public HttpResponseMessage GetEquipmentByUserId(int userId)
        {
            var response = _equipmentAppService.getEquipmentsByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("equip")]
        public HttpResponseMessage GetEquipmentById(int id)
        {
            var response = _equipmentAppService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
