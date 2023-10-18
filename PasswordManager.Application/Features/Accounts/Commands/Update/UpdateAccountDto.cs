namespace PasswordManager.Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string AccountTitle { get; set; }
        public long? CategoryId { get; set; }
        public string AccountUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
