using Domain.Entities.Account;
using Domain.Entities.Company;
using Domain.Entities.Core;
using Domain.Entities.Image;
using Domain.Entities.Post;
using Domain.Entities.PostGroup;
using Domain.Entities.PostImage;
using Domain.Entities.SocialNetwork;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Application.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
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

        public DbSet<Account> Account { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostGroup> PostGroup { get; set; }
        public DbSet<PostImage> PostImage { get; set; }
        public DbSet<SocialNetwork> SocialNetwork { get; set; }
        public DbSet<User> User { get; set; }

    }
}
