using Microsoft.AspNetCore.Identity;

namespace DZ7.Entities;

public class MyIdentityUser : IdentityUser
{
    public ICollection<PostEntity> Posts { get; set; } = new List<PostEntity>();
}