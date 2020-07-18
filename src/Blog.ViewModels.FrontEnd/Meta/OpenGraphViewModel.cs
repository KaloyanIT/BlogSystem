﻿namespace Blog.ViewModels.FrontEnd.Meta
{
    using System;
    using Data.Migrations;
    using Infrastructure.AutoMapper;

    public class OpenGraphViewModel : IHaveMapFrom<CreateOpenGraph>
    {
        public Guid AttachedItemId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
