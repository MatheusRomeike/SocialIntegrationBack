using Domain.Entities.Post;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PostConfiguration : BaseConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => new { x.Id, x.AccountId });

            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.SocialMediaPostId).IsRequired();
            builder.Property(x => x.SocialMediaId).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ImageQuantity);

            builder
                .HasOne(x => x.Account)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
