namespace Blog.ViewModels.BackEnd.Roles
{
    using System;
    using Blog.Infrastructure.AutoMapper;
    using Blog.Services.Roles.Models;

    public class EditRoleViewModel : IHaveMapTo<EditRoleServiceModel>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
