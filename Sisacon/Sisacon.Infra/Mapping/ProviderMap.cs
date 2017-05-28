using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class ProviderMap : BaseMap<Provider>
    {
        public ProviderMap()
        {
            Property(x => x.CodProvider)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(Provider.MAX_LENGTH_CNPJ)
                .IsRequired();

            Property(x => x.SocialReasonName)
                .HasColumnType("varchar")
                .HasMaxLength(Provider.MAX_LENGTH_SOCIAOREASON)
                .IsRequired();

            Property(x => x.FantasyName)
                .HasColumnType("varchar")
                .HasMaxLength(Provider.MAX_LENGTH_SOCIAOREASON)
                .IsRequired();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.IdAddress);

            HasOptional(x => x.Contact)
                .WithMany()
                .HasForeignKey(x => x.IdContact);

            HasOptional(x => x.BankDetails)
                .WithMany()
                .HasForeignKey(x => x.IdBankDetails);

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
