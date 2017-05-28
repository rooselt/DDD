using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class MaterialCategoryMap : BaseMap<MaterialCategory>
    {
        public MaterialCategoryMap()
        {
            Property(x => x.Description)
                .HasMaxLength(MaterialCategory.MAX_LENGTH_DESC)
                .HasColumnType("varchar")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
