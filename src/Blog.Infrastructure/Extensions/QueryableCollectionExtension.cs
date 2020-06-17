namespace Blog.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using global::AutoMapper.QueryableExtensions;

    //using AutoMapper.QueryableExtensions;

    public static class QueryableCollectionExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.MapperConfiguration, membersToExpand);
        }
    }
}
