namespace Blog.ViewModels.BackEnd.Meta.OpenGraphs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Blog.Services.Meta.OpenGraphs.Models;
    using Data.Models.Meta;
    using Infrastructure.AutoMapper;

    public class OpenGraphViewModel : IHaveMapFrom<OpenGraph>, IHaveMapTo<CreateOpenGraphServiceModel>, IHaveMapTo<EditOpenGraphServiceModel>
    {
        public OpenGraphViewModel()
        {

        }

        public OpenGraphViewModel(Guid attachedItemId)
        {
            this.AttachedItemId = attachedItemId;
        }

        public Guid Id { get; set; }

        public Guid AttachedItemId { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; } = null!;
    }
}
