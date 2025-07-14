using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Core.Models;
using WMS.Models.Models.VendorModel;
using System;

namespace WMS.DataLayer.Configurations
{
    public class VendorConfig : EntityGuIdConfig<Vendor>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Vendor> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FDType)
                .IsRequired();

            builder.Property(p => p.Addr1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Addr2)
                .HasMaxLength(100);

            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Pin)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.EmailID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ContactPerson)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CPEmailID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CPMobile)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Url)
                .HasMaxLength(100);

            builder.Property(p => p.ECCNo)
                .HasMaxLength(100);

            builder.Property(p => p.TINNo)
                .HasMaxLength(100);

            builder.Property(p => p.CSTNo)
                .HasMaxLength(100);

            // Seed data
            builder.HasData(
                new Vendor
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Global Trade Co.",
                    Code = "GTC001",
                    FDType = 'F',
                    Addr1 = "123 International Road",
                    Addr2 = "Suite 501",
                    City = "New York",
                    CountryId = 1,
                    StateId = 10,
                    Pin = "10001",
                    EmailID = "info@gtc.com",
                    Phone = "+1-212-555-1000",
                    ContactPerson = "John Doe",
                    CPEmailID = "j.doe@gtc.com",
                    CPMobile = "+1-212-555-2000",
                    Url = "https://www.gtc.com",
                    BaseCurr = 1,
                    ECCNo = "ECC123456",
                    TINNo = "TIN789012",
                    TINDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CSTNo = "CST456789",
                    CSTDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    UserID = 1,
                    CustomerId = 1001,
                    TransExist = 'N'
                },
                new Vendor
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Domestic Supplies Ltd.",
                    Code = "DSL002",
                    FDType = 'D',
                    Addr1 = "456 Local Street",
                    Addr2 = null,
                    City = "Mumbai",
                    CountryId = 2,
                    StateId = 21,
                    Pin = "400001",
                    EmailID = "support@dsl.in",
                    Phone = "+91-22-555-3000",
                    ContactPerson = "Anita Rao",
                    CPEmailID = "anita.rao@dsl.in",
                    CPMobile = "+91-9876543210",
                    Url = "https://www.dsl.in",
                    BaseCurr = 2,
                    ECCNo = "ECC654321",
                    TINNo = "TIN210987",
                    TINDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CSTNo = "CST987654",
                    CSTDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    UserID = 2,
                    CustomerId = 1002,
                    TransExist = 'Y'
                }
            );
        }
    }
}
