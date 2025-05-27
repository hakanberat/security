using SafeVaultApp.Models;
using SafeVaultApp.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SafeVaultApp.Services {
    public class AuthService {
        private List<User> users = new List<User> {
            new User { Id = 1, Username = "admin", HashedPassword = PasswordHelper.HashPassword("1234"), Role = "admin" },
            new User { Id = 2, Username = "user", HashedPassword = PasswordHelper.HashPassword("abcd"), Role = "user" }
        };

        public User? Authenticate(string username, string password) {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == null) return null;

            if (PasswordHelper.VerifyPassword(password, user.HashedPassword)) {
                return user;
            }

            return null;
        }
    }
}
