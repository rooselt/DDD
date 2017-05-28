using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IConfigurationService : IServiceBase<Configuration>
    {
        Configuration getByUserId(int id);
        void createDefaultConfiguration(User user);
    }
}
