using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Domain.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SmsCode).HasMaxLength(6);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.RefreshToken).HasMaxLength(64);
        }
    }
}
