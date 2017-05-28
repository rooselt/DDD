using Sisacon.Domain.Entities;

namespace Sisacon.Infra.Mapping
{
    class CompanyMap : BaseMap<Company>
    {
        public CompanyMap()
        {
            Property(x => x.ePersonType)
                .IsRequired();

            Property(x => x.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(x => x.CompanyName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.FantasyName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Slogan)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(250)
                .IsOptional();

            Property(x => x.Logo)
                .HasColumnType("varbinary")
                .HasMaxLength(null)
                .IsOptional();

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.IdAddress);

            HasOptional(x => x.Contact)
                .WithMany()
                .HasForeignKey(x => x.IdContact);

            HasOptional(x => x.OccupationArea)
                .WithMany()
                .HasForeignKey(x => x.IdOccupationArea);

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
