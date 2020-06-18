namespace Blog.Services.Keywords
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models;
    using Models;

    public interface IKeywordService : IService
    {
        Task Create(CreateKeywordServiceModel serviceModel);

        Task Edit(EditKeywordServiceModel serviceModel);

        Task Delete(Guid id);

        IQueryable<Keyword> GetAll();

        Task<Keyword> GetById(Guid id);
    }
}