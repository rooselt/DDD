using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class CostCategoryMap : BaseMap<CostCategory>
    {
        public CostCategoryMap()
        {
            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
