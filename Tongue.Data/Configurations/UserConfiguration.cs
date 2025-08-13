using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tongue.Data.Models.Users;

namespace Tongue.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);
        builder
            .Property(u => u.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("current_timestamp");
        builder
            .Property(u => u.Disabled)
            .IsRequired()
            .HasDefaultValue(0);
        builder
            .Property(u => u.DisabledAt)
            .IsRequired(false);
    }
}
