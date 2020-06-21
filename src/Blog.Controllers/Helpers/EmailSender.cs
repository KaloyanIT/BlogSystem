namespace Blog.Controllers.Helpers
{
    using System;
    using System.Threading.Tasks;
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

        public async Task SendEmailAsync(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsync(emailMessage);
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer,
                    _emailConfiguration.Port,
                    false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);

                await client.SendAsync(emailMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email can not be sent");
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }

        private void Send(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfiguration.SmtpServer,
                    _emailConfiguration.Port,
                    _emailConfiguration.UseSsl);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);

                client.Send(emailMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email can not be sent");
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
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
