namespace Blog.Services.Keywords
{
    using System.Linq;
    using Data.Models;
    using Data.Models.Context;

    public class KeywordService : IKeywordService
    {
        private readonly BlogContext _blogContext;

        public KeywordService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public IQueryable<Keyword> GetAll()
        {
            var items = _blogContext.Keywords;

            return items;
        }
    }
}