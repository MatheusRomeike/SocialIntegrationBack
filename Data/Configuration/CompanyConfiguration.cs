using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class CompanyConfiguration : BaseConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
        }
    }
}
