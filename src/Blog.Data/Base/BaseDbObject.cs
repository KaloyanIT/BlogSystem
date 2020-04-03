namespace Blog.Data.Base
{
    using System;
    using DataAccess;

    public abstract class BaseDbObject : IDbObject, IHaveDateCreated, IHaveDateModified
    {
        public BaseDbObject()
        {
            this.Id = Guid.NewGuid();            
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }        
    }
}
