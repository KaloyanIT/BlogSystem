﻿using System;
using Blog.Data.Base;

namespace Blog.Data.Models
{
    public class BlogPostKeyword : BaseDbObject
    {
        public Guid BlogPostId { get; set; }

        public BlogPost BlogPost { get; set; }

        public Guid KeywordId { get; set; }

        public Keyword Keyword { get; set; }
    }
}
