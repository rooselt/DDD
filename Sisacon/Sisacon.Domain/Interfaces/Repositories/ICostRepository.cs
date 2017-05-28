using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface ICostRepository : IRepositoryBase<Cost>
    {
        List<Cost> getCostsByUserId(int userId);
        Cost GetCurrentCost(int userId);
    }
}
