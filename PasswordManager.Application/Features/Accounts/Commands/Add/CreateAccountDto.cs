namespace PasswordManager.Application.Features.Accounts.Commands.Add
{
    public class CreateAccountDto
    {
        public long UserId { get; set; }
        public string AccountTitle { get; set; }
        public long? CategoryId { get; set; }
        public string AccountUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
