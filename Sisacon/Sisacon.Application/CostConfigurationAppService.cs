using System;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class CostConfigurationAppService : AppServiceBase<CostConfiguration>, ICostConfigurationAppService
    {
        private readonly ICostConfigurationService _costConfigurationService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public CostConfigurationAppService(ICostConfigurationService costConfigurationService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(costConfigurationService)
        {
            _costConfigurationService = costConfigurationService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<CostConfiguration> getCostConfigurationByUserId(int userId)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                response.Value = _costConfigurationService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<CostConfiguration> updateConfig(CostConfiguration config)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                if(config.Id > 0)
                {
                    _costConfigurationService.update(config);

                    if(_costConfigurationService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
                    else
                    {
                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Configuração de Custo");

                        response.Value = config;
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
