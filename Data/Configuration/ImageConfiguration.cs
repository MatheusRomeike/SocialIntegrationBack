using Domain.Entities.Company;
using Domain.Entities.Image;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ImageConfiguration : BaseConfiguration<Image>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Url).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Caption).HasMaxLength(255);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.CompanyId);

        }
    }
}
