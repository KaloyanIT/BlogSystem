namespace Blog.ViewModels.BackEnd.Tags
{
    using System;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class TagViewModel : IHaveMapFrom<Tag>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
