using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class OccupationAreaRepository : RepositoryBase<OccupationArea>, IOccupationAreaRepository
    {
        public List<OccupationArea> getOccupationAreas()
        {
            try
            {
                return Context.OccupationArea.Where(x => x.ExclusionDate == null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
