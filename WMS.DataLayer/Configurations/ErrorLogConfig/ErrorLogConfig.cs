using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.DataLayer.Configurations;
using WMS.Models.Models;

namespace WMS.DataLayer.Configuration
{
    public class ErrorLogConfig : EntityGuIdConfig<ErrorLog>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.Property(e => e.UserID);
            builder.Property(e => e.Class).HasMaxLength(200);
            builder.Property(e => e.Method).HasMaxLength(200);
            builder.Property(e => e.ErrorMessage); 
            builder.Property(e => e.CreatedDate);
        }
    }
}
