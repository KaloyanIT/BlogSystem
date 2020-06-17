namespace Blog.Services.Keywords
{
    using System.Linq;
    using Base;
    using Data.Models;

    public interface IKeywordService : IService
    {
        IQueryable<Keyword> GetAll();
    }
}