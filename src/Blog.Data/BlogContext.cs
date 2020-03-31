namespace Blog.Data
{
    using Blog.Data.Extensions;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BlogContext : IdentityDbContext<IdentityUser>, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        #region DatabaseSets

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogPostKeyword> BlogPostKeywords { get; set; }

        public DbSet<BlogPostTag> BlogPostTags { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<Tag> Tags { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                                    => optionsBuilder
                                        .UseLazyLoadingProxies();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyDbConfiguration();
        }
    }
}
