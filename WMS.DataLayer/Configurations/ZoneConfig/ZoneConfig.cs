using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WMS.Models.Models.ZoneModel;
using WMS.Core.Models;

namespace WMS.DataLayer.Configurations
{
    public class ZoneConfig : EntityGuIdConfig<Zone>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Zone> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Short)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.TransExistFlag)
                .HasMaxLength(1);

            builder.HasData(
                new Zone { Id = 1, UniqueGuId = Guid.NewGuid(), Name = "North Zone", Short = "NZ", TransExistFlag = "N" },
                new Zone { Id = 2, UniqueGuId = Guid.NewGuid(), Name = "South Zone", Short = "SZ", TransExistFlag = "N" }
            );
        }
    }
}
