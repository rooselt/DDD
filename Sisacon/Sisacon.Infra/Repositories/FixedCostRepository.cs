using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class FixedCostRepository : RepositoryBase<FixedCost>, IFixedCostRepository
    {
        public override void add(FixedCost fixedCost)
        {
            try
            {
                Context.User.Attach(fixedCost.CostCategory.User);
                Context.CostCategory.Attach(fixedCost.CostCategory);

                Context.FixedCost.Add(fixedCost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void update(FixedCost fixedCost)
        {
            try
            {
                fixedCost.CostCategoryId = fixedCost.CostCategory.Id;

                Context.User.Attach(fixedCost.CostCategory.User);
                Context.CostCategory.Attach(fixedCost.CostCategory);

                Context.Entry(fixedCost).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override FixedCost getById(int id)
        {
            try
            {
                return Context.
                    FixedCost.
                    Include("CostCategory").
                    Include("CostCategory.User").
                    Where(x => x.Id == id && x.ExclusionDate == null).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
