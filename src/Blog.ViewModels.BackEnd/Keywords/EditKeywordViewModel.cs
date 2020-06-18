namespace Blog.ViewModels.BackEnd.Keywords
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.AutoMapper;
    using Services.Keywords.Models;

    public class EditKeywordViewModel : IHaveMapFrom<Keyword>, IHaveMapTo<EditKeywordServiceModel>
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; } = null!;
    }
}