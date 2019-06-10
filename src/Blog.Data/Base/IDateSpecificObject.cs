using Blog.DataAccess;
using System;

namespace Blog.Data.Base
{
    public interface IDateSpecificObject : IDbObject
    {
        DateTime DateCreated { get; set; }

        DateTime DateModified { get; set; }
    }
}
