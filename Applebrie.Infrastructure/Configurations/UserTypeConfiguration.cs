using Applebrie.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Applebrie.Infrastructure.Configurations
{
    class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("UserType");

            builder.Property(x => x.Name).HasMaxLength(64);
            builder.Property(x => x.Created).HasDefaultValueSql("GETUTCDATE()");


            builder.HasMany(x => x.Users)
                .WithOne(x => x.UserType)
                .HasForeignKey(x => x.UserTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
