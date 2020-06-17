namespace Blog.ViewModels.BackEnd.Roles
{
    using System.ComponentModel.DataAnnotations;
    using Blog.Services.Roles.Models;
    using Infrastructure.AutoMapper;

    public class CreateRoleViewModel : IHaveMapTo<CreateRoleServiceModel>
    {
        [Required] [MinLength(4)] public string Name { get; set; } = null!;

        [Required] [MinLength(4)] public string Description { get; set; } = null!;
    }
}
