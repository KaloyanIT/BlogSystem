namespace Blog.Infrastructure.Emails
{
    using System.Collections.Generic;
    using System.Linq;
    using MimeKit;

    public class Message
    {
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
        }

        public string Subject { get; }

        public string Content { get; }

        public List<MailboxAddress> To { get; }
    }
}
