namespace Blog.Data.Base.Contracts
{
    /// <summary>
    /// Interface for setting created by property
    /// </summary>
    public interface IHaveCreatedBy
    {
        /// <summary>
        /// Created by User Id
        /// </summary>
        string CreatedBy { get; set; }
    }
}
