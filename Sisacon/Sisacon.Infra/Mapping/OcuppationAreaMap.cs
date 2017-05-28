using Sisacon.Domain.ValueObjects;
using Sisacon.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class OccupationAreaMap : BaseMap<OccupationArea>
    {
        public OccupationAreaMap()
        {
            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
