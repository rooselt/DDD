using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    class ClientMap : BaseMap<Client>
    {
        public ClientMap()
        {
            Property(x => x.CodCliente)
                .HasColumnType("varchar")
                .HasMaxLength(BaseEntity.MAX_LENGTH_COD)
                .IsRequired();

            Property(x => x.ePersonType)
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_CPF)
                .IsOptional();

            Property(x => x.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_CNPJ)
                .IsOptional();

            Property(x => x.Rg)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_RG)
                .IsOptional();

            Property(x => x.ClientName)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_CLIENT_NAME)
                .IsOptional();

            Property(x => x.Birthday)
                .HasColumnType("DateTime")
                .IsOptional();

            Property(x => x.eSex)
                .HasColumnType("int")
                .IsOptional();

            Property(x => x.FantasyName)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_FANTASY_NAME)
                .IsOptional();

            Property(x => x.SocialReasonName)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_SOCIALREASON)
                .IsOptional();

            Property(x => x.SendAutomaticMsg)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.AddBirthdayToCalendar)
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Note)
                .HasColumnType("varchar")
                .HasMaxLength(Client.MAX_LENGTH_NOTE)
                .IsOptional();

            Property(x => x.ExclusionDate)
                .HasColumnType("DateTime")
                .IsOptional();

            Property(x => x.RegistrationDate)
                .HasColumnType("DateTime")
                .IsRequired();

            HasOptional(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.IdAddress);

            HasOptional(x => x.Contact)
                .WithMany()
                .HasForeignKey(x => x.IdContact);

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
