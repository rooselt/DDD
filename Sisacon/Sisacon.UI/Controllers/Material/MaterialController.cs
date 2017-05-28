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
    public class MaterialController : ApiController
    {
        private readonly IMaterialAppService _materialAppService;

        public MaterialController(IMaterialAppService materialAppService)
        {
            _materialAppService = materialAppService;
        }

        [HttpPost]
        [Route("material")]
        public HttpResponseMessage Save(MaterialViewModel materialViewModel)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                if (ModelState.IsValid)
                {
                    var material = Mapper.Map<MaterialViewModel, Material>(materialViewModel);

                    response = _materialAppService.saveOrUpdate(material);
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
        [Route("material")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new ResponseMessage<Material>();

            response = _materialAppService.deleteMaterial(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [Authorize()]
        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialById(int id)
        {
            var response = new ResponseMessage<Material>();

            response = _materialAppService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialByUserId(int userId)
        {
            var response = new ResponseMessage<Material>();

            response = _materialAppService.getMaterialByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("material")]
        public HttpResponseMessage GetMaterialByCategory(int idCategory)
        {

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "");
        }
    }
}
