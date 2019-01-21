using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogContext : IdentityDbContext<IdentityUser>, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
