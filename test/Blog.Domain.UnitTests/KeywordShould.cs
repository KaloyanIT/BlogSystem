namespace Blog.Domain.UnitTests
{
    using System;
    using Data.Models;
    using Xunit;

    [Trait("Keyword", "unit")]
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
