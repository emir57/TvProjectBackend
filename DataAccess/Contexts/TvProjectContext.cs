using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DataAccess.Contexts
{
    public class TvProjectContext : DbContext
    {
        public TvProjectContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(getConnectionString("SqlServer"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Tv> Tvs { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<TvBrand> TvBrands { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserCreditCard> UserCreditCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserCode> UserCodes { get; set; }

        private string getConnectionString(string name)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString(name);
            return connectionString;
        }
    }
}
