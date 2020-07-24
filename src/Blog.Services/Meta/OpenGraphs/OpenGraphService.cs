namespace Blog.Services.Meta.OpenGraphs
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data.Models.Meta;
    using Data.Repositories.Meta.OpenGraphs;
    using Models;

    public class OpenGraphService : IOpenGraphService
    {
        private readonly IOpenGraphRepository _openGraphRepository;
        private readonly IMapper _mapper;

        public OpenGraphService(IOpenGraphRepository openGraphRepository, IMapper mapper)
        {
            _openGraphRepository = openGraphRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateOpenGraphServiceModel serviceModel, Guid attachedItemId)
        {
            serviceModel.AttachedItemId = attachedItemId;

            var openGraph = new OpenGraph(attachedItemId,
                serviceModel.Title,
                serviceModel.Description,
                serviceModel.Type,
                serviceModel.Url,
                serviceModel.ImageUrl);

            try
            {
                await _openGraphRepository.Save(openGraph);
            }
            catch (Exception)
            {

            }
        }

        public async Task Delete(Guid attachedItemId)
        {
            var openGraph = await GetByAttachedItemId(attachedItemId);

            if (openGraph == null)
            {
                throw new Exception("OpenGraph can not be found!");
            }

            await _openGraphRepository.Delete(openGraph);
        }

        public async Task Edit(EditOpenGraphServiceModel serviceModel, Guid id)
        {
            var openGraph = await _openGraphRepository.GetById(id);

            if (openGraph == null)
            {
                throw new Exception("Open Graph can not be found!");
            }

            openGraph.Edit(serviceModel.Title,
                serviceModel.Description,
                serviceModel.Type,
                serviceModel.Url,
                serviceModel.ImageUrl);

            await _openGraphRepository.Save(openGraph);
        }

        public IQueryable<OpenGraph> GetAll()
        {
            return _openGraphRepository.GetAll();
        }

        public async Task<OpenGraph> GetBiId(Guid id)
        {
            var openGraph = await _openGraphRepository.GetById(id);

            return openGraph;
        }

        public Task<OpenGraph?> GetByAttachedItemId(Guid attachedItemId)
        {
            var openGraph = _openGraphRepository.GetByAttachedItemId(attachedItemId);

            return openGraph;
        }
    }
}
