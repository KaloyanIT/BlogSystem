namespace Blog.Data.Base
{
    using Contracts;
    using System;

    /// <summary>
    ///  Abstract Class which combine all needed properties for normal function of the one system database object.
    /// </summary>
    public abstract class BaseDbObject : IDbObject, IHaveDateCreated, IHaveDateModified, IHaveCreatedBy, IHaveModifiedBy
    {
        /// <summary>
        /// Base Database Object
        /// </summary>
        protected BaseDbObject()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Unique Identifier for every Database object inside application
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date of modification
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Creator user id
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Editor user id
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
