using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class LogService : ServiceBase<Log>, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository repository)
            : base(repository)
        {
            _logRepository = repository;
        }

        public List<Log> getByGravity(ErrorGravity.eErrorGravity errorGravity)
        {
            throw new NotImplementedException();
        }
    }
}
