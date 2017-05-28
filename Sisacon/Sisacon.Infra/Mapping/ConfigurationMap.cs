using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class ConfigurationMap : BaseMap<Configuration>
    {
        public ConfigurationMap()
        {
            Property(x => x.DefaultPage)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.CodAutoClient)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoProvider)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoMaterial)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoProduct)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoEstimate)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoRequest)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.CodAutoEquipment)
                .HasColumnType("bit")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
