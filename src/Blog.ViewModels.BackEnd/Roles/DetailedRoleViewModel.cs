namespace Blog.ViewModels.BackEnd.Roles
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedRoleViewModel : IHaveMapFrom<Role>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

    }
}