using JWTAuth.Models;

namespace JWTAuth.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new()
            {
                Username = "admin",
                EmailAddress = "user.admin@email.com",
                Password = "admin",
                GivenName = "Admin",
                Surname = "Main",
                Rol = "Administrator"
            },
            new()
            {
                Username = "user",
                EmailAddress = "username@email.com",
                Password = "user",
                GivenName = "User",
                Surname = "Name",
                Rol = "Standard"
            }
        };

    }
}
