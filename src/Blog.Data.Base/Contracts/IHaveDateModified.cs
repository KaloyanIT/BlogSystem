namespace Blog.Data.Base.Contracts
{
    using System;

    /// <summary>
    ///  Add Date of modification to database objects
    /// </summary>
    public interface IHaveDateModified
    {
        /// <summary>
        /// Date of modification
        /// </summary>
        DateTime? DateModified { get; set; }
    }
}
