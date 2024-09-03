using Domain.Entities.Account;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AccountConfiguration : BaseConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.SocialMediaAccountId).IsRequired();
            builder.Property(x => x.SocialMediaId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder
                .HasOne(x => x.AccountConfiguration)
                .WithOne(x => x.Account)
                .HasForeignKey<Domain.Entities.Account.AccountConfiguration>(x => x.Id);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);
        }
    }
}
