using Microsoft.EntityFrameworkCore;
using WebForumSecurity_Blazor.Models;

namespace WebForumSecurity_Blazor.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
