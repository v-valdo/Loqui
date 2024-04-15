namespace Loqui.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}