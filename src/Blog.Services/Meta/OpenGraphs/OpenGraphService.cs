﻿namespace Blog.Services.Meta.OpenGraphs
{
    using System;
    using System.Threading.Tasks;
    using Data.Models.Meta;
    using Data.Repositories.Meta.OpenGraphs;
    using System.Linq;
    using Models;
    using AutoMapper;
    using System.Diagnostics.CodeAnalysis;

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
            catch (Exception ex)
            {

            }
        }

        public async Task Edit(EditOpenGraphServiceModel serviceModel)
        {
            var openGraph = await _openGraphRepository.GetByAttachedItemId(serviceModel.Id);

            if(openGraph == null)
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
