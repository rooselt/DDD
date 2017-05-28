using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IProviderService : IServiceBase<Provider>
    {
        List<Provider> getByUserId(int userId);
        int GetCount(int userId);
    }
}
