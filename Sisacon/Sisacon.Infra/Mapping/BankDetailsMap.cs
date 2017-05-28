using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class BankDetailsMap : BaseMap<BankDetails>
    {
        public BankDetailsMap()
        {
            Property(x => x.Bank)
                .HasColumnType("varchar")
                .HasMaxLength(BankDetails.MAX_LENGTH_BANK)
                .IsOptional();

            Property(x => x.AccountNumber)
                .HasColumnType("varchar")
                .HasMaxLength(BankDetails.MAX_LENGTH_ACCOUNTNUMBER)
                .IsOptional();

            Property(x => x.Agency)
                .HasColumnType("varchar")
                .HasMaxLength(BankDetails.MAX_LENGTH_AGENCY)
                .IsOptional();
        }
    }
}
