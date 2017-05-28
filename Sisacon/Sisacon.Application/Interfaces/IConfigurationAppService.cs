using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface IConfigurationAppService : IAppServiceBase<Configuration>
    {
        ResponseMessage<Configuration> updateConfig(Configuration config);
        ResponseMessage<Configuration> getByUserId(int id);
    }
}
