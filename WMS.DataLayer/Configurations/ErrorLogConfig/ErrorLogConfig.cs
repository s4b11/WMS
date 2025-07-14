using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class ErrorLogConfig : EntityGuIdConfig<ErrorLog>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserID);
            builder.Property(e => e.Class).HasMaxLength(200);
            builder.Property(e => e.Method).HasMaxLength(200);
            builder.Property(e => e.ErrorMessage); 
            builder.Property(e => e.CreatedDate);
        }
    }
}
