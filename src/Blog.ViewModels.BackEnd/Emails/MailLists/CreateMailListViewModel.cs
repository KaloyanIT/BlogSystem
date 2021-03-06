﻿namespace Blog.ViewModels.BackEnd.Emails.MailLists
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.AutoMapper;
    using Services.Emails.MailLists.Models;

    public class CreateMailListViewModel : IHaveMapTo<CreateMailListServiceModel>
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(20)]
        public string Description { get; set; } = null!;
    }
}
