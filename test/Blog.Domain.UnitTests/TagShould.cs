using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.Domain.UnitTests
{
    public class TagShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab")]
        [InlineData("a")]
        public void ThrowArgumentNullExceptionWhenName_IsNullOrWhitespace(string name)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Tag(name));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab")]
        [InlineData("a")]
        public void ThrowArgumentNullExceptionWhenName_IsNullOrWhitespace_OnEdit(string name)
        {
            //Arrange
            var tag = new Tag("valid name");
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => tag.EditName(name));
        }

        [Fact]
        public void SetNameProperty_WhenIsValid()
        {
            //Arrange
            string name = "Name";
            //Act
            var tag = new Tag(name);

            //Assert
            Assert.True(tag.Name == name);
        }
    }
}
