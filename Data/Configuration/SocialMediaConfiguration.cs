using Domain.Entities.SocialMedia;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class SocialMediaConfiguration : BaseConfiguration<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(100);

            builder
                .HasOne(x => x.SocialMediaConfiguration)
                .WithOne(x => x.SocialMedia)
                .HasForeignKey<Domain.Entities.SocialMedia.SocialMediaConfiguration>(x => x.Id);

            builder
                .HasMany(x => x.PostTypes)
                .WithOne(x => x.SocialMedia)
                .HasForeignKey(x => x.SocialMediaId);
        }
    }
}
