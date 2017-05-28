using Sisacon.Domain.Entities;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface ILogService : IServiceBase<Log>
    {
        List<Log> getByGravity(eErrorGravity errorGravity);
    }
}

