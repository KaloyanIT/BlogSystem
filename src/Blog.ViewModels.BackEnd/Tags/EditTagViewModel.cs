namespace Blog.ViewModels.BackEnd.Tags
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Tags.Models;

    public class EditTagViewModel : IHaveMapTo<EditTagServiceModel>, IHaveMapFrom<Tag>
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
