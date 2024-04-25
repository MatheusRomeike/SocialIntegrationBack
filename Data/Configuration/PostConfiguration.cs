using Domain.Entities.Company;
using Domain.Entities.Post;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PostConfiguration : BaseConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SocialNetworkPostId)
                .IsRequired();

            builder.HasOne(x => x.PostGroup)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.PostGroupId)
                .IsRequired();

            builder.HasOne(x => x.Account)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AccountId)
                .IsRequired();

        }
    }
}
