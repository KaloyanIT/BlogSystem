namespace Blog.Domain.UnitTests
{
    using System;
    using Data.Models;
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
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.Empty, this.validString, this.validString, this.validString));
        }

        [Fact]
        public void SetItemIdProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            //Act
            var comment = new Comment(id, this.validString, this.validString, this.validString);

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
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), invalidString, this.validString, this.validString));
        }

        [Fact]
        public void SetUsernameProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            //Act
            var comment = new Comment(id, username, this.validString, this.validString);

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
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), this.validString, invalidString, this.validString));
        }

        [Fact]
        public void SetEmailProperty_WhenIsValid()
        {
            //Arrange
            var id = Guid.NewGuid();
            string username = "Username";
            string email = "email";
            //Act
            var comment = new Comment(id, username, email, this.validString);

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
            Assert.Throws<ArgumentNullException>(() => new Comment(Guid.NewGuid(), this.validString, this.validString, invalidString));
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
            var comment = new Comment(id, username, email, content);

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
            var comment = new Comment(id, username, email, this.validString, userId);

            //Assert
            Assert.Equal(userId, comment.UserId);
        }
    }
}
