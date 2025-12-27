using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace DZ8.Entities;

public class MyIdentityUserEntity : IdentityUser
{
    // [JsonIgnore]
    public ICollection<PostEntity> Posts { get; set; } = new List<PostEntity>();
}