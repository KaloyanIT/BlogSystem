using Blog.Data.Base;
using System;
using Xunit;

namespace Blog.UnitTests.Domain
{
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
