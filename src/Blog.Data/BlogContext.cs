namespace Blog.Data
{
    using System;
    using Blog.Data.Base;
    using Blog.Data.Extensions;
    using Blog.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public class BlogContext : IdentityDbContext<IdentityUser>, IBlogContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            this.ChangeTracker.Tracked += OnEntityTracked;
            this.ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        #region DatabaseSets

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogPostKeyword> BlogPostKeywords { get; set; }

        public DbSet<BlogPostTag> BlogPostTags { get; set; }

        public DbSet<Keyword> Keywords { get; set; }

        public DbSet<Tag> Tags { get; set; }

        private void OnEntityTracked(object? sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is IHaveDateCreated entity)
            {
                entity.DateCreated = DateTime.UtcNow;
            }
        }

        private void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is IHaveDateModified entity)
            {
                entity.DateModified = DateTime.UtcNow;
            }
        }

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
