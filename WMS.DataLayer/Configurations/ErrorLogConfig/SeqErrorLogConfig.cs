using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.DataLayer.Configurations;
using WMS.Models;

namespace WMS.DataLayer.Configuration
{
    public class SeqErrorLogConfig : EntityGuIdConfig<SeqErrorLog>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<SeqErrorLog> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Seed);
            builder.Property(e => e.Incr);
            builder.Property(e => e.Curval);
        }
    }
}
