using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    public class CostMap : BaseMap<Cost>
    {
        public CostMap()
        {
            Property(x => x.ReferenceMonthText)
                .HasColumnType("varchar").
                IsRequired();

            Property(x => x.WorkedHours)
                .IsRequired();

            Property(x => x.Salary)
                .IsRequired();

            Property(x => x.TotalFixedCost)
                .IsOptional();

            Property(x => x.TotalDevaluationOfEquipment)
                .IsOptional();

            Property(x => x.TotalCost)
                .IsOptional();

            Property(x => x.CostPerHour)
                .IsOptional();

            Property(x => x.Closed)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Current)
                .HasColumnType("bit")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.ListFixedCost)
                .WithRequired()
                .HasForeignKey(x => x.CostId);
        }
    }
}
