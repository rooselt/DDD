using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public override void add(Log log)
        {
            try
            {
                Context.Log.Add(log);
                Context.User.Attach(log.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Log> getByGravity(ErrorGravity.eErrorGravity errorGravity)
        {
            try
            {
                return Context.Log.Where(x => x.eErrorGravity == errorGravity).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
