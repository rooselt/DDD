using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class CostConfigurationMap : BaseMap<CostConfiguration>
    {
        public CostConfigurationMap()
        {
            Property(x => x.MaxValue)
                .IsRequired();

            Property(x => x.IncludDevaluationOfEquipment)
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
