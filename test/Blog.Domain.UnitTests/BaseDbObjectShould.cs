namespace Blog.Domain.UnitTests
{
    using System;
    using Data.Base;
    using Xunit;

    [Trait("BaseDbObject", "unit")]
    public class BaseDbObjectShould
    {
        [Fact]
        public void AssignValidGuid_OnCreate()
        {
            //Arrange
            //Act
            var baseModel = new TestBaseDbObject();

            //Assert
            Assert.True(baseModel.Id != Guid.Empty);
        }

        [Fact]
        public void SetDataCreated_And_DateModified_OnCreate()
        {
            //Arrange
            //Act
            var baseModel = new TestBaseDbObject();

            //Assert
            Assert.True(baseModel.DateCreated != null);
        }
    }

    public class TestBaseDbObject : BaseDbObject
    {

    }
}
