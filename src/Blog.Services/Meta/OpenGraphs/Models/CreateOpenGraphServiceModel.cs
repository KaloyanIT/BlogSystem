namespace Blog.Services.Meta.OpenGraphs.Models
{
    using System;

    public class CreateOpenGraphServiceModel
    {
        public Guid AttachedItemId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;

    }
}
