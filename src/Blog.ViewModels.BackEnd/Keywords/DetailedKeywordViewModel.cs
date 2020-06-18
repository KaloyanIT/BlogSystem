namespace Blog.ViewModels.BackEnd.Keywords
{
    using Base;
    using Data.Models;
    using Infrastructure.AutoMapper;

    public class DetailedKeywordViewModel : BaseGridViewModel, IHaveMapFrom<Keyword>
    {
        public string Name { get; set; } = null!;
    }
}