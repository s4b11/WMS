using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class CountryConfig : EntityGuIdConfig<Country>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CountryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CountryCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new Country { Id = 1, UniqueGuId = Guid.NewGuid(), CountryName = "Afghanistan", CountryCode = "AF" },
                new Country { Id = 2, UniqueGuId = Guid.NewGuid(), CountryName = "Albania", CountryCode = "AL" },
                new Country { Id = 3, UniqueGuId = Guid.NewGuid(), CountryName = "Algeria", CountryCode = "DZ" },
                new Country { Id = 4, UniqueGuId = Guid.NewGuid(), CountryName = "Andorra", CountryCode = "AD" },
                new Country { Id = 5, UniqueGuId = Guid.NewGuid(), CountryName = "Angola", CountryCode = "AO" },
                new Country { Id = 6, UniqueGuId = Guid.NewGuid(), CountryName = "Antigua and Barbuda", CountryCode = "AG" },
                new Country { Id = 7, UniqueGuId = Guid.NewGuid(), CountryName = "Argentina", CountryCode = "AR" },
                new Country { Id = 8, UniqueGuId = Guid.NewGuid(), CountryName = "Armenia", CountryCode = "AM" },
                new Country { Id = 9, UniqueGuId = Guid.NewGuid(), CountryName = "Australia", CountryCode = "AU" },
                new Country { Id = 10, UniqueGuId = Guid.NewGuid(), CountryName = "Austria", CountryCode = "AT" },
                new Country { Id = 11, UniqueGuId = Guid.NewGuid(), CountryName = "Azerbaijan", CountryCode = "AZ" }
            );
        }
    }
}