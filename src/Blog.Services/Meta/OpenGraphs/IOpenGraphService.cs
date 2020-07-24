namespace Blog.Services.Meta.OpenGraphs
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models.Meta;
    using Models;

    public interface IOpenGraphService : IService
    {
        IQueryable<OpenGraph> GetAll();

        Task<OpenGraph> GetBiId(Guid id);

        Task<OpenGraph?> GetByAttachedItemId(Guid itemId);

        Task Create(CreateOpenGraphServiceModel createOpenGraphServiceModel, Guid attachedItemId);

        Task Edit(EditOpenGraphServiceModel serviceModel, Guid id);
    }
}
