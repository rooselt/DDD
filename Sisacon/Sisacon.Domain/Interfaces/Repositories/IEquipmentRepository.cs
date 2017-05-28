using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        List<Equipment> getByUserId(int userId);
        int GetCount(int userId);
    }
}
