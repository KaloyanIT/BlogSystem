namespace Blog.Domain.UnitTests
{
    using System;
    using Blog.Data.Models;
    using Xunit;

    [Trait("ContactData", "unit")]
    public class ContactDataShoulds
    {
        private string validString = "validString";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenName_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContactData(invalidString, validString, validString, validString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenSubject_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContactData(validString, invalidString, validString, validString));
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
            Assert.Throws<ArgumentNullException>(() => new ContactData(validString, validString, invalidString, validString));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenMessage_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContactData(validString, validString, validString, invalidString));
        }

    }
}
