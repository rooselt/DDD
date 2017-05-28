using Sisacon.Domain.ValueObjects;

namespace Sisacon.Infra.Mapping
{
    public class PriceResearchMap : BaseMap<PriceResearch>
    {
        public PriceResearchMap()
        {
            Property(x => x.Price)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.SearchDate)
                .HasColumnType("DateTime")
                .IsRequired();

            HasRequired(x => x.Provider)
                .WithMany()
                .HasForeignKey(x => x.ProviderId);

            HasRequired(x => x.Material)
                .WithMany(x => x.ListPriceResearch)
                .HasForeignKey(x => x.MaterialId);
        }
    }
}
