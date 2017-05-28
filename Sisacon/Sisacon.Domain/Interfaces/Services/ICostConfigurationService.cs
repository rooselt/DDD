using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface ICostConfigurationService : IServiceBase<CostConfiguration>
    {
        CostConfiguration getByUserId(int id);
        void createDefaultCostConfiguration(User user);
    }
}
