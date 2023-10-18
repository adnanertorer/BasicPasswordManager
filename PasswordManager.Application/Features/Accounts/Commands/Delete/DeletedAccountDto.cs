namespace PasswordManager.Application.Features.Accounts.Commands.Delete
{
    public class DeletedAccountDto
    {
        public long Id {  get; set; }
        public string AccountTitle { get; set; }
        public string AccountUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
