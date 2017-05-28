using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    public class EquipmentMap : BaseMap<Equipment>
    {
        public EquipmentMap()
        {
            Property(x => x.SerialNumber)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_SERIAL_NUMBER)
                .IsOptional();

            Property(x => x.CodEquipment)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Desc)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_DESC)
                .IsRequired();

            Property(x => x.AcquisitionDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.Model)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_MODEL)
                .IsOptional();

            Property(x => x.Manufacturer)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_MANUFACTURER)
                .IsOptional();

            Property(x => x.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.LifeSpan)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.NameTechnicalAssistance)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_NAME_TECHNICAL_ASSISTANCE)
                .IsOptional();

            Property(x => x.PhoneTechnicalAssistance)
                .HasColumnType("varchar")
                .HasMaxLength(Equipment.MAX_LENGTH_PHONE_TECHNICAL_ASSISTANCE)
                .IsOptional();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
