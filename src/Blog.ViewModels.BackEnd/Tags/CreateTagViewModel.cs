namespace Blog.ViewModels.BackEnd.Tags
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.AutoMapper;
    using Services.Tags.Models;

    public class CreateTagViewModel : IHaveMapTo<CreateTagServiceModel>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
