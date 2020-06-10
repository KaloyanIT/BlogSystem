namespace Blog.Data.Base.Extensions
{
    using System;
    using System.Linq;
    using Infrastructure.Pager;

    /// <summary>
    /// Extension for common Linq operations
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Get pager functionality
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="query">IQueryable collection of data</param>
        /// <param name="page">Current page number</param>
        /// <param name="pageSize">Items that are displayed per page</param>
        /// <returns></returns>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                                    int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
