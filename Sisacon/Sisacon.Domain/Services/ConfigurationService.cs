using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using System;

namespace Sisacon.Domain.Services
{
    public class ConfigurationService : ServiceBase<Configuration>, IConfigurationService
    {
        private readonly IConfigurationRepository _repository;

        public ConfigurationService(IConfigurationRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void createDefaultConfiguration(User user)
        {
            try
            {
                var config = new Configuration();

                config.createDefaultConfig(user);

                _repository.add(config);

                _repository.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuration getByUserId(int id)
        {
            try
            {
                return _repository.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
