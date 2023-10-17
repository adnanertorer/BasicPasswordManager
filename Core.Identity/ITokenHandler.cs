using Core.Persistance.Repositories;

namespace Core.Identity
{
    public interface ITokenHandler<T> where T : UserEntity
    {
        Task<AccessToken> CreateAccessToken(T resource);
        AccessToken? ReturnAccessToken(T resource);
        void RevokeRefreshToken(T resource);
    }
}
