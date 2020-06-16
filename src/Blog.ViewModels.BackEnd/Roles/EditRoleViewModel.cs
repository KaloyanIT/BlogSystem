namespace Blog.ViewModels.BackEnd.Roles
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Roles.Models;

    public class EditRoleViewModel : IHaveMapTo<EditRoleServiceModel>, IHaveMapFrom<Role>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = null!;
    }
}
