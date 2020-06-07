namespace Blog.Controllers.ViewModels.Admin.Tags
{
    using System;

    public class TagViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
