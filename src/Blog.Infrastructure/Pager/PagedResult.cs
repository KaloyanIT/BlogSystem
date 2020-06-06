using System.Collections.Generic;

namespace Blog.Infrastructure.Pager
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }       

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
