using Domain.Entities.Account;
using Domain.Entities.Company;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AccountConfiguration : BaseConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.SocialNetwork)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.SocialNetworkId)
                .IsRequired();

        }
    }
}
