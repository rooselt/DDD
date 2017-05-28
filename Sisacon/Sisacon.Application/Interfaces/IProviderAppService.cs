using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface IProviderAppService : IAppServiceBase<Provider>
    {
        ResponseMessage<Provider> saveOrUpdate(Provider Provider);
        ResponseMessage<Provider> deleteProvider(int ProviderId);
        ResponseMessage<Provider> getProviderByUserId(int userId);
    }
}
