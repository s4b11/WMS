using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class UserConfig : EntityGuIdConfig<User>
    {
        [Obsolete]
        public override void Configure(EntityTypeBuilder<User> builder)
        { 
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20);

            builder.HasData(
                new User
                {
                    Id = 1,
                    UniqueGuId = Guid.NewGuid(),
                    Username = "admin",
                    PasswordHash = "$2a$12$HLfQhL/tjH2zrY35XCVsmex2Qup7Tr3p5Xu3CyrAVDmRA35RaxOz.",
                    Email = "admin@example.com",
                    Role = "Admin",
                    IsDeleted = false,
                    CreatedBy = 0,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 0,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 2,
                    UniqueGuId = Guid.NewGuid(),
                    Username = "user",
                    PasswordHash = "$2a$12$6ngObu3BSe8Zk5/UIM1ckeNQ5wSpc7GzM1hc.1BEOBtKYkX.5.0NC",
                    Email = "user@example.com",
                    Role = "User",
                    IsDeleted = false,
                    CreatedBy = 0,
                    CreatedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    ModifiedBy = 0,
                    ModifiedDate = new DateTime(2020, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                }
            );

        }
    }
}