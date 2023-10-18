using AutoMapper;
using Core.Application.Responses;
using MediatR;
using PasswordManager.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountCommand : IRequest<BaseResponse<UpdateAccountDto>>
    {
        public required UpdateAccountDto UpdateAccountDto { get; set; }

        public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, BaseResponse<UpdateAccountDto>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }

            public async Task<BaseResponse<UpdateAccountDto>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
            {
                request.UpdateAccountDto.UpdatedAt = DateTime.UtcNow;
                var model = await _accountRepository.GetAsync(predicate: x => x.Id == request.UpdateAccountDto.Id);

                _mapper.Map(request.UpdateAccountDto, model); 

                var updatedResource = await _accountRepository.UpdateAsync(model!);
                return BaseResponse<UpdateAccountDto>.SuccessFull(_mapper.Map<UpdateAccountDto>(updatedResource), 204);
            }
        }
    }
}
