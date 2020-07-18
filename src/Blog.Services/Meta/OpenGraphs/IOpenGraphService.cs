namespace Blog.Services.Meta.OpenGraphs
{
    using System.Linq;
    using Data.Models.Meta;
    using Base;
    using System.Threading.Tasks;
    using System;

    public interface IOpenGraphService : IService
    {
        IQueryable<OpenGraph> GetAll();

        Task<OpenGraph> GetByAttachedItemId(Guid itemId);
    }
}
