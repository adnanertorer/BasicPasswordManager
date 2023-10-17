using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PasswordManager.Domain.Entities.Configurations
{
    public class UserNoteConfiguration : IEntityTypeConfiguration<UserNote>
    {
        public void Configure(EntityTypeBuilder<UserNote> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NoteText).IsRequired();
            builder.Property(x => x.NoteTitle).HasMaxLength(50);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne<User>(u => u.User).WithMany(x => x.UserNotes).HasForeignKey(x => x.UserId);
        }
    }
}
