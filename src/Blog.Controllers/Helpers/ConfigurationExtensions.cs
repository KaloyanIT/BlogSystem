namespace Blog.Controllers.Helpers
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        private const string ConnectionName = "DefaultConnection";
        private const string EmailConfigurationName = "EmailConfiguration";

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString(ConnectionName);        
    }
}
