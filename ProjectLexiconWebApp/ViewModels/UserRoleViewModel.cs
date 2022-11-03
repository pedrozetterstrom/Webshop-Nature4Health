using Microsoft.AspNetCore.Identity;

namespace ProjectLexiconWebApp.ViewModels;

public class UserRoleViewModel
{
    public class User
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
    public List<User> Users { get; set; } = new();
    public List<IdentityRole> IdentityRoles { get; set; } = new List<IdentityRole>();
}
