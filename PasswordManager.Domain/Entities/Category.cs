using Core.Persistance.Repositories;

namespace PasswordManager.Domain.Entities
{
    public class Category:Entity<long>
    {
        public string Name { get; set; }
        public long UserId { get; set; }

        public User User { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
