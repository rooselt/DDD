using Sisacon.Domain.ValueObjects;

namespace Sisacon.Infra.Mapping
{
    public class ProductImagesMap : BaseMap<ProductImages>
    {
        public ProductImagesMap()
        {
            Property(x => x.Image)
                .HasColumnType("varbinary")
                .HasMaxLength(null)
                .IsRequired();
        }
    }
}
