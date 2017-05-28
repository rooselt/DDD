using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    public class MaterialMap : BaseMap<Material>
    {
        public MaterialMap()
        {
            Property(x => x.CodMaterial)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(Material.MAX_LENGTH_DESC)
                .IsRequired();

            Property(x => x.Note)
                .HasColumnType("varchar")
                .HasMaxLength(Material.MAX_LENGTH_NOTE)
                .IsOptional();

            Ignore(x => x.CurrentPrice);

            HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.ListPriceResearch)
                .WithOptional();

            HasMany(x => x.ListProduct).
                WithMany(x => x.ListMaterial);
        }
    }
}
