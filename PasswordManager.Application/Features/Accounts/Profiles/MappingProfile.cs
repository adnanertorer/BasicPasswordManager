using AutoMapper;
using PasswordManager.Application.Features.Accounts.Commands.Add;
using PasswordManager.Application.Features.Accounts.Commands.Delete;
using PasswordManager.Application.Features.Accounts.Commands.Update;
using PasswordManager.Application.Features.Accounts.Queries.GetById;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Features.Accounts.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAccountDto, Account>().ReverseMap();
            CreateMap<UpdateAccountDto, Account>().ReverseMap();
            CreateMap<DeletedAccountDto, Account>().ReverseMap();
            CreateMap<AccountDto, Account>().ReverseMap();
        }
    }
}
