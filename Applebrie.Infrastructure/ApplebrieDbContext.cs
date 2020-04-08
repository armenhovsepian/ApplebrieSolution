using Applebrie.Core.Entities;
using Applebrie.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Applebrie.Infrastructure
{
    public class ApplebrieDbContext : DbContext
    {
        public ApplebrieDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            //builder.Entity<UserType>().HasData(
            //    new UserType { Id = 1, Name = "Administrator" },
            //    new UserType { Id = 1, Name = "User" },
            //    new UserType { Id = 1, Name = "Guest" }
            //);

            //builder.Entity<User>().HasData(
            //    new User { Id = 1, FirstName = "Armen", LastName = "Hovsepian", UserTypeId = 1 }
            //);

            base.OnModelCreating(builder);
        }
    }
}
