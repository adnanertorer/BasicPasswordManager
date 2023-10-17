using Core.Persistance.Repositories;

namespace PasswordManager.Domain.Entities
{
    public class Account:Entity<long>
    {
        public long UserId { get; set; }
        public string AccountTitle { get; set; }
        public long? CategoryId { get; set; }
        public string AccountUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Category? Category { get; set; }
        public User User { get; set; }
    }
}
