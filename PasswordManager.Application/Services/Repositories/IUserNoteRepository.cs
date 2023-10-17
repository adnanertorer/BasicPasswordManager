using Core.Persistance.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Services.Repositories
{
    public interface IUserNoteRepository : IAsyncRepository<UserNote, long>
    {
    }
}
