using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.Sex;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Application
{
    public class ProviderAppService : AppServiceBase<Provider>, IProviderAppService
    {
        private readonly IProviderService _providerService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public ProviderAppService(IProviderService providerService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(providerService)
        {
            _providerService = providerService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Provider> deleteProvider(int ProviderId)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                var provider = _providerService.getById(ProviderId, true);

                if(provider != null)
                {
                    _providerService.delete(provider);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Fornecedor");
                }

                if(_providerService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Provider> getProviderByUserId(int userId)
        {
            var response = new ResponseMessage<Provider>();
            response.ValueList = new List<Provider>();

            try
            {
                response.ValueList = _providerService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Provider> saveOrUpdate(Provider provider)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                if(provider.isValid())
                {
                    if(provider.Id > 0)
                    {
                        _providerService.update(provider);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Fornecedor");
                    }
                    else
                    {
                        provider.genereteCode();

                        _providerService.add(provider);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Fornecedor");
                    }

                    if(_providerService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
                    else
                    {
                        response.Value = provider;
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, provider.User, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
