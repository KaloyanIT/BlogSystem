
namespace Blog.Data.Base
{
    using System;
    using DataAccess;

    public interface IDateSpecificObject : IDbObject
    {
        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}
