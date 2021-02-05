namespace Blog.ViewModels.FrontEnd
{
    using System;

    public class HeaderViewModel
    {
        public string Title { get; set; } = null!;

        public string SubTitle { get; set; } = null!;

        public DateTime? CreationDate { get; set; }

        public string? Author { get; set; }
    }
}
