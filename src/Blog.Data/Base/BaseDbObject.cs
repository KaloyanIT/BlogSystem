using System;

namespace Blog.Data.Base
{
    public class BaseDbObject : IDbObject, IDateSpecificObject
    {
        public BaseDbObject()
        {
            this.Id = Guid.NewGuid();
            this.DateCreated = DateTime.UtcNow;
            this.DateModified = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public virtual void Update()
        {
            this.DateModified = DateTime.UtcNow;
        }
    }
}
