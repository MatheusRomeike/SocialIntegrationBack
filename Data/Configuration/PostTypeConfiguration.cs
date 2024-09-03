using Domain.Entities.Account;
using Domain.Entities.SocialMedia;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class PostTypeConfiguration : BaseConfiguration<PostType>
    {
        public override void Configure(EntityTypeBuilder<PostType> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SocialMediaId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaxCharacters).IsRequired();
            builder.Property(x => x.AcceptedMediaTypes).IsRequired();
            builder.Property(x => x.MediaAspectRatio).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.SocialMedia)
                .WithMany(x => x.PostTypes)
                .HasForeignKey(x => x.SocialMediaId)
                .IsRequired();
        }
    }
}
