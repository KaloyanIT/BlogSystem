﻿namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    using Base;

    public class BlogPost : BaseDbObject
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Summary { get; private set; }

        public bool ShowOnHomePage { get; private set; }

        public string UserId { get; private set; }

        public virtual IdentityUser User { get; private set; }

        public virtual ICollection<BlogPostKeyword> BlogKeywords { get; private set; }

        public virtual ICollection<BlogPostTag> BlogTags { get; private set; }

        public BlogPost() : base()
        {
        }

        public BlogPost(string title, string content, string summary, string userId, bool showOnHomePage = true) : base()
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("BlogPost title");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("BlogPost content");
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentNullException("BlogPost Summary");
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException("BlogPost UserId");
            }

            Title = title;
            Content = content;
            Summary = summary;
            UserId = userId;
            ShowOnHomePage = showOnHomePage;
        }
    }
}
