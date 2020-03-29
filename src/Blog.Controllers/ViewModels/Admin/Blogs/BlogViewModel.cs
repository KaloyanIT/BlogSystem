namespace Blog.Controllers.ViewModels.Admin.Blogs
{
    using AutoMapper;
    using System;


    using Data.Models;
    using Infrastructure.AutoMapper;

    public class BlogViewModel : IHaveMapFrom<BlogPost>, IHaveCustomMap
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, BlogViewModel>()
                .ForMember(x => x.CreatedBy, x => x.MapFrom(z => z.User.UserName));
        }
    }
}
