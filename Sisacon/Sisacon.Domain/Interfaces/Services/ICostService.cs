using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface ICostService : IServiceBase<Cost>
    {
        List<Cost> GetCostsByUserId(int userId);
    }
}
