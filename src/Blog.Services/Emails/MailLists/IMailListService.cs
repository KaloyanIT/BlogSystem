namespace Blog.Services.Emails.MailLists
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Data.Models.Emails;
    using Models;

    public interface IMailListService : IService
    {
        IQueryable<MailList> GetAll();

        Task Create(CreateMailListServiceModel serviceModel);

        Task Delete(Guid id);
    }
}
