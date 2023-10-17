using Core.Persistance.Repositories;

namespace PasswordManager.Domain.Entities
{
    public class UserNote: Entity<long>
    {
        public long UserId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteText { get; set; }

        public User User { get; set; }
    }
}
