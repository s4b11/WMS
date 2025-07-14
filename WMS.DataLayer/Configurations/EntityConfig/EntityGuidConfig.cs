using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WMS.Models;

namespace WMS.DataLayer.Configurations
{
    public class EntityGuIdConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityGuid
    {
        [Obsolete]
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(pf => pf.UniqueGuId)
                   .HasDefaultValueSql("uuid_generate_v4()"); // PostgreSQL random UUID
        }
    }
}