using AutoMapper;
using PasswordManager.Application.Features.Accounts.Commands.Add;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Features.Accounts.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAccountDto, Account>().ReverseMap();
        }
    }
}
