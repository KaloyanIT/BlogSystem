using AutoMapper;
using Blog.Core.ViewModels.Blogs;
using Blog.Data;
using Blog.Services.Models;
using System.Reflection;

namespace Blog.Core.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            this.CreateMap<BlogPost, BlogServiceModel>().ReverseMap();
            this.CreateMap<CreateBlogServiceModel, BlogPost>().ReverseMap();    
            this.CreateMap<CreateBlogViewModel, CreateBlogServiceModel>().ReverseMap();
            this.CreateMap<CreateBlogViewModel, BlogServiceModel>().IgnoreAllNonExisting().ReverseMap();
        }        
    }

    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
 (this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}
