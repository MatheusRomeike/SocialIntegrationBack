using Domain.Entities.SocialMedia;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class SocialMediaConfigurationConfiguration : BaseConfiguration<Domain.Entities.SocialMedia.SocialMediaConfiguration>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.SocialMedia.SocialMediaConfiguration> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.BaseUrl).HasMaxLength(100);
            builder.Property(x => x.AuthorizationUrl).HasMaxLength(100);
            builder.Property(x => x.ClientId).HasMaxLength(100);
            builder.Property(x => x.ClientSecret).HasMaxLength(100);
            builder.Property(x => x.RedirectUri).HasMaxLength(100);
            builder.Property(x => x.Scope).HasMaxLength(100);
            builder.Property(x => x.GrantType).HasMaxLength(100);
            builder.Property(x => x.ResponseType).HasMaxLength(100);
            builder.Property(x => x.ExtraUrlInfo).HasMaxLength(100);

            builder
                .HasOne(x => x.SocialMedia)
                .WithOne(x => x.SocialMediaConfiguration)
                .HasForeignKey<Domain.Entities.SocialMedia.SocialMediaConfiguration>(x => x.Id);

        }
    }
}
