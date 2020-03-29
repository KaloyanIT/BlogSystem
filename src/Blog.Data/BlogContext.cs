namespace Blog.Data
{
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

            modelBuilder.Entity<BlogPostKeyword>()
                .HasKey(bc => new { bc.BlogPostId, bc.KeywordId });

            modelBuilder.Entity<BlogPostKeyword>()
                .HasOne(bc => bc.BlogPost)
                .WithMany(b => b.BlogKeywords)
                .HasForeignKey(bc => bc.BlogPostId);

            modelBuilder.Entity<BlogPostKeyword>()
                .HasOne(bc => bc.Keyword)
                .WithMany(c => c.BlogKeywords)
                .HasForeignKey(bc => bc.KeywordId);

            modelBuilder.Entity<BlogPostTag>()
                .HasKey(bc => new { bc.BlogPostId, bc.TagId });

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bc => bc.BlogPost)
                .WithMany(b => b.BlogTags)
                .HasForeignKey(bc => bc.BlogPostId);

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.BlogPostTag)
                .HasForeignKey(bc => bc.TagId);
        }
    }
}
