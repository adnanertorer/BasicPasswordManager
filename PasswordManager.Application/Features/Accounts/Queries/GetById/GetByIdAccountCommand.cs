using AutoMapper;
using Core.Application.Responses;
using MediatR;
using PasswordManager.Application.Services.Repositories;

namespace PasswordManager.Application.Features.Accounts.Queries.GetById
{
    public class GetByIdAccountCommand : IRequest<BaseResponse<AccountDto>>
    {
        public long Id { get; set; }

        public class GetByIdAccountCommandHandler : IRequestHandler<GetByIdAccountCommand, BaseResponse<AccountDto>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public GetByIdAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }
            public async Task<BaseResponse<AccountDto>> Handle(GetByIdAccountCommand request, CancellationToken cancellationToken)
            {
                var model = await _accountRepository.GetAsync(predicate: x=>x.Id == request.Id);
                return BaseResponse<AccountDto>.SuccessFull(_mapper.Map<AccountDto>(model), 200);
            }
        }
    }
}
