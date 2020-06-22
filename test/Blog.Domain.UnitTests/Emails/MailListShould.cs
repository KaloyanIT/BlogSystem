namespace Blog.Domain.UnitTests.Emails
{
    using System;
    using Data.Models.Emails;
    using Xunit;

    [Trait("MailList", "unit")]
    public class MailListShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenName_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new MailList(invalidString, "Description"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowArgumentNullException_WhenDescription_IsNUll(string invalidString)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new MailList("Name", invalidString));
        }

        [Theory]
        [InlineData("MailList1")]
        [InlineData("MailList2")]
        [InlineData("MailList3")]
        public void SetName_WhenName_IsValid(string validName)
        {
            //Arrange
            //Act
            var mailList = new MailList(validName, "Description");

            //Assert
            Assert.True(validName == mailList.Name);
        }

        [Theory]
        [InlineData("MailList1Description")]
        [InlineData("MailList2Descripiton")]
        [InlineData("MailList3Description")]
        public void SetDescription_WhenDescription_IsValid(string validDescription)
        {
            //Arrange
            //Act
            var mailList = new MailList("validName", validDescription);

            //Assert
            Assert.True(validDescription == mailList.Description);
        }

        [Theory]
        [InlineData("MailList1Description")]
        [InlineData("MailList2Descripiton")]
        [InlineData("MailList3Description")]
        public void MailSubscribersCollection_ShouldNotBeNull_OnCreate(string validDescription)
        {
            //Arrange
            //Act
            var mailList = new MailList("validName", validDescription);

            //Assert
            Assert.NotNull(mailList.MailListSubscribers);
        }

        [Theory]
        [InlineData("MailList1")]
        [InlineData("MailList2")]
        [InlineData("MailList3")]
        public void SetName_WhenNameIsValid_OnEdit(string validName)
        {
            //Arrange
            var mailList = new MailList("validName", "validDescription");

            //Act
            mailList.Edit(validName, "someDescription");

            //Assert
            Assert.True(validName == mailList.Name);
        }

        [Theory]
        [InlineData("MailList1Description")]
        [InlineData("MailList2Descripiton")]
        [InlineData("MailList3Description")]
        public void SetDescription_WhenDescriptionIsValid_OnEdit(string validDescription)
        {
            //Arrange
            var mailList = new MailList("validName", "testDesc");

            //Act
            mailList.Edit("someName", validDescription);

            //Assert
            Assert.True(validDescription == mailList.Description);
        }

        [Fact]
        public void SetSubscribersToNull_OnDelete()
        {
            //Arrange
            var mailList = new MailList("validName", "testDesc");

            //Act
            mailList.Delete();

            //Assert
            Assert.Null(mailList.MailListSubscribers);
        }
    }
}
