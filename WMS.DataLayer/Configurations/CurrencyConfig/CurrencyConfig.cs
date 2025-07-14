using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Core.Models;
using WMS.Models.Models.CurrencyModel;
using System;

namespace WMS.DataLayer.Configurations
{
    public class CurrencyConfig : EntityGuIdConfig<Currency>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.CountryId)
                .IsRequired();

            builder.HasData(
                new Currency
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "US Dollar",
                    Code = "USD",
                    CountryId = 1,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false
                },
                new Currency
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Euro",
                    Code = "EUR",
                    CountryId = 2,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false
                }
            );
        }
    }
}
