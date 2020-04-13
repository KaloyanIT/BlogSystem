namespace Blog.Infrastructure.Emails
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using MimeKit;

    public class Message
    {
        private readonly List<MailboxAddress> _to;
        private readonly string _subject;
        private readonly string _content;

        public Message(IEnumerable<string> to, string subject, string content)
        {
            _to = new List<MailboxAddress>();

            _to.AddRange(to.Select(x => new MailboxAddress(x)));
            _subject = subject;
            _content = content;
        }

        public string Subject => _subject;

        public string Content => _content;

        public List<MailboxAddress> To => _to;
    }
}
