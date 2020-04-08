using Applebrie.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Applebrie.Infrastructure.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.FirstName).HasMaxLength(64);
            builder.Property(x => x.LastName).HasMaxLength(64);
            builder.Property(x => x.Created).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
