using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IConfigurationRepository : IRepositoryBase<Configuration>
    {
        Configuration getByUserId(int id);
    }
}
