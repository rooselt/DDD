using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class CostConfigurationService : ServiceBase<CostConfiguration>, ICostConfigurationService
    {
        private readonly ICostConfigurationRepository _costConfigurationRepository;

        public CostConfigurationService(ICostConfigurationRepository costConfigurationRepository) : base(costConfigurationRepository)
        {
            _costConfigurationRepository = costConfigurationRepository;
        }

        public void createDefaultCostConfiguration(User user)
        {
            try
            {
                var config = new CostConfiguration();

                config.createDefaultConfiguration(user);
                _costConfigurationRepository.add(config);
                _costConfigurationRepository.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CostConfiguration getByUserId(int id)
        {
            try
            {
                return _costConfigurationRepository.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
