namespace Blog.Controllers.Helpers
{
    using Blog.Infrastructure.Emails;
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        private const string ConnectionName = "DefaultConnection";
        private const string EmailConfigurationName = "EmailConfiguration";

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString(ConnectionName);

        public static EmailConfiguration GetEmailConfiguration(this IConfiguration configuration)
        {
            var emailConfiguration = configuration
                    .GetSection(EmailConfigurationName)
                    .Get<EmailConfiguration>();

            if (emailConfiguration == null)
            {
                var defaultEmailConfiguration = new EmailConfiguration("test@email.com",
                    "localhost",
                    24,
                "test@test.com",
                    "121334",
                    false
                );

                return defaultEmailConfiguration;
            }

            return emailConfiguration;
        }      
    }
}
