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
    public class MaterialCategoryController : ApiController
    {
        private readonly IMaterialCategoryAppService _materialCategoryAppService;

        public MaterialCategoryController(IMaterialCategoryAppService materialCategoryAppService)
        {
            _materialCategoryAppService = materialCategoryAppService;
        }

        [HttpPost]
        [Route("materialCategory")]
        public HttpResponseMessage Save(MaterialCategoryViewModel categoryViewModel)
        {
            var response = new ResponseMessage<MaterialCategory>();

            if (ModelState.IsValid)
            {
                var materialCategory = Mapper.Map<MaterialCategoryViewModel, MaterialCategory>(categoryViewModel);

                response = _materialCategoryAppService.saveOrUpdate(materialCategory);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("materialCategory")]
        public HttpResponseMessage GetMaterialsCategories(int userId)
        {
            var response = new ResponseMessage<MaterialCategory>();

            response = _materialCategoryAppService.getMaterialCategoryByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("materialCategory")]
        public HttpResponseMessage GetMaterialCategoryById(int id)
        {
            var response = new ResponseMessage<MaterialCategory>();

            response = _materialCategoryAppService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("materialCategory")]
        public HttpResponseMessage Delete(int categoryId)
        {
            var response = new ResponseMessage<MaterialCategory>();

            response = _materialCategoryAppService.deleteMaterialCategory(categoryId);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
