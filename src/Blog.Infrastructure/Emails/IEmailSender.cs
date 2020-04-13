namespace Blog.Infrastructure.Emails
{
    public interface IEmailSender
    {
        void SendEmail(Message message);

        void SendEmailAsync(Message message);
    }
}
