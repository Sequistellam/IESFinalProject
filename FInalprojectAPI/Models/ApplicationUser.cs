using Microsoft.AspNetCore.Identity;

namespace FInalprojectAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add a property to represent the years a user can access
        public string AccessibleYears { get; set; }
    }
}
