using System;

namespace Blog.Services.Tags.Models
{
    public class TagServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? BlogId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
