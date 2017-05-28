using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class CostConfigurationRepository : RepositoryBase<CostConfiguration>, ICostConfigurationRepository
    {
        public override void add(CostConfiguration costConfiguration)
        {
            try
            {
                Context.CostConfiguration.Add(costConfiguration);

                Context.User.Attach(costConfiguration.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CostConfiguration getByUserId(int userId)
        {
            try
            {
                return Context.
                    CostConfiguration.
                    Include("User").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
