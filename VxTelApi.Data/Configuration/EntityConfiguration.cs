﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VxTel.Domain.Entities;

namespace VxTelApi.Data.Configuration
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(m => m.DateCreated).HasColumnType(DataConstants.SqlServer.DateTime2).HasDefaultValueSql(DataConstants.SqlServer.SysDateTime);
            builder.Property(p => p.DateUpdated).HasColumnType(DataConstants.SqlServer.DateTime2);
        }
    }
}