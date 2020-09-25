namespace Blog.Data.Base.Contracts
{
    using System;

    /// <summary>
    /// Interface for adding Date of Creation on each database object inside application
    /// </summary>
    public interface IHaveDateCreated
    {
        /// <summary>
        /// Date of creation.
        /// </summary>
        DateTime DateCreated { get; set; }
    }
}
