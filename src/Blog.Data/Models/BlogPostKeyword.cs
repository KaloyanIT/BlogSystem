﻿using System;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class BlogPostKeyword : BaseDbObject
    {
        public Guid BlogPostId { get; private set; }

        public virtual BlogPost BlogPost { get; private set; }

        public Guid KeywordId { get; private private set; }

        public virtual Keyword Keyword { get; private set; }

        public BlogPostKeyword()
        {

        }

        public BlogPostKeyword(Guid blogPostId, Guid keywordId)
        {
            if(blogPostId == Guid.Empty)
            {
                throw new ArgumentNullException("BlogPostKeyword blogPostId can not be empty guid.");
            }

            if (keywordId == Guid.Empty)
            {
                throw new ArgumentNullException("BlogPostKeyword keywordId can not be empty guid.");
            }

            this.BlogPostId = blogPostId;
            this.KeywordId = keywordId;
        }

        public BlogPostKeyword(BlogPost blogPost, Keyword keyword)
        {
            if(blogPost == null)
            {
                throw new ArgumentNullException("BlogPostKeyword BlogPost can not be null.");
            }

            if (keyword == null)
            {
                throw new ArgumentNullException("BlogPostKeyword Keyword can not be null.");
            }

            this.BlogPost = blogPost;
            this.Keyword = keyword;
        }
    }
}
