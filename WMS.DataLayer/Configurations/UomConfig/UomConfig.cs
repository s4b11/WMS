using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class UomConfig : EntityGuIdConfig<Uom>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<Uom> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Short)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.TransExistFlag)
                .HasMaxLength(1)
                .HasDefaultValue("N");

            builder.HasData(
                new Uom
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    IsDeleted = false,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 1,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    Name = "Kilogram",
                    Short = "kg",
                    TransExistFlag = "Y"
                },
                new Uom
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    IsDeleted = false,
                    CreatedBy = 1,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 1,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    Name = "Liter",
                    Short = "L",
                    TransExistFlag = "Y"
                }
            );
        }
    }
}