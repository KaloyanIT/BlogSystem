namespace Blog.EmailService
{
    using System;
    using System.Threading.Tasks;
    using Adapters;
    using AutoMapper;
    using Infrastructure.Emails;
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Logging;
    using MimeKit;
    using Models;
    using Services.Base;

    public class EmailsService : BaseService, IEmailsService
    {
        private readonly BaseEmailMessageAdapter _adapter;
        private readonly EmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailsService> _logger;

        public EmailsService(BaseEmailMessageAdapter adapter,
            EmailConfiguration emailConfiguration,
            IMapper mapper,
            ILogger<EmailsService> logger) : base(mapper, logger)
        {
            _adapter = adapter;
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public void SendEmail<T>(T message) where T : BaseEmailMessage
        {
            var mimeMessage = new MimeMessage();

            _adapter.Adapt(message, mimeMessage);

            SendAsync(mimeMessage).Wait();
        }

        public async Task SendEmailAsync<T>(T message) where T : BaseEmailMessage
        {
            var mimeMessage = new MimeMessage();

            _adapter.Adapt(message, mimeMessage);

            await SendAsync(mimeMessage);
        }

        private async Task SendAsync(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();

            emailMessage.From.Add(MailboxAddress.Parse(_emailConfiguration.From));

            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer,
                    _emailConfiguration.Port,
                    _emailConfiguration.UseSsl);

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
    }
}
