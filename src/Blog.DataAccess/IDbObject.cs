namespace Blog.DataAccess
{
    using System;

    public interface IDbObject 
    {
        Guid Id { get; set; }
    }
}
