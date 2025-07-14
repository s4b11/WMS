using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Core.Models;
using WMS.Models.Models.CompanyModel;
using System;

namespace WMS.DataLayer.Configurations
{
    public class CompanyConfig : EntityGuIdConfig<Company>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Addr1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Addr2)
                .HasMaxLength(100);

            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CountryId)
                .IsRequired();

            builder.Property(p => p.StateId)
                .IsRequired();

            builder.Property(p => p.Pin)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ContactPerson)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CPMobile)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.EmailID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CPEmailID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.URL)
                .HasMaxLength(100);

            builder.Property(p => p.ECCNO)
                .HasMaxLength(100);

            builder.Property(p => p.TINNO)
                .HasMaxLength(100);

            builder.Property(p => p.CSTNO)
                .HasMaxLength(100);

            builder.Property(p => p._3PLFlag)
                .HasMaxLength(1)
                .HasDefaultValue("N");

            builder.Property(p => p.TransExistFlag)
                .HasMaxLength(1)
                .HasDefaultValue("N");

            builder.Property(p => p.ImagePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.ImageName)
                .IsRequired()
                .HasMaxLength(255);

            // Seed data
            builder.HasData(
                new Company
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "ABC Corporation",
                    Code = "ABC001",
                    Addr1 = "123 Main Street",
                    Addr2 = "Suite 500",
                    City = "New York",
                    StateId = 1, // Assuming NY is stateId 1
                    CountryId = 1, // Assuming US is countryId 1
                    Pin = "10001",
                    ContactPerson = "John Smith",
                    Phone = "+1-212-555-1234",
                    CPMobile = "+1-917-555-5678",
                    EmailID = "info@abccorp.com",
                    CPEmailID = "john.smith@abccorp.com",
                    URL = "www.abccorp.com",
                    BaseCurr = 1, // Assuming USD is 1
                    ECCNO = "EC12345678",
                    TINNO = "TIN987654",
                    TINDATE = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    CSTDATE = new DateTime(2020, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                    CSTNO = "CST456789",
                    UserID = 1, // Admin user
                    _3PLFlag = "N",
                    TransExistFlag = "Y",
                    Image = new byte[0], // Empty byte array for seed
                    ImagePath = "/images/companies/abc-corp.jpg",
                    ImageName = "abc-corp.jpg"
                },
                new Company
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Name = "XYZ Logistics",
                    Code = "XYZ002",
                    Addr1 = "456 Commerce Road",
                    City = "Chicago",
                    StateId = 2, // Assuming IL is stateId 2
                    CountryId = 1, // US
                    Pin = "60601",
                    ContactPerson = "Sarah Johnson",
                    Phone = "+1-312-555-7890",
                    CPMobile = "+1-312-555-7891",
                    EmailID = "contact@xyzlogistics.com",
                    CPEmailID = "sarah.j@xyzlogistics.com",
                    URL = "www.xyzlogistics.com",
                    BaseCurr = 1, // USD
                    UserID = 1,
                    _3PLFlag = "Y",
                    TransExistFlag = "N",
                    Image = new byte[0],
                    ImagePath = "/images/companies/xyz-logistics.jpg",
                    ImageName = "xyz-logistics.jpg"
                }
            );
        }
    }
}