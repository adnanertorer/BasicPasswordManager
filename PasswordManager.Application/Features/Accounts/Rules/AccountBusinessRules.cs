using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using PasswordManager.Application.Features.Accounts.Constants;
using PasswordManager.Application.Services.Repositories;

namespace PasswordManager.Application.Features.Accounts.Rules
{
    public class AccountBusinessRules : BaseBusinessRoles
    {
        private readonly IAccountRepository _accountRepository;

        public AccountBusinessRules(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task CannotBeDuplicate(string username, string title)
        {
            var account = await _accountRepository.GetAsync(i=>i.Username.ToLower() == username.ToLower() 
            && i.AccountTitle.ToLower() == title.ToLower());
            if(account != null) {
                throw new BusinessException(Consts.AccountExist_TR);
            }
        }
    }
}
