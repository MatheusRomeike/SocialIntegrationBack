using Domain.Entities.Company;
using Domain.Entities.PostImage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PostImageConfiguration : BaseConfiguration<PostImage>
    {
        public override void Configure(EntityTypeBuilder<PostImage> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Order).IsRequired();

            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostImages)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Image)
                .WithMany(x => x.PostImages)
                .HasForeignKey(x => x.ImageId);
        }
    }
}
