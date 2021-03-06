﻿namespace Blog.Services.Tags.Models
{
    using System;

    public class TagServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public Guid? BlogId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
