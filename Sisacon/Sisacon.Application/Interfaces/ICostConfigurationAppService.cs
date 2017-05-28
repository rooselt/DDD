using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface ICostConfigurationAppService : IAppServiceBase<CostConfiguration>
    {
        ResponseMessage<CostConfiguration> updateConfig(CostConfiguration config);
        ResponseMessage<CostConfiguration> getCostConfigurationByUserId(int id);
    }
}
