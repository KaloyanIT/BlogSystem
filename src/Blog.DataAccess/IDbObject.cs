using System;

namespace Blog.DataAccess
{
    public interface IDbObject
    {
        Guid Id { get; set; }
    }
}
