using Microsoft.AspNetCore.Identity;

namespace DZ6.Models;

public class MyIdentityUser : IdentityUser
{
    public ICollection<PostModel> Posts { get; set; } = new List<PostModel>();
}