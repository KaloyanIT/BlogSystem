namespace Blog.Data.Base.Contracts
{
    /// <summary>
    /// Set Modified by property
    /// </summary>
    public interface IHaveModifiedBy
    {
        /// <summary>
        /// Modified by User Id
        /// </summary>
        string? ModifiedBy { get; set; }
    }
}
