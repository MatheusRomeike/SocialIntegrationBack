using Domain.Entities.SocialNetwork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class SocialNetworkConfiguration : BaseConfiguration<SocialNetwork>
    {
        public override void Configure(EntityTypeBuilder<SocialNetwork> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(255);
            builder.Property(x => x.BaseUrlApi).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.SocialNetwork)
                .HasForeignKey(x => x.SocialNetworkId);
        }
    }
}
