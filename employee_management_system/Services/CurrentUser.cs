using System.Security.Claims;

namespace employee_management_system.Services;

public interface ICurrentUser
{
    Task<int> GetCurrentUserIdAsync();
    Task<string> GetCurrentUserNameAsync();
    Task<string> GetCurrentUserRoleAsync();
}
public class CurrentUser(IHttpContextAccessor _httpContextAccessor) : ICurrentUser
{
    public async Task<int> GetCurrentUserIdAsync()
    {
        // Retrieve the user's ID from the claims
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("Id");
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            return userId;
        }

        // Default value or error handling
        return 0;
    }

    public async Task<string> GetCurrentUserNameAsync()
    {
        // Retrieve the user's username from the claims
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name)?.Value;
    }

    public async Task<string> GetCurrentUserRoleAsync()
    {
        // Retrieve the user's role from the claims
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
    }
}
