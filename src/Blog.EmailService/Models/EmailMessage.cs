namespace Blog.EmailService.Models
{
    using System.Collections.Generic;

    public class EmailMessage : BaseEmailMessage
    {
        public EmailMessage(IEnumerable<string> to, string subject, string content) : base(to, subject, content)
        {
        }
    }
}
