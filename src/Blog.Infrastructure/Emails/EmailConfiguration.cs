namespace Blog.Infrastructure.Emails
{
    public class EmailConfiguration
    {
        public string From { get; set; }

        public string SmtpServer { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool UseSsl { get; set; }


        public EmailConfiguration()
        {
            From = string.Empty;
            SmtpServer = string.Empty;
            Port = 0;
            Username = string.Empty;
            Password = string.Empty;
            UseSsl = false;
        }

        public EmailConfiguration(string from, string smtpServer, int port, string username, string password, bool useSsl)
        {
            From = from;
            SmtpServer = smtpServer;
            Port = port;
            Username = username;
            Password = password;
            UseSsl = useSsl;
        }
    }
}
