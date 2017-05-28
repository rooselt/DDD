using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class CostCategoryController : ApiController
    {
        private readonly ICostCategoryAppService _costCategoryAppService;

        public CostCategoryController(ICostCategoryAppService costCategoryAppService)
        {
            _costCategoryAppService = costCategoryAppService;
        }

        [HttpPost]
        [Route("costCategory")]
        public HttpResponseMessage Save(CostCategoryViewModel categoryViewModel)
        {
            var response = new ResponseMessage<CostCategory>();

            if (ModelState.IsValid)
            {
                var CostCategory = Mapper.Map<CostCategoryViewModel, CostCategory>(categoryViewModel);

                response = _costCategoryAppService.saveOrUpdate(CostCategory);
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("costCategory")]
        public HttpResponseMessage GetCostCategories(int userId)
        {
            var response = new ResponseMessage<CostCategory>();

            response = _costCategoryAppService.getCostCategoryByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("costCategory")]
        public HttpResponseMessage GetCostCategoryById(int id)
        {
            var response = new ResponseMessage<CostCategory>();

            response = _costCategoryAppService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("costCategory")]
        public HttpResponseMessage Delete(int categoryId)
        {
            var response = new ResponseMessage<CostCategory>();

            response = _costCategoryAppService.deleteCostCategory(categoryId);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
