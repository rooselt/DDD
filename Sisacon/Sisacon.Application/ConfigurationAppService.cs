using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class ConfigurationAppService : AppServiceBase<Configuration>, IConfigurationAppService
    {
        private readonly IConfigurationService _configService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public ConfigurationAppService(IConfigurationService serviceBase, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(serviceBase)
        {
            _configService = serviceBase;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Configuration> getByUserId(int id)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.Value = _configService.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<Configuration> updateConfig(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                if (config.Id > 0)
                {
                    _configService.update(config);

                    if( _configService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
                    else
                    {
                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Configuração");
                        response.Value = config;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
