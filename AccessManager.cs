using FInalprojectAPI.Models;
using Microsoft.AspNetCore.Identity;

public class AccessManager
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccessManager(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> GrantAccessToUserAsync(string managerId, string userId, string accessibleYears)
    {
        var manager = await _userManager.FindByIdAsync(managerId);
        var user = await _userManager.FindByIdAsync(userId);

        // Validate that the manager has access to the years
        if (manager.AccessibleYears.Contains(accessibleYears))
        {
            user.AccessibleYears = accessibleYears;
            await _userManager.UpdateAsync(user);
            return true;
        }

        return false;
    }
}
