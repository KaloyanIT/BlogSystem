namespace Blog.Services.Meta.OpenGraphs
{
    using System;
    using System.Threading.Tasks;
    using Data.Models.Meta;
    using Data.Repositories.Meta.OpenGraphs;
    using System.Linq;

    public class OpenGraphService : IOpenGraphService
    {
        private readonly IOpenGraphRepository _openGraphRepository;

        public OpenGraphService(IOpenGraphRepository openGraphRepository)
        {
            _openGraphRepository = openGraphRepository;
        }

        public IQueryable<OpenGraph> GetAll()
        {
            return _openGraphRepository.GetAll();
        }

        public Task<OpenGraph?> GetByAttachedItemId(Guid attachedItemId)
        {
            var openGraph = _openGraphRepository.GetByAttachedItemId(attachedItemId);

            return openGraph;
        }
    }
}
