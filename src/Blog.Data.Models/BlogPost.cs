namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Base;

    public class BlogPost : BaseDbObject
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Summary { get; private set; }

        public bool ShowOnHomePage { get; private set; }

        public string UserId { get; private set; }

        public User? User { get; private set; }

        public ICollection<BlogPostKeyword>? BlogKeywords { get; private set; }

        public ICollection<BlogPostTag>? BlogTags { get; private set; }

        public BlogPost()
        {
            Title = string.Empty;
            Content = string.Empty;
            Summary = string.Empty;
            UserId = string.Empty;
            ShowOnHomePage = true;
        }

        public BlogPost(string title, string content, string summary, string userId, bool showOnHomePage = true) : base()
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "BlogPost title");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content), "BlogPost content");
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentNullException(nameof(summary), "BlogPost Summary");
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId), "BlogPost UserId");
            }

            Title = title;
            Content = content;
            Summary = summary;
            UserId = userId;
            ShowOnHomePage = showOnHomePage;
        }
    }
}
