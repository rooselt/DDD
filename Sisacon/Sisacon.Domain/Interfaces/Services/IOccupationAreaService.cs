using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IOccupationAreaService : IServiceBase<OccupationArea>
    {
        List<OccupationArea> getOccupationAreas();
    }
}
