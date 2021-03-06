﻿namespace Blog.Data.Models.Context
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Base.Contracts;
    using Base.Extensions;
    using Comments;
    using Controllers.Helpers;
    using Files;
    using Infrastructure.Constants;
    using Links;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Models;
    using Models.Emails;
    using Models.Meta;


    public class BlogContext : IdentityDbContext<User, Role, string>, IBlogContext
    {
        [NotNull]
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogContext(DbContextOptions<BlogContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            ChangeTracker.Tracked += OnEntityTracked;
            ChangeTracker.StateChanged += OnEntityStateChanged;

            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        #region DatabaseSets

        public DbSet<BlogPost> Blogs { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<BlogPostKeyword> BlogPostKeywords { get; set; } = null!;

        public DbSet<BlogPostTag> BlogPostTags { get; set; } = null!;

        public DbSet<Keyword> Keywords { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<Settings> Settings { get; set; } = null!;

        //Emails Models

        public DbSet<MailList> MailLists { get; set; } = null!;

        public DbSet<Subscriber> Subscribers { get; set; } = null!;

        public DbSet<MailListSubscriber> MailListSubscribers { get; set; } = null!;

        public DbSet<OpenGraph> OpenGraphs { get; set; } = null!;

        public DbSet<File> Files { get; set; } = null!;

        public DbSet<Library> Library { get; set; } = null!;

        public DbSet<Link> Link { get; set; } = null!;

        public DbSet<ContactData> ContactsData { get; set; } = null!;

        private void OnEntityTracked(object? sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is IHaveDateCreated entity)
            {
                entity.DateCreated = DateTime.UtcNow;
            }

            if (!e.FromQuery && e.Entry.State == EntityState.Added
                && e.Entry.Entity is IHaveCreatedBy userEntity
                && _httpContextAccessor.HttpContext != null)
            {
                userEntity.CreatedBy = _httpContextAccessor.HttpContext!.User.GetLoggedInUserId<string>();
            }
        }

        private void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is IHaveDateModified entity)
            {
                entity.DateModified = DateTime.UtcNow;
            }

            if (e.NewState == EntityState.Modified
                && e.Entry.Entity is IHaveModifiedBy userEntity
                && _httpContextAccessor.HttpContext != null)
            {
                userEntity.ModifiedBy = _httpContextAccessor.HttpContext!.User.GetLoggedInUserId<string>()!;
            }
        }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>(entity => { entity.ToTable(name: DataBaseConstants.RolesTableName); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable(DataBaseConstants.UserRolesTableName); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable(DataBaseConstants.UserClaimsTableName); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable(DataBaseConstants.UserLoginTableName); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable(DataBaseConstants.UserTokenTableName); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable(DataBaseConstants.RoleClaimTableName); });

            modelBuilder.ApplyDbConfiguration();
        }
    }
}
