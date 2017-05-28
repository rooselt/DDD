using Sisacon.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sisacon.Infra.Mapping
{
    public class LogMap : BaseMap<Log>
    {
        public LogMap()
        {
            Property(x => x.Message)
                .HasColumnType("varchar")
                .HasMaxLength(Log.MAX_LENGTH_MESSAGE)
                .IsRequired();

            Property(x => x.InnerException)
                .HasColumnType("varchar")
                .HasMaxLength(Log.MAX_LENGTH_INNER_EX)
                .IsRequired();

            Property(x => x.StackTrace)
                .HasColumnType("varchar")
                .HasMaxLength(Log.MAX_LENGTH_STACKTRACE)
                .IsRequired();

            Property(x => x.eErrorGravity)
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.IdUser);
        }
    }
}
