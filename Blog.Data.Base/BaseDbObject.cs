namespace Blog.Data.Base
{
    using System;

    public abstract class BaseDbObject : IDbObject, IHaveDateCreated, IHaveDateModified
    {
        public BaseDbObject()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
