namespace Blog.Services.Meta.OpenGraphs
{
    using System;
    using System.Threading.Tasks;
    using Data.Models.Meta;
    using Data.Repositories.Meta.OpenGraphs;
    using System.Linq;
    using Models;
    using AutoMapper;

    public class OpenGraphService : IOpenGraphService
    {
        private readonly IOpenGraphRepository _openGraphRepository;
        private readonly IMapper _mapper;

        public OpenGraphService(IOpenGraphRepository openGraphRepository, IMapper mapper)
        {
            _openGraphRepository = openGraphRepository;
            this._mapper = mapper;
        }

        public async Task Create(CreateOpenGraphServiceModel serviceModel, Guid attachedItemId)
        {
            serviceModel.AttachedItemId = attachedItemId;

            var openGraph = new OpenGraph(attachedItemId, serviceModel.Title, serviceModel.Description, serviceModel.Url, serviceModel.ImageUrl);

            try
            {
                await _openGraphRepository.Save(openGraph);
            }
            catch (Exception ex)
            {

            }
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
