using DZ8.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DZ8.Data;

public class ApplicationDbContext : IdentityDbContext<MyIdentityUserEntity>
{
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<BookModel> Books { get; set; }
    
    public DbSet<PostEntity> Posts { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}