using AutoMapper;
using Blog.Data;
using Blog.Services.Models;

namespace Blog.Core.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            this.CreateMap<BlogPost, BlogServiceModel>();
            this.CreateMap<BlogServiceModel, BlogPost>();
        }
    }
}
