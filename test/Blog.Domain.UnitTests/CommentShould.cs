using Blog.Data.Models.Comments;

namespace Blog.Domain.UnitTests
{
    using System;
    using Xunit;

    [Trait("Comment", "unit")]
    public class CommentShould
    {
        private string validString = "validWord";

        [Fact]
        public void ThrowArgumentNullException_WhenItemId_IsGuidEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.Empty, CommentItemType.Blog, validString, validString, validString));
        }

        [Fact]
        public void SetItemIdProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            //Act
            var comment = new Comment(id, CommentItemType.Blog, validString, validString, validString);

            //Assert
            Assert.Equal(id, comment.AttachedItemId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenUsername_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), CommentItemType.Blog, invalidString, validString, validString));
        }

        [Fact]
        public void SetUsernameProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            //Act
            var comment = new Comment(id, CommentItemType.Blog, username, validString, validString);

            //Assert
            Assert.Equal(username, comment.Username);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenEmail_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), CommentItemType.Blog, validString, invalidString, validString));
        }

        [Fact]
        public void SetEmailProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            string email = "email";
            //Act
            var comment = new Comment(id, CommentItemType.Blog, username, email, validString);

            //Assert
            Assert.Equal(email, comment.Email);
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
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), CommentItemType.Blog, validString, validString, invalidString));
        }

        [Fact]
        public void SetContentProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            string email = "email";
            string content = "content";

            //Act
            var comment = new Comment(id, CommentItemType.Blog, username, email, content);

            //Assert
            Assert.Equal(content, comment.Content);
        }

        [Fact]
        public void SetUserIdProperty_WhenIsNotNullOrWhitespace()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            string email = "email";
            string userId = "user-id";

            //Act
            var comment = new Comment(id, CommentItemType.Blog, username, email, validString, userId);

            //Assert
            Assert.Equal(userId, comment.UserId);
        }
    }
}
