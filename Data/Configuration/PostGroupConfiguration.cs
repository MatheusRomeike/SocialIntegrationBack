using Domain.Entities.Company;
using Domain.Entities.PostGroup;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PostGroupConfiguration : BaseConfiguration<PostGroup>
    {
        public override void Configure(EntityTypeBuilder<PostGroup> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(5000);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PostGroups)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Posts)
                .WithOne(x => x.PostGroup)
                .HasForeignKey(x => x.PostGroupId);

        }
    }
}
