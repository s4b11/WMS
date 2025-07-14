using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.DataLayer.Configurations;
using WMS.Models.Models;

namespace WMS.DataLayer.Configuration
{
    public class ExceptionLogConfig : EntityGuIdConfig<ExceptionLog>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder.Property(e => e.ErrorMessage);
            builder.Property(e => e.UserId);
            builder.Property(e => e.ActionName).HasMaxLength(200);
            builder.Property(e => e.ControllerName).HasMaxLength(200);
            builder.Property(e => e.IpAddress).HasMaxLength(200);
        }
    }
}
