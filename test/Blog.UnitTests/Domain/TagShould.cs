using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.UnitTests.Domain
{
    public class TagShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullExceptionWhenName_IsNullOrWhitespace(string name)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Tag(name));
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
