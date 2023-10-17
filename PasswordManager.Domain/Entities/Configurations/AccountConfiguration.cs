using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Domain.Entities.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.AccountTitle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x=>x.Password).IsRequired().HasMaxLength(64);
            builder.Property(x=>x.Username).IsRequired().HasMaxLength(30);
            builder.Property(x=>x.AccountUrl).IsRequired().HasMaxLength(250);
            builder.Property(x=>x.CreatedAt).IsRequired();
            builder.HasOne<User>(x=>x.User).WithMany(u=>u.Accounts).HasForeignKey(u=>u.UserId);
            builder.HasOne<Category>(x => x.Category).WithMany(u => u.Accounts).HasForeignKey(c => c.CategoryId);
        }
    }
}
