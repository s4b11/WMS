using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WMS.Core.Models;

namespace WMS.DataLayer.Configurations
{
    public class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        [Obsolete]
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Primary Key Configuration
            builder.HasKey(p => p.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            // Audit Fields Configuration
            builder.Property(p => p.CreatedBy)
                .IsRequired()
                .HasDefaultValue(1); // Default system user

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.ModifiedBy)
                .HasDefaultValue(0); // Null until modified

            builder.Property(p => p.ModifiedDate);

            // Soft Delete Configuration
            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}