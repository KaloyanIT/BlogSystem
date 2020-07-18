namespace Blog.Data.Repositories.Meta.OpenGraphs
{
    using Base;
    using Models.Meta;
    using DataAccess;

    public interface IOpenGraphRepository : IRepository<OpenGraph>, ITransientRepository
    {
    }
}
