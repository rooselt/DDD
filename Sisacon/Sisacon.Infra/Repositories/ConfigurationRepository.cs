using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>, IConfigurationRepository
    {
        public override void add(Configuration config)
        {
            try
            {
                Context.Config.Add(config);
                Context.User.Attach(config.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuration getByUserId(int id)
        {
            try
            {
                return Context.Config.Where(x => x.User.Id == id && x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
