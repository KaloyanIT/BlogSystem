using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.Domain.UnitTests
{
    public class BlogPostShould
    {
        private string validString = "validString";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenTitle_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPost(invalidString, this.validString, this.validString, this.validString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenContent_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPost(this.validString, invalidString, this.validString, this.validString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenSummary_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPost(this.validString, this.validString, invalidString, this.validString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenUserId_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new BlogPost(this.validString, this.validString, this.validString, invalidString));
        }

        [Fact]
        public void SetTitleProperty_WhenIsValid()
        {
            //Arrange
            string title = "Name";
            //Act
            var blogPost = new BlogPost(title, this.validString, this.validString, this.validString);

            //Assert
            Assert.True(title == blogPost.Title);
        }

        [Fact]
        public void SetContentProperty_WhenIsValid()
        {
            //Arrange
            string content = "Content";
            //Act
            var blogPost = new BlogPost(this.validString, content, this.validString, this.validString);

            //Assert
            Assert.True(content == blogPost.Content);
        }

        [Fact]
        public void SetSummaryProperty_WhenIsValid()
        {
            //Arrange
            string summary = "Summary";
            //Act
            var blogPost = new BlogPost(this.validString, this.validString, summary, this.validString);

            //Assert
            Assert.True(summary == blogPost.Summary);
        }

        [Fact]
        public void SetUserIdProperty_WhenIsValid()
        {
            //Arrange
            string userId = "Name";
            //Act
            var blogPost = new BlogPost(this.validString, this.validString, this.validString, userId);

            //Assert
            Assert.True(userId == blogPost.UserId);
        }
    }
}
