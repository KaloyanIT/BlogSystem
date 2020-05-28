﻿namespace Blog.Controllers.Helpers
{
    using Blog.Infrastructure.Emails;
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        private static readonly string ConnectionName = "DefaultConnection";
        private static readonly string EmailConfigurationName = "EmailConfiguration";

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString(ConnectionName);

        public static EmailConfiguration GetEmailConfiguration(this IConfiguration configuration)
        {
            var emailConfiguration = configuration
                    .GetSection("EmailConfiguration")
                    .Get<EmailConfiguration>();

            if(emailConfiguration == null)
            {
                var defaultEmailConfiguration = new EmailConfiguration()
                {
                    From = "test@email.com",
                    SmtpServer ="localhost",
                    UseSSL = false,
                    Username = "test@test.com",
                    Password = "121334",
                    Port = 24
                };

                return defaultEmailConfiguration;
            }

            return emailConfiguration;
        }
    }
}
