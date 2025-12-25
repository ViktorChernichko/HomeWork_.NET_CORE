using DZ6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DZ6.Data;

public class ApplicationDbContext : IdentityDbContext<MyIdentityUser>
{
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<BookModel> Books { get; set; }
    
    public DbSet<PostModel> Posts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}