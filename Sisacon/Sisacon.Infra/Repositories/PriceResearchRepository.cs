using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;

namespace Sisacon.Infra.Repositories
{
    public class PriceResearchRepository : RepositoryBase<PriceResearch>, IPriceResearchRepository
    {
        public override void add(PriceResearch price)
        {
            try
            {
                price.Material.Category = null;
                price.Provider.User = null;

                Context.User.Attach(price.Material.User);
                Context.Material.Attach(price.Material);
                Context.Provider.Attach(price.Provider);

                Context.PriceResearch.Add(price);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
