using Domain.Entities.Account;
using Domain.Entities.Core;
using Domain.Entities.Post;
using Domain.Entities.SocialMedia;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Application.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Property(i => i.CreatedAt).IsModified = false;
                        entry.Entity.UpdatedAt = DateTime.Now;

                        break;
                    case EntityState.Added:
                        if (entry.Entity.CreatedAt.Year == 1)
                            entry.Entity.CreatedAt = DateTime.Now;

                        if (entry.Entity.UpdatedAt.Year == 1)
                            entry.Entity.UpdatedAt = DateTime.Now;

                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Environment
#if DEBUG
            DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env.local"));
#else
                DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
#endif
            #endregion

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

            foreach (var table in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var p in table.GetProperties()
                             .Where(p => p.PropertyInfo?.PropertyType == typeof(DateTime) ||
                                         p.PropertyInfo?.PropertyType == typeof(DateTime?)))
                {
                    p.SetColumnType("timestamp without time zone");
                }
            }

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AccountConfiguration> AccountConfiguration { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<SocialMediaConfiguration> SocialMediaConfiguration { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<User> User { get; set; }

    }
}
