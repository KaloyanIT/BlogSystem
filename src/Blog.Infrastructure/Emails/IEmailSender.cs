using System.Threading.Tasks;

namespace Blog.Infrastructure.Emails
{
    public interface IEmailSender
    {
        void SendEmail(Message message);

        Task SendEmailAsync(Message message);
    }
}
