using System;
using Blog.Data.Models;
using Xunit;

namespace Blog.UnitTests.Domain
{
    public class KeywordShould
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
            Assert.Throws<ArgumentNullException>(() => new Keyword(name));
        }

        [Fact]
        public void SetNameProperty_WhenIsValid()
        {
            //Arrange
            string name = "Name";
            //Act
            var keyword = new Keyword(name);

            //Assert
            Assert.True(keyword.Name == name);
        }
    }
}
