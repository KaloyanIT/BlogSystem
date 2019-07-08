using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.UnitTests.Domain
{
    public class BlogPostTagShould
    {
        [Fact]
        public void ThrowsArgumentNullException_WhenBlogPostId_IsGuidEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostTag(Guid.Empty, Guid.NewGuid()));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenTagId_IsGuidEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostTag(Guid.NewGuid(), Guid.Empty));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenBlogPost_IsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostTag(null, new Tag()));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenTag_IsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostTag(new BlogPost(), null));
        }

        [Fact]
        public void SetBlogPostId_WhenIsValid()
        {
            //Arrange
            var blogPostId = Guid.NewGuid();
            //Act
            var blogPostKeyword = new BlogPostTag(blogPostId, Guid.NewGuid());
            //Assert

            Assert.Equal(blogPostId, blogPostKeyword.BlogPostId);
        }

        [Fact]
        public void SetBlogPost_WhenIsNotNull()
        {
            //Arrange
            var blogPost = new BlogPost();
            var keyword = new Tag();
            //Act
            var blogPostKeyword = new BlogPostTag(blogPost, keyword);
            //Assert

            Assert.Same(blogPost, blogPostKeyword.BlogPost);
        }

        [Fact]
        public void SetTagId_WhenIsValid()
        {
            //Arrange
            var blogPostId = Guid.NewGuid();
            var tagId = Guid.NewGuid();
            //Act
            var blogPostKeyword = new BlogPostTag(blogPostId, tagId);
            //Assert

            Assert.Equal(tagId, blogPostKeyword.TagId);
        }

        [Fact]
        public void SetTag_WhenIsNotNull()
        {
            //Arrange
            var blogPost = new BlogPost();
            var tag = new Tag();
            //Act
            var blogPostKeyword = new BlogPostTag(blogPost, tag);
            //Assert

            Assert.Same(tag, blogPostKeyword.Tag);
        }
    }
}
