using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IProviderRepository : IRepositoryBase<Provider>
    {
        List<Provider> getByUserId(int userId);
        int GetCount(int userId);
    }
}
