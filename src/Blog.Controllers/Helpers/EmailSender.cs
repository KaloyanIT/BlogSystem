namespace Blog.Controllers.Helpers
{
    using System;
    using Infrastructure.Emails;
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Logging;
    using MimeKit;
    using MimeKit.Text;

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(EmailConfiguration emailConfiguration, ILogger<EmailSender> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);


            Send(emailMessage);
        }
        public void SendEmailAsync(Message message)
        {

            throw new System.NotImplementedException();
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.SmtpServer,
                        _emailConfiguration.Port,
                        _emailConfiguration.UseSSL);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);

                    client.Send(emailMessage);
                }
                catch(Exception ex)
                {
                    _logger.LogError("Email can not be sent");
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }

            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emaiMessage = new MimeMessage();
            emaiMessage.From.Add(new MailboxAddress(_emailConfiguration.From));
            emaiMessage.To.AddRange(message.To);
            emaiMessage.Subject = message.Subject;
            emaiMessage.Body = new TextPart(TextFormat.Text)
            {
                Text = message.Content
            };

            return emaiMessage;
        }

    }
}
