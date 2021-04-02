namespace Blog.EmailService
{
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task Send(string email, string subject, string content);

        Task Send(string email, string templateId, object templateModel);
    }
}
