using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class AddressMap : BaseMap<Address>
    {
        public AddressMap()
        {
            Property(x => x.Cep)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_CEP)
                .IsOptional();

            Property(x => x.Logradouro)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_LOGRADOURO)
                .IsOptional();

            Property(x => x.Numero)
                .HasColumnType("int")
                .IsOptional();

            Property(x => x.Complemento)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_COMPLEMENTO)
                .IsOptional();

            Property(x => x.Bairro)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_BAIRRO)
                .IsOptional();

            Property(x => x.Cidade)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_CIDADE)
                .IsOptional();

            Property(x => x.Estado)
                .HasColumnType("varchar")
                .HasMaxLength(Address.MAX_LENGTH_ESTADO)
                .IsOptional();
        }
    }
}
