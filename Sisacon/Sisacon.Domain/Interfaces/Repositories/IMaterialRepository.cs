using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IMaterialRepository : IRepositoryBase<Material>
    {
        List<Material> getByUserId(int userId);
        int GetCount(int userId);
    }
}
