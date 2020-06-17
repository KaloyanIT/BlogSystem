namespace Blog.Services.Tags.Models
{
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class CreateTagServiceModel : IHaveMapTo<Tag>
    {
        public string Name { get; set; } = null!;
    }
}
