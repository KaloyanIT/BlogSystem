using System;

namespace Blog.Services.Keywords.Models
{
    public class EditKeywordServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
