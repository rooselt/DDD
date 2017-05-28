using AutoMapper;
using Ninject.Activation;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain;
using Sisacon.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class ProviderController : ApiController
    {
        private readonly IProviderAppService _providerService;

        public ProviderController(IProviderAppService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost]
        [Route("provider")]
        public HttpResponseMessage Save(ProviderViewModel providerViewModel)
        {
            var response = new ResponseMessage<Domain.Entities.Provider>();

            try
            {
                if (ModelState.IsValid)
                {
                    var provider = Mapper.Map<ProviderViewModel, Domain.Entities.Provider>(providerViewModel);

                    response = _providerService.saveOrUpdate(provider);
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
        [Route("provider")]
        public HttpResponseMessage GetProvidersByUserId(int userId)
        {
            var response = _providerService.getProviderByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("provider")]
        public HttpResponseMessage GetProviderById(int id)
        {
            var response = _providerService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("provider")]
        public HttpResponseMessage Delete(int id)
        {
            var response = _providerService.deleteProvider(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
