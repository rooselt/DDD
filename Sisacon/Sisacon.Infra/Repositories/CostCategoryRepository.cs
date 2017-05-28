using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class CostCategoryRepository : RepositoryBase<CostCategory>, ICostCategoryRepository
    {
        public override void add(CostCategory costCategory)
        {
            try
            {
                Context.CostCategory.Add(costCategory);

                Context.User.Attach(costCategory.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CostCategory> getByUserId(int userId)
        {
            try
            {
                return Context.
                    CostCategory.
                    Include("User").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
