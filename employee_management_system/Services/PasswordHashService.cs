using employee_management_system.Models;
using Microsoft.AspNetCore.Identity;

namespace employee_management_system.Services
{
    public interface IPasswordHashService
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword);
    }

    public class PasswordHashService(IPasswordHasher<UserModel> _passwordHasher) : IPasswordHashService
    {
      
        public async Task<string> HashPasswordAsync(string password)
        {
            return await Task.Run(() =>
            {
                var hashedPassword = _passwordHasher.HashPassword(null, password);
                return hashedPassword;
            });
        }

        public async Task<bool> VerifyPasswordAsync(string hashedPassword, string providedPassword)
        {
            return await Task.Run(() =>
            {
                var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
                return result == PasswordVerificationResult.Success;
            });
        }
    }
}
