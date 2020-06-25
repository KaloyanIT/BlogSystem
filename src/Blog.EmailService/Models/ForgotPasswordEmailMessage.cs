namespace Blog.EmailService.Models
{
    using System.Collections.Generic;

    public class ForgotPasswordEmailMessage : BaseEmailMessage
    {
        private readonly string _link;

        public ForgotPasswordEmailMessage(IEnumerable<string> to,
            string subject,
            string content,
            string link) : base(to, subject, content)
        {
            _link = link;

            Content += _link;
        }
    }
}