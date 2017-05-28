using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class ClientController : ApiController
    {
        private readonly IClientAppService _clientService;

        public ClientController(IClientAppService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("client")]
        public HttpResponseMessage Save(ClientViewModel clientViewModel)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                if(ModelState.IsValid)
                {
                    var client = Mapper.Map<ClientViewModel, Client>(clientViewModel);

                    response = _clientService.saveOrUpdate(client);
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
        [Route("client")]
        public HttpResponseMessage GetClientById(int id)
        {
            var response = _clientService.getById(id, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("client")]
        public HttpResponseMessage GetClientByUserId(int idUser)
        {
            var response = _clientService.getClientByUserId(idUser);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("client")]
        public HttpResponseMessage DeleteClient(int idClient)
        {
            var response = _clientService.deleteClient(idClient);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
