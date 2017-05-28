using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IMaterialService : IServiceBase<Material>
    {
        List<Material> getByUserId(int userId);
        int GetCount(int userId);
    }
}
