using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IEquipmentService : IServiceBase<Equipment>
    {
        List<Equipment> getByUserId(int userId);
        int GetCount(int userId);
    }
}
