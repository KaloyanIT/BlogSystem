namespace Blog.EmailService
{
    using System;
    using System.Threading.Tasks;
    using Infrastructure.Options;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Errors.Model;
    using SendGrid.Helpers.Mail;

    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SendGridOptions> _sendGridOptions;
        private readonly SendGridClient _sendGridClient;

        public EmailSender(IOptions<SendGridOptions> sendGridOptions)
        {
            _sendGridOptions = sendGridOptions;
            _sendGridClient = new SendGridClient(_sendGridOptions.Value.ApiKey);
        }

        public async Task Send(string email, string subject, string content)
        {
            var message = new SendGridMessage();

            message.SetFrom("mail@kaloyanit.com", "Kaloyan Kostov");            

            message.AddTo(email);

            message.SetSubject(subject);

            message.AddContent(MimeType.Html, content);

            var response = await _sendGridClient.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("SendGrid Error");
            }
        }
    }
}
