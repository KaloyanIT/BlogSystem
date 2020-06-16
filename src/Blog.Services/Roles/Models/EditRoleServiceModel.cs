namespace Blog.Services.Roles.Models
{
    using System;

    public class EditRoleServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
