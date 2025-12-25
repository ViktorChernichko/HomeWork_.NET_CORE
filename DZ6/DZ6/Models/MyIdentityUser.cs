using Microsoft.AspNetCore.Identity;

namespace DZ6.Entities;

public class MyIdentityUser : IdentityUser
{
    public ICollection<PostEntity> Posts { get; set; } = new List<PostEntity>();
}