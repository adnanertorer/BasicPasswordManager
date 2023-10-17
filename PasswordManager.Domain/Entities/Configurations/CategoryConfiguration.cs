using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Domain.Entities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x=>x.CreatedAt).IsRequired();
            builder.HasOne<User>(u=>u.User).WithMany(x=>x.Categories).HasForeignKey(x=>x.UserId);
        }
    }
}
