using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface ICostConfigurationRepository : IRepositoryBase<CostConfiguration>
    {
        CostConfiguration getByUserId(int userId);
    }
}
