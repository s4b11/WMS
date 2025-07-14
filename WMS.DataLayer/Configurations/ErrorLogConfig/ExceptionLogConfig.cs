using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class ExceptionLogConfig : EntityGuIdConfig<ExceptionLog>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ErrorMessage);
            builder.Property(e => e.UserId);
            builder.Property(e => e.ActionName).HasMaxLength(200);
            builder.Property(e => e.ControllerName).HasMaxLength(200);
            builder.Property(e => e.IpAddress).HasMaxLength(200);
        }
    }
}
