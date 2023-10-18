using Core.Application.Requests;

namespace PasswordManager.Application.Features.Accounts.Queries.GetList
{
    public class GetListAccountWithIdDto
    {
        public long UserId { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}
