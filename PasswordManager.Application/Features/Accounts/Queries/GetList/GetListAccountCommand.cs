using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Features.Accounts.Queries.GetById;
using PasswordManager.Application.Services.Repositories;

namespace PasswordManager.Application.Features.Accounts.Queries.GetList
{
    public class GetListAccountCommand : IRequest<BaseResponse<Paginate<AccountDto>>>
    {
        public required GetListAccountWithIdDto GetListAccountWithIdDto { get; set; }

        public class GetListAccountCommandHandler : IRequestHandler<GetListAccountCommand, BaseResponse<Paginate<AccountDto>>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public GetListAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }
            public async Task<BaseResponse<Paginate<AccountDto>>> Handle(GetListAccountCommand request, CancellationToken cancellationToken)
            {
                var list = await _accountRepository.GetListAsync(predicate: x => x.UserId == request.GetListAccountWithIdDto.UserId, include
                    : i => i.Include(i => i.Category), orderBy: o => o.OrderBy(o => o.AccountTitle), index: request.GetListAccountWithIdDto.PageRequest.PageIndex,
                    size: request.GetListAccountWithIdDto.PageRequest.PageIndex);

                var paginateAccounts = _mapper.Map<Paginate<AccountDto>>(list);
                return BaseResponse<Paginate<AccountDto>>.SuccessFull(paginateAccounts, 200);


            }
        }
    }
}
