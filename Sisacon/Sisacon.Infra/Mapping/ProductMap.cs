using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            Property(x => x.CodProduct)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(Product.MAX_LENGTH_DESCRIPTION)
                .IsRequired();

            Property(x => x.Info)
                .HasColumnType("varchar")
                .HasMaxLength(Product.MAX_LENGTH_INFO)
                .IsRequired();

            Property(x => x.Value)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.ProfitPercentage)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.HoursToProduce)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.MinutesToProduce)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.CostPerHour)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.TotalCostMaterials)
                .HasColumnType("decimal")
                .IsRequired();

            HasMany(x => x.ListProductImages)
                .WithRequired()
                .HasForeignKey(x => x.IdProduct);


            HasMany(x => x.ListMaterial)
                .WithMany(x => x.ListProduct);
        }
    }
}
