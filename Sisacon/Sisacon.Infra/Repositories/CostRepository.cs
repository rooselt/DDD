using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class CostRepository : RepositoryBase<Cost>, ICostRepository
    {
        public override void add(Cost cost)
        {
            try
            {
                Context.User.Attach(cost.User);
                Context.Cost.Add(cost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void update(Cost cost)
        {
            try
            {
                cost.ListFixedCost = null;
                Context.User.Attach(cost.User);
                Context.Entry(cost).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Cost getById(int id)
        {
            try
            {
                var cost = Context.
                    Cost.
                    Include("User").
                    Where(x => x.Id == id && x.ExclusionDate == null).
                    FirstOrDefault();

                if (cost != null)
                {
                    cost.ListFixedCost = Context.
                    FixedCost.
                    Include("CostCategory").
                    Include("CostCategory.User").
                    Where(x => x.CostId == cost.Id && x.ExclusionDate == null).
                    ToList();
                }

                return cost;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cost> getCostsByUserId(int userId)
        {
            try
            {
                return Context.
                    Cost.
                    Include("User").
                    Include("ListFixedCost").
                    Include("ListFixedCost.CostCategory").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cost GetCurrentCost(int userId)
        {
            try
            {
                return Context.
                    Cost.
                    Include("User").
                    Include("ListFixedCost").
                    Include("ListFixedCost.CostCategory").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null && x.Current).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
