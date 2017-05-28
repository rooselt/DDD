using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            HasKey(x => x.Id);

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();
        }
    }
}
