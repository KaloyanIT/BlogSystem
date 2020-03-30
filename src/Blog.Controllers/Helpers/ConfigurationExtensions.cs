namespace Blog.Controllers.Helpers
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        private static readonly string ConnectionName = "DefaultConnection";

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString(ConnectionName);
    }
}
