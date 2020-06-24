namespace Blog.EmailService
{
    using System.Threading.Tasks;
    using Adapters;
    using MimeKit;
    using Models;

    public class EmailService : IEmailService
    {
        private readonly BaseEmailMessageAdapter _adapter;

        public EmailService(BaseEmailMessageAdapter adapter)
        {
            _adapter = adapter;
        }

        public void SendEmail<T>(T message) where T : BaseEmailMessage
        {
            var mimeMessage = new MimeMessage();

            _adapter.Adapt(message, mimeMessage);


        }

        public async Task SendEmailAsync<T>(T message) where T : BaseEmailMessage
        {
            throw new System.NotImplementedException();
        }
    }
}
