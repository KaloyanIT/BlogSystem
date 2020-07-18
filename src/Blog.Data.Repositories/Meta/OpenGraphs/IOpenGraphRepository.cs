namespace Blog.Data.Repositories.Meta.OpenGraphs
{
    using Base;
    using Models.Meta;
    using DataAccess;
    using System;
    using System.Threading.Tasks;

    public interface IOpenGraphRepository : IRepository<OpenGraph>, ITransientRepository
    {
        Task<OpenGraph> GetByAttachedItemId(Guid attachedItemId);
    }
}
