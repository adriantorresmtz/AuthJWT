using JWTAuth.Models;

namespace JWTAuth.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
