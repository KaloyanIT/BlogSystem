using System;

namespace Blog.Data.Base
{
    public interface IDbObject
    {
        Guid Id { get; set; }
    }
}
