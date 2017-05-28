using Sisacon.Domain.ValueObjects;

namespace Sisacon.Infra.Mapping
{
    public class FixedCostMap : BaseMap<FixedCost>
    {
        public FixedCostMap()
        {
            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(FixedCost.MAX_LENGTH_DESCRIPTION)
                .IsRequired();

            Property(x => x.Value)
                .IsRequired();

            HasRequired(x => x.CostCategory)
                .WithMany()
                .HasForeignKey(x => x.CostCategoryId);
        }
    }
}
