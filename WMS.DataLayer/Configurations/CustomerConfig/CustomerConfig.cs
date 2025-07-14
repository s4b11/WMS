using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Core.Models;
using WMS.Models.Models.CustomerModel;
using System;

namespace WMS.DataLayer.Configurations
{
    public class CustomerConfig : EntityGuIdConfig<Customer>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Addr1).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Addr2).HasMaxLength(100);
            builder.Property(p => p.City).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.StateId).IsRequired();
            builder.Property(p => p.Pin).IsRequired().HasMaxLength(50);
            builder.Property(p => p.EmailID).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ContactPerson).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CPEmailID).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CPMobile).IsRequired().HasMaxLength(100);
            builder.Property(p => p.URL).HasMaxLength(100);
            builder.Property(p => p.BaseCurr).IsRequired();
            builder.Property(p => p.ECCNO).HasMaxLength(100);
            builder.Property(p => p.TINNO).HasMaxLength(100);
            builder.Property(p => p.TINDATE);
            builder.Property(p => p.CSTNO).HasMaxLength(100);
            builder.Property(p => p.CSTDATE);
            builder.Property(p => p.UserID).IsRequired();
            builder.Property(p => p.CompanyId).IsRequired();

            // Seed data
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Acme Corp",
                    Code = "ACM001",
                    Addr1 = "123 Main St",
                    Addr2 = "Suite 400",
                    City = "New York",
                    CountryId = 1,
                    StateId = 10,
                    Pin = "10001",
                    EmailID = "info@acmecorp.com",
                    Phone = "1234567890",
                    ContactPerson = "John Doe",
                    CPEmailID = "john.doe@acmecorp.com",
                    CPMobile = "9876543210",
                    URL = "https://acmecorp.com",
                    BaseCurr = 1,
                    ECCNO = "ECC123456",
                    TINNO = "TIN987654",
                    TINDATE = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CSTNO = "CST123456",
                    CSTDATE = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    UserID = 1,
                    CompanyId = 1,
                    TransExistFlag = 'N'
                },
                new Customer
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Beta Industries",
                    Code = "BET002",
                    Addr1 = "456 Market Ave",
                    Addr2 = null,
                    City = "Los Angeles",
                    CountryId = 1,
                    StateId = 5,
                    Pin = "90001",
                    EmailID = "contact@betaind.com",
                    Phone = "2345678901",
                    ContactPerson = "Jane Smith",
                    CPEmailID = "jane.smith@betaind.com",
                    CPMobile = "8765432109",
                    URL = "https://betaind.com",
                    BaseCurr = 2,
                    ECCNO = null,
                    TINNO = "TIN654321",
                    TINDATE = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CSTNO = null,
                    CSTDATE = null,
                    UserID = 2,
                    CompanyId = 1,
                    TransExistFlag = 'Y'
                }
            );
        }
    }
}
