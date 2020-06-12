namespace Blog.Services.Tags.Models
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class EditTagServiceModel : IHaveMapTo<Tag>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
