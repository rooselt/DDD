using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Mapping
{
    public class ContactMap : BaseMap<Contact>
    {
        public ContactMap()
        {
            Property(x => x.LandLine)
                .HasColumnType("varchar")
                .HasMaxLength(Contact.MAX_LENGTH_LAND_LINE)
                .IsOptional();

            Property(x => x.CellPhone)
                .HasColumnType("varchar")
                .HasMaxLength(Contact.MAX_LENGTH_CELLPHONE)
                .IsOptional();

            Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(User.EMAIL_MAX_LENGTH)
                .HasColumnName("Email")
                .IsOptional();

            Property(x => x.UrlSite)
                .HasColumnType("varchar")
                .HasMaxLength(Contact.MAX_LENGTH_URL_SITE)
                .IsOptional();
        }
    }
}
