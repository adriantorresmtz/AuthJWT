using JWTAuth.Models;
using JWTAuth.Repositories;

namespace JWTAuth.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(w => 
                        w.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) &&
                        w.Password.Equals(userLogin.Password, StringComparison.OrdinalIgnoreCase)
                        ); 

            return user;
            
        }
    }
}
