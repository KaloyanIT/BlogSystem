namespace Blog.Data.Base
{
    using System;

    public interface IDbObject 
    {
        Guid Id { get; set; }
    }
}
