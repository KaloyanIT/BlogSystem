namespace Blog.Domain.UnitTests.Meta
{
    using System;
    using Blog.Data.Models.Meta;
    using Xunit;

    [Trait("OpenGraph", "unit")]
    public class OpenGraphShould
    {
        private string validString = "ValidString";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenTitle_IsNUllOrEmtpyString(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new OpenGraph(Guid.NewGuid(), invalidString, this.validString, this.validString, this.validString));
        }

         [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenDescription_IsNUllOrEmptyString(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new OpenGraph(Guid.NewGuid(), this.validString, invalidString, this.validString, this.validString));
        }

             [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenType_IsNUllOrEmptyString(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new OpenGraph(Guid.NewGuid(), this.validString, this.validString, invalidString, this.validString));
        }

             [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenUrl_IsNUllOrEmptyString(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new OpenGraph(Guid.NewGuid(), this.validString, this.validString, this.validString, invalidString));
        }
    }
}
