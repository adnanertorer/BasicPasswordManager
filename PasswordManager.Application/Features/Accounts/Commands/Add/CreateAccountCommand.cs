using AutoMapper;
using Core.Application.Responses;
using MediatR;
using PasswordManager.Application.Features.Accounts.Rules;
using PasswordManager.Application.Services.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Features.Accounts.Commands.Add
{
    public class CreateAccountCommand : IRequest<BaseResponse<CreateAccountDto>>
    {
        public required CreateAccountDto CreateAccountDto { get; set; }

        public class CreateAccoundCommandHandler : IRequestHandler<CreateAccountCommand, BaseResponse<CreateAccountDto>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;
            private readonly AccountBusinessRules _accountBusinessRules;

            public CreateAccoundCommandHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
                _accountBusinessRules = accountBusinessRules;
            }

            public async Task<BaseResponse<CreateAccountDto>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
            {
                await _accountBusinessRules.CannotBeDuplicate(request.CreateAccountDto.Username, request.CreateAccountDto.AccountTitle);
                
                request.CreateAccountDto.CreatedAt = DateTime.UtcNow ;
                var model = await _accountRepository.AddAsync(_mapper.Map<Account>(request.CreateAccountDto));
                return BaseResponse<CreateAccountDto>.SuccessFull(_mapper.Map<CreateAccountDto>(model), 200);

            }
        }
    }
}
