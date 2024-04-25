using Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(i => i.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.HasKey(i => i.Id);

            builder.Property(i => i.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(i => i.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(i => i.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamp without time zone")
                .IsRequired(false);

            builder.HasQueryFilter(i => i.DeletedAt == null);
        }
    }
}
