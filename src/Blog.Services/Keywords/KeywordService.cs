namespace Blog.Services.Keywords
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Models;
    using Data.Models.Context;
    using Data.Repositories.Keywords;
    using Microsoft.Extensions.Logging;
    using Models;
    using Roles.Models;

    public class KeywordService : BaseService, IKeywordService
    {
        private readonly IKeywordRepository _keywordRepository;

        public KeywordService(IKeywordRepository keywordRepository,
            IMapper mapper,
            ILogger<KeywordService> logger) : base(mapper, logger)
        {
            _keywordRepository = keywordRepository;
        }


        public async Task Create(CreateKeywordServiceModel serviceModel)
        {
            var item = new Keyword(serviceModel.Name);

            await _keywordRepository.Save(item);
        }

        public async Task Edit(EditKeywordServiceModel serviceModel)
        {
            var item = await this.GetById(serviceModel.Id);

            item.Edit(serviceModel.Name);

            await _keywordRepository.Save(item);
        }

        public async Task Delete(Guid id)
        {
            var item = await this.GetById(id);

            await _keywordRepository.Delete(item);
        }

        public IQueryable<Keyword> GetAll()
        {
            var items = _keywordRepository.GetAll();

            return items;
        }

        public async Task<Keyword> GetById(Guid id)
        {
            var item = await _keywordRepository.GetById(id);

            return item;
        }
    }
}