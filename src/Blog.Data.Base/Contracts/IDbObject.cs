namespace Blog.Data.Base.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Interface for all Database objects inside application
    /// </summary>
    public interface IDbObject 
    {
        /// <summary>
        /// Unique Identifier for every Database object inside application
        /// </summary>
        [Key]
        Guid Id { get; set; }
    }
}
