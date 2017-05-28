using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface ILogRepository : IRepositoryBase<Log>
    {
        List<Log> getByGravity(ErrorGravity.eErrorGravity errorGravity);
    }
}
