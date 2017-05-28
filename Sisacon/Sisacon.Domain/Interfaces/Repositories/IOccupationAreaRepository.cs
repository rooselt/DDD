using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IOccupationAreaRepository : IRepositoryBase<OccupationArea>
    {
        List<OccupationArea> getOccupationAreas();
    }
}
