namespace Blog.EmailService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MimeKit;

    public abstract class BaseEmailMessage
    {
        private ICollection<MailboxAddress> _to;
        private string _subject;
        private string _content;

        protected BaseEmailMessage(IEnumerable<string> to, string subject, string content)
        {
            Subject = subject;
            Content = content;

            _to = ParseEmailAddresses(to);
        }

        public string Subject
        {
            get => _subject;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Subject can not be null!");
                }

                _subject = value;
            }
        }

        public string Content
        {
            get => _content;

            protected set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Content can not be null!");
                }

                _content = value;
            }
        }

        public ICollection<MailboxAddress> To
        {
            get => _to;

            private set => _to = value ?? throw new ArgumentNullException(nameof(value), "Email Sender collection can not be null!");
        }

        protected ICollection<MailboxAddress> ParseEmailAddresses(IEnumerable<string> emailAddresses)
        {
            var mailBoxAddresses = new List<MailboxAddress>();

            mailBoxAddresses.AddRange(emailAddresses.Select(MailboxAddress.Parse));

            return mailBoxAddresses;
        }
    }
}
