using Domain.Entities.Account;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AccountConfigurationConfiguration : BaseConfiguration<Domain.Entities.Account.AccountConfiguration>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Account.AccountConfiguration> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.AccessToken).IsRequired().HasMaxLength(500);
            builder.Property(x => x.RefreshToken).HasMaxLength(500);
            builder.Property(x => x.TokenType).HasMaxLength(50);

            builder
                .HasOne(x => x.Account)
                .WithOne(x => x.AccountConfiguration)
                .HasForeignKey<Domain.Entities.Account.AccountConfiguration>(x => x.Id);
        }
    }
}
