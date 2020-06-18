namespace Blog.ViewModels.BackEnd.Keywords
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.AutoMapper;
    using Services.Keywords.Models;

    public class CreateKeywordViewModel : IHaveMapTo<CreateKeywordServiceModel>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;
    }
}