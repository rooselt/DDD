using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Application.Interfaces
{
    public interface ILogAppService : IAppServiceBase<Log>
    {
        ResponseMessage<Log> getLogs();
        ResponseMessage<Log> getLogById(int id);
        void createClientLog(Exception ex, User user, eErrorGravity gravity);
        void createInternalLog(Exception ex, User user, eErrorGravity gravity);
    }
}
