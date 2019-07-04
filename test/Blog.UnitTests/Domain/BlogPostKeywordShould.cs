using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.UnitTests.Domain
{
    public class BlogPostKeywordShould
    {
        [Fact]
        public void ThrowsArgumentNullException_WhenBlogPostId_IsGuidEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostKeyword(Guid.Empty, Guid.NewGuid()));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenKeywordId_IsGuidEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostKeyword(Guid.NewGuid(), Guid.Empty));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenBlogPost_IsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostKeyword(null, new Keyword()));
        }

        [Fact]
        public void ThrowsArgumentNullException_WhenKeyword_IsNull()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPostKeyword(new BlogPost(), null));
        }

        [Fact]
        public void SetBlogPostId_WhenIsValid()
        {
            //Arrange
            var blogPostId = Guid.NewGuid();
            //Act
            var blogPostKeyword = new BlogPostKeyword(blogPostId, Guid.NewGuid());
            //Assert

            Assert.Equal(blogPostId, blogPostKeyword.BlogPostId);
        }

        [Fact]
        public void SetBlogPost_WhenIsNotNull()
        {
            //Arrange
            var blogPost = new BlogPost();
            var keyword = new Keyword();
            //Act
            var blogPostKeyword = new BlogPostKeyword(blogPost, keyword);
            //Assert

            Assert.Same(blogPost, blogPostKeyword.BlogPost);
        }

        [Fact]
        public void SetKeywordId_WhenIsValid()
        {
            //Arrange
            var blogPostId = Guid.NewGuid();
            var keywordId = Guid.NewGuid();
            //Act
            var blogPostKeyword = new BlogPostKeyword(blogPostId, keywordId);
            //Assert

            Assert.Equal(keywordId, blogPostKeyword.KeywordId);
        }

        [Fact]
        public void SetKeyword_WhenIsNotNull()
        {
            //Arrange
            var blogPost = new BlogPost();
            var keyword = new Keyword();
            //Act
            var blogPostKeyword = new BlogPostKeyword(blogPost, keyword);
            //Assert

            Assert.Same(keyword, blogPostKeyword.Keyword);
        }
    }
}
