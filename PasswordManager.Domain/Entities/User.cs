using Core.Persistance.Repositories;

namespace PasswordManager.Domain.Entities
{
    public class User:UserEntity
    {
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<UserNote> UserNotes { get; set; }
    }
}
