using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;
using Sisacon.Domain.Enuns;
using static Sisacon.Domain.Enuns.PersonType;

namespace Sisacon.Application
{
    public class ClientAppService : AppServiceBase<Client>, IClientAppService
    {
        private readonly IClientService _clientService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public ClientAppService(IClientService clientService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(clientService)
        {
            _clientService = clientService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<List<Client>> getClientByUserId(int userId)
        {
            var response = new ResponseMessage<List<Client>>();

            try
            {
                var clientList = _clientService.getByUserId(userId);

                var clientsF = clientList.Where(x => x.ePersonType == ePersonType.Fisica).ToList();
                var clientsJ = clientList.Where(x => x.ePersonType == ePersonType.Juridica).ToList();

                response.ValueList = new List<List<Client>>();
                response.ValueList.Add(clientsF);
                response.ValueList.Add(clientsJ);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Client> saveOrUpdate(Client client)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                if(client.IsValid())
                {
                    if(client.Id > 0)
                    {
                        _clientService.update(client);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Cliente");
                    }
                    else
                    {
                        client.GenereteCode();

                        _clientService.add(client);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Cliente");
                    }

                    if(_clientService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
                    else
                    {
                        response.Value = client;
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, client.User, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Client> deleteClient(int clientId)
        {
            var response = new ResponseMessage<Client>();

            try
            {
                var client = _clientService.getById(clientId);

                if(client != null && client.ValidatePendencesBeforeDelete())
                {
                    _clientService.delete(client);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Cliente");
                }

                if(_clientService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Client> GetCount(int userId)
        {
            var response = new ResponseMessage<Client>();

            try
            {

            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
