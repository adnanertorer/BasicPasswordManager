using AutoMapper;
using Core.Application.Responses;
using MediatR;
using PasswordManager.Application.Features.Accounts.Constants;
using PasswordManager.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.Accounts.Commands.Delete
{
    public class DeleteAccountCommand : IRequest<BaseResponse<DeletedAccountDto>>
    {
        public long Id { get; set; }

        public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, BaseResponse<DeletedAccountDto>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public DeleteAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }
            public async Task<BaseResponse<DeletedAccountDto>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
            {
                var model = await _accountRepository.GetAsync(predicate: x => x.Id == request.Id);
                if (model == null)
                {
                    return BaseResponse<DeletedAccountDto>.Fail(Consts.AccountNotFound_TR, 404);
                }

                await _accountRepository.DeleteAsync(model, true);
                return BaseResponse<DeletedAccountDto>.SuccessFull(_mapper.Map<DeletedAccountDto>(model), 200);
            }
        }
    }
}
