using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Models;
using System;

namespace WMS.DataLayer.Configurations
{
    public class CarrierConfig : EntityGuIdConfig<Carrier>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Carrier> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.Addr1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Addr2)
                .HasMaxLength(100);

            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Pin)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.CpName)
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Mobile)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LstRegnno)
                .HasMaxLength(50);

            builder.Property(p => p.CstRegnno)
                .HasMaxLength(50);

            builder.Property(p => p.StRegnno)
                .HasMaxLength(50);

            builder.Property(p => p.TransExistFlag)
                .HasMaxLength(1);

            // Seed data
            builder.HasData(
                new Carrier
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Express Logistics",
                    Type = "Air",
                    Addr1 = "123 Skyline Rd",
                    Addr2 = "Suite 400",
                    City = "Mumbai",
                    CountryId = 101,
                    StateId = 27,
                    Pin = "400001",
                    CpName = "John Doe",
                    Email = "contact@expresslogistics.com",
                    Phone = "02212345678",
                    Mobile = "9876543210",
                    LstRegnno = "LST12345",
                    LstRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CstRegnno = "CST54321",
                    CstRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    StRegnno = "ST11111",
                    StRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CustomerId = 1001,
                    TransExistFlag = "N",
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = 1,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 1,
                    IsDeleted = false
                },
                new Carrier
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "Cargo Movers",
                    Type = "Road",
                    Addr1 = "456 NH Road",
                    Addr2 = null,
                    City = "Chennai",
                    CountryId = 101,
                    StateId = 33,
                    Pin = "600001",
                    CpName = "Jane Smith",
                    Email = "support@cargomovers.in",
                    Phone = "04487654321",
                    Mobile = "9123456780",
                    LstRegnno = "LST67890",
                    LstRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CstRegnno = "CST09876",
                    CstRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    StRegnno = "ST22222",
                    StRegndate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CustomerId = 1002,
                    TransExistFlag = "Y",
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = 1,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 1,
                    IsDeleted = false
                }
            );
        }
    }
}
