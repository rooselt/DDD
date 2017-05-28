using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public UserMap()
        {
            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .IsOptional()
                .HasMaxLength(User.EMAIL_MAX_LENGTH);

            Property(x => x.Password)
                .HasColumnType("varchar")
                .IsRequired();

            Property(x => x.Active)
                .IsRequired()
                .HasColumnType("bit");

            Property(x => x.eUserType)
                .HasColumnName("UserType")
                .IsRequired();

            Property(x => x.LastLogin)
                .IsOptional()
                .HasColumnType("DateTime");

            Property(x => x.ShowWellcomeMessage)
                .IsRequired()
                .HasColumnType("bit");
        }
    }
}
