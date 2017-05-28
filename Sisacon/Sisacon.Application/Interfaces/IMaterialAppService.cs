using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface IMaterialAppService : IAppServiceBase<Material>
    {
        ResponseMessage<Material> saveOrUpdate(Material Material);
        ResponseMessage<Material> deleteMaterial(int MaterialId);
        ResponseMessage<Material> getMaterialByUserId(int userId);
    }
}
