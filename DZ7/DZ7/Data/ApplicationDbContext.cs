using DZ7.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DZ7.Data;

public class ApplicationDbContext : IdentityDbContext<MyIdentityUser>
{
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<BookModel> Books { get; set; }
    
    public DbSet<PostEntity> Posts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}